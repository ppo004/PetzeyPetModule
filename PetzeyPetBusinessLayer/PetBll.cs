using AutoMapper;
using PetzeyPetDataAccessLayer;
using PetzeyPetDTOs;
using PetzeyPetEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetBusinessLayer
{
    public class PetBll
    {
        IPetDbRepository repo = new PetDbRepository();
        MapperConfiguration config = new MapperConfiguration(cfg =>

                  cfg.CreateMap<AddPetDto, Pet>().ForMember(dest => dest.AppointmentIds, act => act.Ignore())

              );
        MapperConfiguration config1 = new MapperConfiguration(cfg =>

                 cfg.CreateMap<PetDto, Pet>()

             );
        MapperConfiguration config2 = new MapperConfiguration(cfg =>

                 cfg.CreateMap<Pet, PetDto>()

             );

        public PetDto CreatePet(AddPetDto petDto)
        {
            Mapper mapper = new Mapper(config);
            Pet pet = mapper.Map<Pet>(petDto);
            int id = repo.CreatePet(pet);
            Pet pet1 = repo.GetPetById(id);

            Mapper mapper1 = new Mapper(config2);
            PetDto petDto1 = mapper1.Map<PetDto>(pet1);
            return petDto1;

        }
        public PetDto EditPet(PetDto petDto)
        {
            Mapper mapper = new Mapper(config1);
            Pet pet = mapper.Map<Pet>(petDto);
            Pet p = repo.EditPet(pet);

            Mapper mapper1 = new Mapper(config2);
            PetDto changedPetDto = mapper1.Map<PetDto>(p);

            return changedPetDto;


        }

        public bool DeletePet(int id)
        {
            repo.DeletePet(id);
            if (repo.GetPetById(id) == null)
                return true;
            return false;
        }

        public PetDto GetPetById(int id)
        {
            Pet pet = repo.GetPetById(id);
            Mapper mapper1 = new Mapper(config2);
            PetDto petDto = mapper1.Map<PetDto>(pet);
            if (petDto == null)
                return null;
            return petDto;
        }

    }
}