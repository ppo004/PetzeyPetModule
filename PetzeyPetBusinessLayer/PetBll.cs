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

                 cfg.CreateMap<UpdatePetDto, Pet>()

             );
        MapperConfiguration config2 = new MapperConfiguration(cfg =>

                 cfg.CreateMap<Pet, UpdatePetDto>()

             );
       

        public UpdatePetDto CreatePet(AddPetDto petDto)
        {
            Mapper mapper = new Mapper(config);
            Pet pet = mapper.Map<Pet>(petDto);
          

            int id = repo.CreatePet(pet);
            Pet pet1 = repo.GetPetById(id);

            Mapper mapper1 = new Mapper(config2);
            UpdatePetDto petDto1 = mapper1.Map<UpdatePetDto>(pet1);
            return petDto1;

        }

       
        public UpdatePetDto EditPet(UpdatePetDto petDto)
        {
            Mapper mapper = new Mapper(config1);
            Pet pet = mapper.Map<Pet>(petDto);
            Pet p = repo.EditPet(pet);

            Mapper mapper1 = new Mapper(config2);
            UpdatePetDto changedPetDto = mapper1.Map<UpdatePetDto>(p);

            return changedPetDto;


        }

        public bool DeletePet(int id)
        {
            repo.DeletePet(id);
            if (repo.GetPetById(id) == null)
                return true;
            return false;
        }

        public UpdatePetDto GetPetById(int id)
        {
            Pet pet = repo.GetPetById(id);
            Mapper mapper1 = new Mapper(config2);
            UpdatePetDto petDto = mapper1.Map<UpdatePetDto>(pet);
            if (petDto == null)
                return null;
            return petDto;
        }

        public List<UpdatePetDto> GetAllPets()
        {
            Mapper mapper1 = new Mapper(config2);
            List<UpdatePetDto> petDto = new List<UpdatePetDto>();
            foreach (Pet pets in repo.GetAllPets())
                petDto.Add(mapper1.Map<UpdatePetDto>(pets));
            return petDto;
        }

    }
}