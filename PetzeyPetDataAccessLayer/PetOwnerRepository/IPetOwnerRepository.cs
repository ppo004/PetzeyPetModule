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
        int CreateOwner(PetOwner petOwner);
        PetOwner EditOwner(PetOwner petOwner);
        //List<string> GetOwnerNames();
        PetOwner AddProfilePic(int petOwnerId, string imageUrl);
        PetOwner DeleteProfilePic(int petOwnerId);
        void DeletePetInOwner(int petId, int ownerId);

        PetOwner getOwnerById (int petOwnerId);

        List<PetOwner> GetAllOwners();
        Task<PetOwner> DeleteProfilePicAsync(int petOwnerId);
        Task<PetOwner> getOwnerByIdAsync(int id);
        Task<PetOwner> AddProfilePicAsync(int ownerId, string imageUrl);
        Task<PetOwner> EditOwnerAsync(PetOwner owner);
        Task<int> CreateOwnerAsync(PetOwner owner);
    }
}
