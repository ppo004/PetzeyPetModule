using PetzeyPetEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetDataAccessLayer.PetOwnerRepository
{
    public interface IPetOwnerRepository
    {
        void CreateOwner(PetOwner petOwner);
        void EditOwner(PetOwner petOwner);
        List<string> GetOwnerNames();
        void AddProfilePic(int petOwnerId, string imageUrl);
        void DeleteProfilePic(int petOwnerId);

    }
}
