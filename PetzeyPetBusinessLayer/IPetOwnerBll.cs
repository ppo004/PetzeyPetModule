using PetzeyPetDTOs;
using PetzeyPetEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetBusinessLayer
{
    public interface IPetOwnerBll
    {
        OwnerDto CreateOwner(AddOwnerDto ownerDto);
        Task<OwnerDto> CreateOwnerAsync(AddOwnerDto ownerDto);

        OwnerDto EditOwner(OwnerDto ownerDto);
        Task<OwnerDto> EditOwnerAsync(OwnerDto ownerDto);
        OwnerDto GetOwnerById(int id);
        Task<OwnerDto> GetOwnerByIdAsync(int id);
        PetOwner AddOwnerProfilePic(AddProfilePicDto dto);
        Task<PetOwner> AddOwnerProfilePicAsync(AddProfilePicDto dto);
        List<OwnerDto> GetAllOwners();
        PetOwner DeleteOwnerProfilePic(int id);
        Task<PetOwner> DeleteOwnerProfilePicAsync(int id);
    }
}
