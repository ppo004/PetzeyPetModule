using AutoMapper;
using PetzeyPetDataAccessLayer.PetOwnerRepository;
using PetzeyPetDTOs;
using PetzeyPetEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetBusinessLayer
{
    public class PetOwnerBll
    {
        IPetOwnerRepository repo = new PetOwnerRepository();
        MapperConfiguration addOwnerConfig = new MapperConfiguration(cfg =>

                   cfg.CreateMap<AddOwnerDto, PetOwner>().ForMember(dest => dest.PetOwnerId, act => act.Ignore())

               );
        MapperConfiguration editOwnerConfig = new MapperConfiguration(cfg =>

                 cfg.CreateMap<EditOwnerDto, PetOwner>()

             );
        MapperConfiguration editOwnerConfig2 = new MapperConfiguration(cfg =>

                 cfg.CreateMap<PetOwner, EditOwnerDto>()

             );

       


        public EditOwnerDto CreateOwner(AddOwnerDto ownerDto)
        {
            Mapper mapper = new Mapper(addOwnerConfig);
            PetOwner owner = mapper.Map<PetOwner>(ownerDto);


            int id = repo.CreateOwner(owner);

            PetOwner owner1 = repo.getOwnerById(id);

            Mapper mapper1 = new Mapper(editOwnerConfig2);
            EditOwnerDto ownerDto1 = mapper1.Map<EditOwnerDto>(owner1);
            return ownerDto1;

        }

        public EditOwnerDto EditOwner(EditOwnerDto ownerDto)
        {
            Mapper mapper = new Mapper(editOwnerConfig);
            PetOwner owner = mapper.Map<PetOwner>(ownerDto);
            PetOwner po = repo.EditOwner(owner);

            Mapper mapper1 = new Mapper(editOwnerConfig2);
            EditOwnerDto changedOwnerDto = mapper1.Map<EditOwnerDto>(po);

            return changedOwnerDto;


        }

        public EditOwnerDto GetOwnerById(int id)
        {
            PetOwner owner = repo.getOwnerById(id);
            Mapper mapper1 = new Mapper(editOwnerConfig2);
            EditOwnerDto ownerDto = mapper1.Map<EditOwnerDto>(owner);
            if (ownerDto == null)
                return null;
            return ownerDto;
        }

        public PetOwner AddOwnerProfilePic(AddProfilePicDto dto)
        {
            repo.AddProfilePic(dto.OwnerId, dto.imageUrl);

            return repo.getOwnerById(dto.OwnerId);
        }

        public List<EditOwnerDto> GetAllOwners()
        {
            Mapper mapper1 = new Mapper(editOwnerConfig2);
            List<EditOwnerDto> petOwnerDto = new List<EditOwnerDto>();
            foreach (PetOwner petOwner in repo.GetAllOwners())
                petOwnerDto.Add(mapper1.Map<EditOwnerDto>(petOwner));
            return petOwnerDto;
        }

        public PetOwner deleteOwnerProfilePic(int id)
        {
            repo.DeleteProfilePic(id);

            return repo.getOwnerById(id);
        }
    }
}
