﻿using PetzeyPetDTOs;
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

        public List<Pet> getPets(int id)
        {
            List<OwnerHasPet> petIds = db.PetOwners.Find(id).PetIds.ToList();
            List<Pet> pets = new List<Pet>();
            foreach (var petId in petIds)
            {
                pets.Add(db.Pets.Find(petId.PetId));
            }

            return pets;

        }
    }
}
