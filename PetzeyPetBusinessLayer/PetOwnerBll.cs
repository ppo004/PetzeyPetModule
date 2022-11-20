using AutoMapper;
using PetzeyPetBusinessLayer.Validators;
using PetzeyPetDataAccessLayer.PetOwnerRepository;
using PetzeyPetDTOs;
using PetzeyPetEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using PetzeyPetExceptions;
namespace PetzeyPetBusinessLayer
{
    public class PetOwnerBll:IPetOwnerBll
    {
        readonly IPetOwnerRepository repo;
        readonly ValidatorFactory validators;
        public PetOwnerBll()
        {
            repo = new PetOwnerRepository();
            validators = ValidatorFactory.GetInstance();
        }
        public PetOwnerBll(IPetOwnerRepository repo)
        {
            this.repo = repo;
            validators = ValidatorFactory.GetInstance();
        }

        readonly MapperConfiguration addOwnerConfig = new MapperConfiguration(cfg =>

                   cfg.CreateMap<AddOwnerDto, PetOwner>().ForMember(dest => dest.PetOwnerId, act => act.Ignore())

               );
        readonly MapperConfiguration editOwnerConfig = new MapperConfiguration(cfg =>

                 cfg.CreateMap<OwnerDto, PetOwner>()

             );
        readonly MapperConfiguration editOwnerConfig2 = new MapperConfiguration(cfg =>

                 cfg.CreateMap<PetOwner, OwnerDto>()

             );
        readonly MapperConfiguration config1 = new MapperConfiguration(cfg =>

                 cfg.CreateMap<Pet, UpdatePetDto>()

             );

       


        public OwnerDto CreateOwner(AddOwnerDto ownerDto)
        {
            Mapper mapper = new Mapper(addOwnerConfig);
            try
            {
                PetOwner owner = mapper.Map<PetOwner>(ownerDto);
                if (owner.OwnerEmail == null || owner.OwnerPhone == null || owner.OwnerName == null || owner.OwnerLocation == null) throw new EmptyFieldException();
                if (!validators.Validator["email"].Validate(owner.OwnerEmail)) throw new IncorrectEmailFormatException();
                if (!validators.Validator["phone"].Validate(owner.OwnerPhone)) throw new IncorrectPhoneNoFormatException();
                if (!validators.Validator["image"].Validate(owner.ImageUrl)) throw new IncorrectURLFormatException();
                //if (!validators.Validator["location"].Validate(owner.OwnerLocation)) throw new IncorrectLocationFormat();
                PetOwner owner1 = repo.CreateOwner(owner);
                Mapper mapper1 = new Mapper(editOwnerConfig2);
                OwnerDto ownerDto1 = mapper1.Map<OwnerDto>(owner1);
                return ownerDto1;
            }
            catch(DbUpdateException e) { throw e;} 
        }
        public async Task<OwnerDto> CreateOwnerAsync(AddOwnerDto ownerDto)
        {
            try
            {
                Mapper mapper = new Mapper(addOwnerConfig);
                PetOwner owner = mapper.Map<PetOwner>(ownerDto);
                if (owner.OwnerEmail==null || owner.OwnerPhone == null || owner.OwnerName == null || owner.OwnerLocation == null) throw new EmptyFieldException();
                if (!validators.Validator["email"].Validate(owner.OwnerEmail)) throw new IncorrectEmailFormatException();
                if (!validators.Validator["phone"].Validate(owner.OwnerPhone)) throw new IncorrectPhoneNoFormatException();
                if (!validators.Validator["image"].Validate(owner.ImageUrl)) throw new IncorrectURLFormatException();
                if (!validators.Validator["location"].Validate(owner.OwnerLocation)) throw new IncorrectLocationFormat();
                PetOwner owner1 = await repo.CreateOwnerAsync(owner);
                Mapper mapper1 = new Mapper(editOwnerConfig2);
                OwnerDto ownerDto1 = mapper1.Map<OwnerDto>(owner1);
                return ownerDto1;
            }
            catch (DbUpdateException e) { throw e; }

        }

