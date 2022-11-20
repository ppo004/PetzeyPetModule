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
        readonly IPetDbRepository repo;
        readonly IPetOwnerBll ownerBll;
        readonly ValidatorFactory validators;
        public PetBll()
        {
            validators = ValidatorFactory.GetInstance();
            this.repo = new PetDbRepository();
            this.ownerBll = new PetOwnerBll();
            this.validators = ValidatorFactory.GetInstance();
        }
        public PetBll(IPetDbRepository repo, IPetOwnerBll ownerBll) { 
            this.repo = repo;
            this.ownerBll = ownerBll;
            this.validators = ValidatorFactory.GetInstance();
        }

        readonly MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<AddPetDto, Pet>().ForMember(dest => dest.AppointmentIds, act => act.Ignore()));
        readonly MapperConfiguration config1 = new MapperConfiguration(cfg =>cfg.CreateMap<UpdatePetDto, Pet>());
        readonly MapperConfiguration config2 = new MapperConfiguration(cfg =>cfg.CreateMap<Pet, UpdatePetDto>());
        readonly MapperConfiguration config3 = new MapperConfiguration(cfg =>cfg.CreateMap<UpdatePetDto, AddPetDto>());

        public void BusinessRules(AddPetDto petDto)
        {
            OwnerDto owner = ownerBll.GetOwnerById(petDto.OwnerId);
            if (owner == null) throw new OwnerDoesntExistException();
            if (petDto.Name.Length == 0 || petDto.BloodGroup.Length == 0) throw new EmptyFieldException();
            if (!validators.Validator["bloodgroup"].Validate(petDto.BloodGroup)) throw new IncorrectBloodGroupFormatException();
            if (!validators.Validator["image"].Validate(petDto.ImageUrl)) throw new IncorrectURLFormatException();

        }

        public Pet DoesPetExist(int id)
        {
            Pet pet = repo.GetPetById(id);
            if (pet == null) throw new PetDoesntExistException();
            return pet;
        }
        public async Task<Pet> DoesPetExistAsync(int id)
        {
            Pet pet = await repo.GetPetByIdAsync(id);
            if (pet == null) throw new PetDoesntExistException();
            return pet;
        }

        public int AddAppointmentsToPet(PetAppDto petAppdto)
        {
            try {
                int id = repo.AddAppointmentId(petAppdto.petId, petAppdto.AppointmentId);
                PetAndAppointments appointment = repo.GetPetandAppById(id);
                if (appointment == null) throw new PetDoesntExistException();// change exception
                return appointment.PetAppId;
            }
            catch (PetDoesntExistException e) { throw e; }
            catch(Exception e) { throw e; }
        }


        public UpdatePetDto CreatePet(AddPetDto petDto)
        {
            Mapper mapper = new Mapper(config);

            try
            {
                Pet pet = mapper.Map<Pet>(petDto);
                BusinessRules(petDto);
                List<UpdatePetDto> pets = ownerBll.GetPetsOfOwner(petDto.OwnerId);
                int count = pets.Where(p => p.Name == petDto.Name).Count();
                if (count > 0) throw new SameOwnerSameNameException();
                int id = repo.CreatePet(pet);
                Pet pet1 = DoesPetExist(id);
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
            catch (PetDoesntExistException e) { throw e; }
            catch (Exception e) { throw e; }
        }


        public UpdatePetDto EditPet(UpdatePetDto petDto)
        {
            Mapper mapper = new Mapper(config1);
            Mapper mapper1 = new Mapper(config3);
            AddPetDto addPetDto = mapper1.Map<AddPetDto>(petDto);   
            try
            {
                BusinessRules(addPetDto);
                Pet pet = mapper.Map<Pet>(petDto);
                Pet p = repo.EditPet(pet);
                Mapper mapper2 = new Mapper(config2);
                UpdatePetDto changedPetDto = mapper2.Map<UpdatePetDto>(p);
                return changedPetDto;
            }
            catch (EmptyFieldException e) { throw e; }
            catch (IncorrectBloodGroupFormatException e) { throw e; }
            catch (IncorrectDOBFormatException e) { throw e; }
            catch (IncorrectURLFormatException e) { throw e; }
            catch (OwnerDoesntExistException e) { throw e; }
            catch (RepeatedAllergyException e) { throw e; } //TBD
            catch (SameOwnerSameNameException e) { throw e; }
            catch (PetDoesntExistException e) { throw e; }
            catch (Exception e) { throw e; }
        }

        public bool DeletePet(int id)
        {
            try
            {
                return repo.DeletePet(id);
                
            }
            catch (PetDoesntExistException e) { throw e; }
            catch (Exception e) { throw e; }
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
            catch (Exception e) { throw e; }
        }

        /// <summary>
        /// Async BLL Functions
        /// </summary>


        public async Task<bool> AddAppointmentsToPetAsync(PetAppDto petAppdto)
        {
            try
            {
                int id = await repo.AddAppointmentIdAsyc(petAppdto.petId, petAppdto.AppointmentId);
                PetAndAppointments appointment = repo.GetPetandAppById(id);
                if (appointment == null)
                    return false;
                return true;
            }
            catch (PetDoesntExistException e) { throw e; }
            catch (Exception e) { throw e; }

        }
        public async Task<UpdatePetDto> CreatePetAsync(AddPetDto petDto)
        {
            try
            {
                Mapper mapper = new Mapper(config);
                Pet pet = mapper.Map<Pet>(petDto);
                BusinessRules(petDto);
                int id =await repo.CreatePetAsync(pet);
                Pet pet1 = await DoesPetExistAsync(id);
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
            catch (PetDoesntExistException e) { throw e; }
            catch (Exception e) { throw e; }

        }


        public async Task<UpdatePetDto> EditPetAsync(UpdatePetDto petDto)
        {

            Mapper mapper = new Mapper(config1);
            Mapper mapper1 = new Mapper(config3);
            AddPetDto addPetDto = mapper1.Map<AddPetDto>(petDto);
            try
            {
                BusinessRules(addPetDto);
                Pet pet = mapper.Map<Pet>(petDto);
                Pet p =await repo.EditPetAsync(pet);
                Mapper mapper2 = new Mapper(config2);
                UpdatePetDto changedPetDto = mapper2.Map<UpdatePetDto>(p);
                return changedPetDto;
            }
            catch (EmptyFieldException e) { throw e; }
            catch (IncorrectBloodGroupFormatException e) { throw e; }
            catch (IncorrectDOBFormatException e) { throw e; }
            catch (IncorrectURLFormatException e) { throw e; }
            catch (OwnerDoesntExistException e) { throw e; }
            catch (RepeatedAllergyException e) { throw e; } //TBD
            catch (SameOwnerSameNameException e) { throw e; }
            catch (PetDoesntExistException e) { throw e; }
            catch (Exception e) { throw e; }


        }

        public async Task<bool> DeletePetAsync(int id)
        {
            try
            {
                return await repo.DeletePetAsync(id);

            }
            catch (PetDoesntExistException e) { throw e; }
            catch (Exception e) { throw e; }
        }

        public async Task<UpdatePetDto> GetPetByIdAsync(int id)
        {
            try
            {
                Pet pet = await DoesPetExistAsync(id);
                Mapper mapper1 = new Mapper(config2);
                UpdatePetDto petDto = mapper1.Map<UpdatePetDto>(pet);
                return petDto;
            }
            catch (PetDoesntExistException e) { throw e; }
            catch (Exception e) { throw e; }
        }
    

        //Add exception

        public List<UpdatePetDto> GetAllPets()
        {
            Mapper mapper1 = new Mapper(config2);
            List<UpdatePetDto> petDto = new List<UpdatePetDto>();
            foreach (Pet pets in repo.GetAllPets())
                petDto.Add(mapper1.Map<UpdatePetDto>(pets));
            return petDto;
        }

        public Task<List<UpdatePetDto>> GetAllPetsAsync()
        {
            throw new NotImplementedException();
        }
    }
}