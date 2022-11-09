using PetzeyPetEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetDataAccessLayer.PetOwnerRepository
{
    public class PetOwnerRepository: IPetOwnerRepository
    {
        PetDbContext db = new PetDbContext();

        public void CreateOwner(PetOwner petOwner)
        {
            db.PetOwners.Add(petOwner);
            db.SaveChanges();
        }

        public void AddProfilePic(int petOwnerId, string imageUrl)
        {
            var owner = db.PetOwners.Find(petOwnerId);
            owner.ImageUrl = imageUrl;
            db.SaveChanges();
        }

        public void DeleteProfilePic(int petOwnerId)
        {
            var owner = db.PetOwners.Find(petOwnerId);
            owner.ImageUrl = "No Profile";
            db.SaveChanges();
        }


        public void EditOwner(PetOwner petOwner)
        {
            throw new NotImplementedException();
        }

        public List<string> GetOwnerNames()
        {
            throw new NotImplementedException();
        }
    }
}
