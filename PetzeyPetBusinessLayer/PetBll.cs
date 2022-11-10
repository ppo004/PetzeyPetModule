using AutoMapper;
using PetzeyPetDataAccessLayer;
using PetzeyPetDTOs;
using PetzeyPetEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetzeyPetExceptions;
using System.Text.RegularExpressions;
using PetzeyPetBusinessLayer.Validators;

namespace PetzeyPetBusinessLayer
{

    public class PetBll:IPetBll
    {
        IPetDbRepository repo;
        Validator validator;
        public PetBll()
        {
            this.repo = new PetDbRepository();
        }

        MapperConfiguration config = new MapperConfiguration(cfg =>

                  cfg.CreateMap<AddPetDto, Pet>().ForMember(dest => dest.AppointmentIds, act => act.Ignore())

              );
        MapperConfiguration config1 = new MapperConfiguration(cfg =>

                 cfg.CreateMap<UpdatePetDto, Pet>()

             );
        MapperConfiguration config2 = new MapperConfiguration(cfg =>

                 cfg.CreateMap<Pet, UpdatePetDto>()

             );
        public bool AddAppointmentsToPet(PetAppDto petAppdto)
        {  //Add logic for checking that if pet exists
            int id = repo.AddAppointmentId(petAppdto.petId, petAppdto.AppointmentId);
            PetAndAppointments appointment = repo.GetPetandAppById(id);
            if (appointment == null)
                return false;
            return true;

        }
        public UpdatePetDto CreatePet(AddPetDto petDto)
        {
            Mapper mapper = new Mapper(config);
            try
            {
                Pet pet = mapper.Map<Pet>(petDto);

                if (pet.Name.Length == 0 || pet.BloodGroup.Length == 0) throw new EmptyFieldException();
                //Make changes later by converting the above exception from general to specific for every field.
                if (!validator.DOBValidator(pet.DOB.ToString())) throw new IncorrectDOBFormatException();
                if (!validator.BloodGroupValidator(pet.BloodGroup)) throw new IncorrectBloodGroupFormatException();
                if (!validator.ImageUrlValidator(pet.ImageUrl)) throw new IncorrectURLFormatException();
                int id = repo.CreatePet(pet);
                Pet pet1 = repo.GetPetById(id);

                Mapper mapper1 = new Mapper(config2);
                UpdatePetDto petDto1 = mapper1.Map<UpdatePetDto>(pet1);
                return petDto1;
            }
            catch (EmptyFieldException e) { throw e; }
            catch (IncorrectBloodGroupFormatException e) { throw e; }
            catch (IncorrectDOBFormatException e) { throw e; }
            catch (IncorrectURLFormatException e) { throw e; }

            catch (OwnerDoesntExistException e) { throw e; }
            catch (RepeatedAllergyException e) { throw e; } //TBD
            catch (SameOwnerSameNameException e) { throw e; }
        }
        public async Task<UpdatePetDto> CreatePetAsync(AddPetDto petDto)
        {
            Mapper mapper = new Mapper(config);
            try
            {
                Pet pet = mapper.Map<Pet>(petDto);
                if (pet.Name.Length == 0 || pet.BloodGroup.Length == 0) throw new EmptyFieldException();
                //Make changes later by converting the above exception from general to specific for every field.
                if (!validator.DOBValidator(pet.DOB.ToString())) throw new IncorrectDOBFormatException();
                if (!validator.BloodGroupValidator(pet.BloodGroup)) throw new IncorrectBloodGroupFormatException();
                if (!validator.ImageUrlValidator(pet.ImageUrl)) throw new IncorrectURLFormatException();

                pet.AppointmentIds = null;

                int id = await repo.CreatePetAsync(pet);
                Pet pet1 = await repo.GetPetByIdAsync(id);

                Mapper mapper1 = new Mapper(config2);
                UpdatePetDto petDto1 = mapper1.Map<UpdatePetDto>(pet1);
                return petDto1;
            }
            catch (EmptyFieldException e) { throw e; }
            catch (IncorrectBloodGroupFormatException e) { throw e; }
            catch (IncorrectDOBFormatException e) { throw e; }
            catch (IncorrectURLFormatException e) { throw e; }

            catch (OwnerDoesntExistException e) { throw e; }
            catch (RepeatedAllergyException e) { throw e; }
            catch (SameOwnerSameNameException e) { throw e; }
            //TBD
        }
        public UpdatePetDto EditPet(UpdatePetDto petDto)
        {
            Mapper mapper = new Mapper(config1);
            try
            {
                Pet pet = mapper.Map<Pet>(petDto);

                if (pet.Name.Length == 0 || pet.BloodGroup.Length == 0) throw new EmptyFieldException();
                //Make changes later by converting the above exception from general to specific for every field.
                if (!validator.DOBValidator(pet.DOB.ToString())) throw new IncorrectDOBFormatException();
                if (!validator.BloodGroupValidator(pet.BloodGroup)) throw new IncorrectBloodGroupFormatException();
                if (!validator.ImageUrlValidator(pet.ImageUrl)) throw new IncorrectURLFormatException();
                Pet p = repo.EditPet(pet);

                Mapper mapper1 = new Mapper(config2);
                UpdatePetDto changedPetDto = mapper1.Map<UpdatePetDto>(p);

                return changedPetDto;
            }
            catch (EmptyFieldException e) { throw e; }
            catch (IncorrectBloodGroupFormatException e) { throw e; }
            catch (IncorrectDOBFormatException e) { throw e; }
            catch (IncorrectURLFormatException e) { throw e; }

            catch (OwnerDoesntExistException e) { throw e; }
            catch (RepeatedAllergyException e) { throw e; }
            catch (SameOwnerSameNameException e) { throw e; }
            //TBD

        }
        public async Task<UpdatePetDto> EditPetAsync(UpdatePetDto petDto)
        {
            Mapper mapper = new Mapper(config1);
            try
            {
                Pet pet = mapper.Map<Pet>(petDto);

                if (pet.Name.Length == 0 || pet.BloodGroup.Length == 0) throw new EmptyFieldException();
                //Make changes later by converting the above exception from general to specific for every field.
                if (!validator.DOBValidator(pet.DOB.ToString())) throw new IncorrectDOBFormatException();
                if (!validator.BloodGroupValidator(pet.BloodGroup)) throw new IncorrectBloodGroupFormatException();
                if (!validator.ImageUrlValidator(pet.ImageUrl)) throw new IncorrectURLFormatException();

                Pet p = await repo.EditPetAsync(pet);

                Mapper mapper1 = new Mapper(config2);
                UpdatePetDto changedPetDto = mapper1.Map<UpdatePetDto>(p);

                return changedPetDto;
            }
            catch (EmptyFieldException e) { throw e; }
            catch (IncorrectBloodGroupFormatException e) { throw e; }
            catch (IncorrectDOBFormatException e) { throw e; }
            catch (IncorrectURLFormatException e) { throw e; }

            catch (OwnerDoesntExistException e) { throw e; }
            catch (RepeatedAllergyException e) { throw e; }
            catch (SameOwnerSameNameException e) { throw e; }
            //TBD
        }