        public OwnerDto EditOwner(OwnerDto ownerDto)
        {
            Mapper mapper = new Mapper(editOwnerConfig);
            try
            {
                PetOwner owner = mapper.Map<PetOwner>(ownerDto);
                if (owner.OwnerEmail == null || owner.OwnerPhone == null || owner.OwnerName == null || owner.OwnerLocation == null) throw new EmptyFieldException();
                if (!validators.Validator["email"].Validate(owner.OwnerEmail)) throw new IncorrectEmailFormatException();
                if (!validators.Validator["phone"].Validate(owner.OwnerPhone)) throw new IncorrectPhoneNoFormatException();
                if (!validators.Validator["image"].Validate(owner.ImageUrl)) throw new IncorrectURLFormatException();
                if (!validators.Validator["location"].Validate(owner.OwnerLocation)) throw new IncorrectLocationFormat();
                PetOwner po = repo.EditOwner(owner);
                Mapper mapper1 = new Mapper(editOwnerConfig2);
                OwnerDto changedOwnerDto = mapper1.Map<OwnerDto>(po);
                return changedOwnerDto;
            }
            catch (DbUpdateException e) { throw e; }
        }
        public async Task<OwnerDto> EditOwnerAsync(OwnerDto ownerDto)
        {
            try
            {
                Mapper mapper = new Mapper(editOwnerConfig);
                PetOwner owner = mapper.Map<PetOwner>(ownerDto);
                if (owner.OwnerEmail == null || owner.OwnerPhone == null || owner.OwnerName == null || owner.OwnerLocation == null) throw new EmptyFieldException();
                if (!validators.Validator["email"].Validate(owner.OwnerEmail)) throw new IncorrectEmailFormatException();
                if (!validators.Validator["phone"].Validate(owner.OwnerPhone)) throw new IncorrectPhoneNoFormatException();
                if (!validators.Validator["image"].Validate(owner.ImageUrl)) throw new IncorrectURLFormatException();
                if (!validators.Validator["location"].Validate(owner.OwnerLocation)) throw new IncorrectLocationFormat();
                PetOwner po = await repo.EditOwnerAsync(owner);
                Mapper mapper1 = new Mapper(editOwnerConfig2);
                OwnerDto changedOwnerDto = mapper1.Map<OwnerDto>(po);
                return changedOwnerDto;
            }
            catch (DbUpdateException e) { throw e; }
        }

        public OwnerDto GetOwnerById(int id)
        {
            PetOwner owner = repo.getOwnerById(id);
            Mapper mapper1 = new Mapper(editOwnerConfig2);
            OwnerDto ownerDto = mapper1.Map<OwnerDto>(owner);
            if (ownerDto == null) throw new OwnerDoesntExistException();
            return ownerDto;
            
        }
        public async Task<OwnerDto> GetOwnerByIdAsync(int id)
        {
            
            PetOwner owner = await repo.getOwnerByIdAsync(id);
            Mapper mapper1 = new Mapper(editOwnerConfig2);
            OwnerDto ownerDto = mapper1.Map<OwnerDto>(owner);
            if (ownerDto == null) throw new OwnerDoesntExistException();
            return ownerDto;
        }

        public PetOwner AddOwnerProfilePic(AddProfilePicDto dto)
        {
            try
            {
                if (!validators.Validator["image"].Validate(dto.imageUrl)) throw new IncorrectURLFormatException();
                repo.AddProfilePic(dto.OwnerId, dto.imageUrl);
                return repo.getOwnerById(dto.OwnerId);
            }
            catch(OwnerDoesntExistException e) { throw e; } 
        }
        public async Task<PetOwner> AddOwnerProfilePicAsync(AddProfilePicDto dto)
        {
            try
            {
                if (!validators.Validator["image"].Validate(dto.imageUrl)) throw new IncorrectURLFormatException();
                await repo.AddProfilePicAsync(dto.OwnerId, dto.imageUrl);
                return await repo.getOwnerByIdAsync(dto.OwnerId);
            }
            catch (OwnerDoesntExistException e) { throw e; }
        }

        public List<OwnerDto> GetAllOwners()
        {
            Mapper mapper1 = new Mapper(editOwnerConfig2);
            List<OwnerDto> petOwnerDto = new List<OwnerDto>();
            foreach (PetOwner petOwner in repo.GetAllOwners())
                petOwnerDto.Add(mapper1.Map<OwnerDto>(petOwner));
            return petOwnerDto;
        }

        public PetOwner DeleteOwnerProfilePic(int id)
        {
            try
            {
                PetOwner owner =  repo.DeleteProfilePic(id);
                return owner;
            }
            catch (OwnerDoesntExistException e) { throw e; }
        }
        
        public async Task<PetOwner> DeleteOwnerProfilePicAsync(int id)
        {
            try
            {
                await repo.DeleteProfilePicAsync(id);
                return await repo.getOwnerByIdAsync(id);
            }
            catch (OwnerDoesntExistException e) { throw e; }
        }

        public List<UpdatePetDto> GetPetsOfOwner(int ownerId)
        {
            
            PetOwner owner = repo.getOwnerById(ownerId);
            if (owner == null)
                throw new OwnerDoesntExistException();
            Mapper mapper = new Mapper(config1);
            List<Pet> pets = repo.getPetsOfOwner(ownerId);
            List<UpdatePetDto> petDtos = new List<UpdatePetDto>();
            foreach (var pet in pets)
                petDtos.Add(mapper.Map<UpdatePetDto>(pet));
            return petDtos;

            
        }

        public async Task<List<UpdatePetDto>> GetPetsOfOwnerAsync(int ownerId)
        {
            
            PetOwner owner =await repo.getOwnerByIdAsync(ownerId);
            if (owner == null)
                throw new OwnerDoesntExistException();
            Mapper mapper = new Mapper(config1);
            List<Pet> pets =await repo.getPetsOfOwnerAsync(ownerId);
            List<UpdatePetDto> petDtos = mapper.Map<List<UpdatePetDto>>(pets);
            return petDtos;

            
        }

       
    }
}

