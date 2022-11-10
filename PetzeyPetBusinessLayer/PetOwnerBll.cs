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
        IPetOwnerRepository repo;
        Validator validator;
        public PetOwnerBll()
        {
            repo = new PetOwnerRepository();
            validator = new Validator();
        }
        MapperConfiguration addOwnerConfig = new MapperConfiguration(cfg =>

                   cfg.CreateMap<AddOwnerDto, PetOwner>().ForMember(dest => dest.PetOwnerId, act => act.Ignore())

               );
        MapperConfiguration editOwnerConfig = new MapperConfiguration(cfg =>

                 cfg.CreateMap<OwnerDto, PetOwner>()

             );
        MapperConfiguration editOwnerConfig2 = new MapperConfiguration(cfg =>

                 cfg.CreateMap<PetOwner, OwnerDto>()

             );
        MapperConfiguration config1 = new MapperConfiguration(cfg =>

                 cfg.CreateMap<List<UpdatePetDto>, List<Pet>>()

             );

       


        public OwnerDto CreateOwner(AddOwnerDto ownerDto)
        {
            Mapper mapper = new Mapper(addOwnerConfig);
            try
            {
                PetOwner owner = mapper.Map<PetOwner>(ownerDto);
                if (!validator.EmailValidator(owner.OwnerEmail)) throw new IncorrectEmailFormatException();
                if (!validator.PhoneNumberValidator(owner.OwnerPhone)) throw new IncorrectPhoneNoFormatException();
                PetOwner owner1 = repo.CreateOwner(owner);
                Mapper mapper1 = new Mapper(editOwnerConfig2);
                OwnerDto ownerDto1 = mapper1.Map<OwnerDto>(owner1);
                return ownerDto1;
            }
            catch(DbUpdateException e) { throw e;}
            catch(IncorrectPhoneNoFormatException e) { throw e; }
            catch(IncorrectEmailFormatException e) { throw e; }
        }
        public async Task<OwnerDto> CreateOwnerAsync(AddOwnerDto ownerDto)
        {
            try
            {
                Mapper mapper = new Mapper(addOwnerConfig);
                PetOwner owner = mapper.Map<PetOwner>(ownerDto);
                if (!validator.EmailValidator(owner.OwnerEmail)) throw new IncorrectEmailFormatException();
                if (!validator.PhoneNumberValidator(owner.OwnerPhone)) throw new IncorrectPhoneNoFormatException();
                PetOwner owner1 = await repo.CreateOwnerAsync(owner);
                Mapper mapper1 = new Mapper(editOwnerConfig2);
                OwnerDto ownerDto1 = mapper1.Map<OwnerDto>(owner1);
                return ownerDto1;
            }
            catch (DbUpdateException e) { throw e; }
            catch (IncorrectPhoneNoFormatException e) { throw e; }
            catch (IncorrectEmailFormatException e) { throw e; }
        }

        public OwnerDto EditOwner(OwnerDto ownerDto)
        {
            Mapper mapper = new Mapper(editOwnerConfig);
            try
            {
                PetOwner owner = mapper.Map<PetOwner>(ownerDto);
                if (!validator.EmailValidator(owner.OwnerEmail)) throw new IncorrectEmailFormatException();
                if (!validator.PhoneNumberValidator(owner.OwnerPhone)) throw new IncorrectPhoneNoFormatException();
                PetOwner po = repo.EditOwner(owner);
                Mapper mapper1 = new Mapper(editOwnerConfig2);
                OwnerDto changedOwnerDto = mapper1.Map<OwnerDto>(po);
                return changedOwnerDto;
            }
            catch (DbUpdateException e) { throw e; }
            catch (IncorrectPhoneNoFormatException e) { throw e; }
            catch (IncorrectEmailFormatException e) { throw e; }
        }
        public async Task<OwnerDto> EditOwnerAsync(OwnerDto ownerDto)
        {
            try
            {
                Mapper mapper = new Mapper(editOwnerConfig);
                PetOwner owner = mapper.Map<PetOwner>(ownerDto);
                if (!validator.EmailValidator(owner.OwnerEmail)) throw new IncorrectEmailFormatException();
                if (!validator.PhoneNumberValidator(owner.OwnerPhone)) throw new IncorrectPhoneNoFormatException();
                PetOwner po = await repo.EditOwnerAsync(owner);
                Mapper mapper1 = new Mapper(editOwnerConfig2);
                OwnerDto changedOwnerDto = mapper1.Map<OwnerDto>(po);
                return changedOwnerDto;
            }
            catch (DbUpdateException e) { throw e; }
            catch (IncorrectPhoneNoFormatException e) { throw e; }
            catch (IncorrectEmailFormatException e) { throw e; }
        }

        public OwnerDto GetOwnerById(int id)
        {
            try
            {
                PetOwner owner = repo.getOwnerById(id);
                Mapper mapper1 = new Mapper(editOwnerConfig2);
                OwnerDto ownerDto = mapper1.Map<OwnerDto>(owner);
                if (ownerDto == null) throw new OwnerDoesntExistException();
                return ownerDto;
            }
            catch(OwnerDoesntExistException e) { throw e;}
        }
        public async Task<OwnerDto> GetOwnerByIdAsync(int id)
        {
            try
            {
                PetOwner owner = await repo.getOwnerByIdAsync(id);
                Mapper mapper1 = new Mapper(editOwnerConfig2);
                OwnerDto ownerDto = mapper1.Map<OwnerDto>(owner);
                if (ownerDto == null) throw new OwnerDoesntExistException();
                return ownerDto;
            }
            catch (OwnerDoesntExistException e) { throw e; }
        }

        public PetOwner AddOwnerProfilePic(AddProfilePicDto dto)
        {
            try
            {
                if (!validator.ImageUrlValidator(dto.imageUrl)) throw new IncorrectURLFormatException();
                repo.AddProfilePic(dto.OwnerId, dto.imageUrl);
                return repo.getOwnerById(dto.OwnerId);
            }
            catch(IncorrectURLFormatException e) { throw e; }
            catch(OwnerDoesntExistException e) { throw e; } 
        }
        public async Task<PetOwner> AddOwnerProfilePicAsync(AddProfilePicDto dto)
        {
            try
            {
                if (!validator.ImageUrlValidator(dto.imageUrl)) throw new IncorrectURLFormatException();
                await repo.AddProfilePicAsync(dto.OwnerId, dto.imageUrl);
                return await repo.getOwnerByIdAsync(dto.OwnerId);
            }
            catch (IncorrectURLFormatException e) { throw e; }
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
                repo.DeleteProfilePic(id);
                return repo.getOwnerById(id);
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

        public List<UpdatePetDto> GetPets(int id)
        {
            Mapper mapper = new Mapper(config1);
            List<Pet> pets = repo.getPets(id);
                List<UpdatePetDto> petDtos = mapper.Map<List<UpdatePetDto>>(pets);

            return petDtos;
        }

    }
}