        public bool DeletePet(int id)
        {
            try
            {
                repo.DeletePet(id);
                if (repo.GetPetById(id) == null)
                    return true;
                throw new PetDoesntExistException();
            }
            catch (PetDoesntExistException e) { throw e; }

        }
        public async Task<bool> DeletePetAsync(int id)
        {
            repo.DeletePet(id);
            if (await repo.GetPetByIdAsync(id) == null)
                return true;
            throw new PetDoesntExistException();
        }

        public UpdatePetDto GetPetById(int id)
        {
            try
            {
                Pet pet = repo.GetPetById(id);
                if (pet == null)
                    throw new PetDoesntExistException();
                Mapper mapper1 = new Mapper(config2);
                UpdatePetDto petDto = mapper1.Map<UpdatePetDto>(pet);
                return petDto;
            }

            catch (PetDoesntExistException e) { throw e; }
        }

        public async Task<UpdatePetDto> GetPetByIdAsync(int id)
        {
            try
            {
                Pet pet = await repo.GetPetByIdAsync(id);
                if (pet == null)
                    throw new PetDoesntExistException();
                Mapper mapper1 = new Mapper(config2);
                UpdatePetDto petDto = mapper1.Map<UpdatePetDto>(pet);
                return petDto;
            }
            catch (PetDoesntExistException e) { throw e; }
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