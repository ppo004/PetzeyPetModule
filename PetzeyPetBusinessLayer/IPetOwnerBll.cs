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
        EditOwnerDto CreateOwner(AddOwnerDto ownerDto);
        EditOwnerDto EditOwner(EditOwnerDto ownerDto);
        EditOwnerDto GetOwnerById(int id);
        PetOwner AddOwnerProfilePic(AddProfilePicDto dto);
        List<EditOwnerDto> GetAllOwners();
        PetOwner deleteOwnerProfilePic(int id);
    }
}
