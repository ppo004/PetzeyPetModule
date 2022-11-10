using PetzeyPetDTOs;
using PetzeyPetEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetzeyPetExceptions;
namespace PetzeyPetDataAccessLayer.PetOwnerRepository
{
    public class PetOwnerRepository: IPetOwnerRepository
    {
        PetDbContext db = new PetDbContext();

        public PetOwner CreateOwner(PetOwner petOwner)
        {
            db.PetOwners.Add(petOwner);
            db.SaveChanges();
            PetOwner owner = getOwnerById(petOwner.PetOwnerId);
            return owner;
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
            try
            {
                var owner = db.PetOwners.Find(petOwnerId);
                if (owner == null) throw new OwnerDoesntExistException();
                owner.ImageUrl = "shorturl.at/tJUZ3";
                db.SaveChanges();
                return owner;
            }
            catch(OwnerDoesntExistException e) { throw e; }
        }


        public PetOwner EditOwner(PetOwner petOwner)
        {
            
            db.Entry(petOwner).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return petOwner;
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



        /// <summary>
        /// Async Funs
        /// </summary>
        ///



        public async Task<PetOwner> CreateOwnerAsync(PetOwner petOwner)
        {
            db.PetOwners.Add(petOwner);
            db.SaveChanges();
            return await getOwnerByIdAsync(petOwner.PetOwnerId);
        }

        public async Task<PetOwner> EditOwnerAsync(PetOwner petOwner)
        {
            db.Entry(petOwner).State = System.Data.Entity.EntityState.Modified;
            await db.SaveChangesAsync();
            return petOwner; 
        }

    

        public async Task<PetOwner> AddProfilePicAsync(int petOwnerId, string imageUrl)
        {
            try
            {
                var owner = db.PetOwners.Find(petOwnerId);
                if (owner == null) throw new OwnerDoesntExistException();
                owner.ImageUrl = imageUrl;
                await db.SaveChangesAsync();
                return owner;
            }
            catch(OwnerDoesntExistException e) { throw e; }
        }

        public async Task<PetOwner> DeleteProfilePicAsync(int petOwnerId)
        {
            var owner = db.PetOwners.Find(petOwnerId);
            owner.ImageUrl = "shorturl.at/tJUZ3";
            await db.SaveChangesAsync();
            return owner;
        }

        public async void DeletePetInOwnerAsync(int petId, int ownerId)
        {
            PetOwner owner = db.PetOwners.Find(ownerId);
            OwnerHasPet o = owner.PetIds.ToList().Where(p => p.PetId == petId).FirstOrDefault();
            owner.PetIds.RemoveAll(p => p.PetId == petId);
            db.OwnerHasPets.Remove(o);
            await db.SaveChangesAsync();
        }

        public async Task<PetOwner> getOwnerByIdAsync(int petOwnerId)
        {
            return await db.PetOwners.FindAsync(petOwnerId);
        }


    }
}
