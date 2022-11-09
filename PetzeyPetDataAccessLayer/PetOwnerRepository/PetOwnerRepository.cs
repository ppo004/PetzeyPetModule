using PetzeyPetDTOs;
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

        public int CreateOwner(PetOwner petOwner)
        {
            db.PetOwners.Add(petOwner);
            db.SaveChanges();
            return petOwner.PetOwnerId;
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


        public PetOwner EditOwner(PetOwner petOwner)
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
            return petOwner;
        }

        public List<string> GetOwnerNames()
        {
            throw new NotImplementedException();
        }

        public PetOwner getOwnerById(int petOwnerId)
        {
            return db.PetOwners.Find(petOwnerId);
        }
    }
}
