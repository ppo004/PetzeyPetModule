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

        public bool CreateOwner(PetOwner petOwner)
        {
            db.PetOwners.Add(petOwner);
            db.SaveChanges();
            return true;
        }

        public void AddProfilePic(int petOwnerId, string imageUrl)
        {
            var owner = db.PetOwners.Find(petOwnerId);
            owner.ImageUrl = imageUrl;
        }

        public void DeleteProfilePic(int petOwnerId)
        {
            throw new NotImplementedException();
        }


        public void EditOwner(PetOwner petOwner)
        {
            /*var ownernew = db.PetOwners.Find(petOwner.PetOwnerId);
            if (ownernew != null)
            {
                db.Entry(petOwner).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            return false;*/
            db.Entry(petOwner).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public List<string> GetOwnerNames()
        {
            throw new NotImplementedException();
        }
    }
}
