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
        PetOwner CreateOwner(PetOwner petOwner);
        PetOwner EditOwner(PetOwner petOwner);
        //List<string> GetOwnerNames();
        PetOwner AddProfilePic(int petOwnerId, string imageUrl);
        PetOwner DeleteProfilePic(int petOwnerId);
        void DeletePetInOwner(int petId, int ownerId);
        List<Pet> getPetsOfOwner(int id);
        PetOwner getOwnerById (int petOwnerId);

        List<PetOwner> GetAllOwners();
        Task<PetOwner> DeleteProfilePicAsync(int petOwnerId);
        Task<PetOwner> getOwnerByIdAsync(int id);
        Task<PetOwner> AddProfilePicAsync(int ownerId, string imageUrl);
        Task<PetOwner> EditOwnerAsync(PetOwner owner);
        Task<PetOwner> CreateOwnerAsync(PetOwner owner);
    }
}
