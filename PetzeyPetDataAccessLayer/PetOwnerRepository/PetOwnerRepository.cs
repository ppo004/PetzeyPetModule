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

        public PetOwner AddProfilePic(int petOwnerId, string imageUrl)
        {
            var owner = db.PetOwners.Find(petOwnerId);
            owner.ImageUrl = imageUrl;
            db.SaveChanges();
            return owner;
        }

        public PetOwner DeleteProfilePic(int petOwnerId)
        {
            var owner = db.PetOwners.Find(petOwnerId);
            owner.ImageUrl = "shorturl.at/tJUZ3";
            db.SaveChanges();
            return owner;
        }


        public PetOwner EditOwner(PetOwner petOwner)
        {
            
            db.Entry(petOwner).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return petOwner;
        }

        public List<string> GetOwnerNames()
        {
            throw new NotImplementedException();
        }

        public void DeletePetInOwner(int petId,int ownerId)
        {
          // List<OwnerHasPet> ownerHasPets = db.OwnerHasPets.Where(p => p.PetId == petId).ToList();
            PetOwner owner = db.PetOwners.Find(ownerId);
            OwnerHasPet o = owner.PetIds.ToList().Where(p => p.PetId == petId).FirstOrDefault();
            owner.PetIds.RemoveAll(p=>p.PetId == petId);
            db.OwnerHasPets.Remove(o);
            db.SaveChanges();

        }

        public PetOwner getOwnerById(int petOwnerId)
        {
            return db.PetOwners.Find(petOwnerId);
        }

        public List<PetOwner> GetAllOwners()
        {
            return db.PetOwners.ToList();
        }
    }
}
