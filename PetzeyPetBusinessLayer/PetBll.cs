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

namespace PetzeyPetBusinessLayer
{

    public class PetBll
    {
        IPetDbRepository repo = new PetDbRepository();
        PetOwnerBll ownerBll = new PetOwnerBll();

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
        /// 

        public void BusinessRules(AddPetDto petDto)
        {
            EditOwnerDto owner = ownerBll.GetOwnerById(petDto.OwnerId);
            if (owner == null)
                throw new OwnerDoesntExistException();
            List<UpdatePetDto> petDtos = (List<UpdatePetDto>)ownerBll.GetPets(petDto.OwnerId)
                                         .ToList().Where(pet=>pet.Name == petDto.Name);
            if (petDtos.Count() > 0)
                throw new SameOwnerSameNameException();
            
        }



        public bool AddAppointmentsToPet(PetAppDto petAppdto)
        {
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
                BusinessRules(petDto);

                int id = repo.CreatePet(pet);
                Pet pet1 = repo.GetPetById(id);
                if (pet1 == null)
                    throw new PetDoesntExistException();

                Mapper mapper1 = new Mapper(config2);
                UpdatePetDto petDto1 = mapper1.Map<UpdatePetDto>(pet1);
                return petDto1;
            }
            catch (EmptyFieldException e) { throw e; }
            catch (IncorrectAgeFormatException e) { throw e; }
            catch (IncorrectBloodGroupFormatException e) { throw e; }
            catch (IncorrectDOBFormatException e) { throw e; }
            catch (IncorrectURLFormatException e) { throw e; }
            catch (OwnerDoesntExistException e) { throw e; }
            catch (SameOwnerSameNameException e) { throw e; }

        }


        public UpdatePetDto EditPet(UpdatePetDto petDto)
        {

            Mapper mapper = new Mapper(config1);
            try
            {
                BusinessRules(petDto);
                Pet pet = mapper.Map<Pet>(petDto);
                if (repo.GetPetById(petDto.PetId) == null)
                    throw new PetDoesntExistException();
                Pet p = repo.EditPet(pet);

                Mapper mapper1 = new Mapper(config2);
                UpdatePetDto changedPetDto = mapper1.Map<UpdatePetDto>(p);

                return changedPetDto;
            }
            catch (EmptyFieldException e) { throw e; }
            catch (IncorrectAgeFormatException e) { throw e; }
            catch (IncorrectBloodGroupFormatException e) { throw e; }
            catch (IncorrectDOBFormatException e) { throw e; }
            catch (IncorrectURLFormatException e) { throw e; }
            catch (OwnerDoesntExistException e) { throw e; }
            catch (SameOwnerSameNameException e) { throw e; }
            catch (PetDoesntExistException e) { throw e; }

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


        public async Task<bool> AddAppointmentsToPetAsync(PetAppDto petAppdto)
        {
            int id = await repo.AddAppointmentIdAsyc(petAppdto.petId, petAppdto.AppointmentId);
            PetAndAppointments appointment = await repo.GetPetandAppByIdAsync(id);
            if (appointment == null)
                return false;
            return true;

        }
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
            try
            {
                Pet pet = await repo.GetPetByIdAsync(id);
                Mapper mapper1 = new Mapper(config2);
                UpdatePetDto petDto = mapper1.Map<UpdatePetDto>(pet);
                if (petDto == null)
                    throw new PetDoesntExistException();
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