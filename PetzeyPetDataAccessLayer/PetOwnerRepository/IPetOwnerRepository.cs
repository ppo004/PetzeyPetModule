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
        PetOwner AddProfilePic(int petOwnerId, string imageUrl);
        PetOwner DeleteProfilePic(int petOwnerId);
        void DeletePetInOwner(int petId, int ownerId);
        PetOwner getOwnerById (int petOwnerId);
        List<PetOwner> GetAllOwners();


        // Async
        Task<int> CreateOwnerAsync(PetOwner petOwner);
        Task<PetOwner> EditOwnerAsync(PetOwner petOwner);
        Task<PetOwner> AddProfilePicAsync(int petOwnerId, string imageUrl);
        Task<PetOwner> DeleteProfilePicAsync(int petOwnerId);
        void DeletePetInOwnerAsync(int petId, int ownerId);
        Task<PetOwner> getOwnerByIdAsync(int petOwnerId);

      

    }
}
