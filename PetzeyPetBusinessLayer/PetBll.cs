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

        /// <summary>
        /// BLL Functions
        /// </summary>

        public UpdatePetDto CreatePet(AddPetDto petDto)
        {
            Mapper mapper = new Mapper(config);
            Pet pet = mapper.Map<Pet>(petDto);
            pet.AppointmentIds = null;

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

        /// <summary>
        /// Async BLL Functions
        /// </summary>

        public async Task<UpdatePetDto> CreatePetAsync(AddPetDto petDto)
        {
            Mapper mapper = new Mapper(config);
            Pet pet = mapper.Map<Pet>(petDto);
            pet.AppointmentIds = null;

            int id = await repo.CreatePetAsync(pet);
            Pet pet1 = await repo.GetPetByIdAsync(id);

            Mapper mapper1 = new Mapper(config2);
            UpdatePetDto petDto1 = mapper1.Map<UpdatePetDto>(pet1);
            return petDto1;

        }


        public async Task<UpdatePetDto> EditPetAsync(UpdatePetDto petDto)
        {
            Mapper mapper = new Mapper(config1);
            Pet pet = mapper.Map<Pet>(petDto);
            Pet p = await repo.EditPetAsync(pet);

            Mapper mapper1 = new Mapper(config2);
            UpdatePetDto changedPetDto = mapper1.Map<UpdatePetDto>(p);

            return changedPetDto;


        }

        public async Task<bool> DeletePetAsync(int id)
        {
            repo.DeletePet(id);
            if (await repo.GetPetByIdAsync(id) == null)
                return true;
            return false;
        }

        public async Task<UpdatePetDto> GetPetByIdAsync(int id)
        {
            Pet pet = await repo.GetPetByIdAsync(id);
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