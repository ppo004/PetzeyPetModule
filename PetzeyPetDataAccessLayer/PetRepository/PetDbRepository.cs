using PetzeyPetDTOs;
using PetzeyPetEntities;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using System.Data.Common;
using System.Data.Entity;
using PetzeyPetDataAccessLayer.PetOwnerRepository;

namespace PetzeyPetDataAccessLayer
{
    public class PetDbRepository : IPetDbRepository
    {
        
        PetDbContext db = new PetDbContext();
        IPetOwnerRepository ownerRepo = new PetOwnerRepository.PetOwnerRepository();

/// <summary>
/// Repo Functions
/// </summary>

        public int AddAppointmentId(int petId, int appId)
        {
            PetAndAppointments appointment = new PetAndAppointments();
            Pet pet = db.Pets.Find(petId);
            appointment.AppointmentId = appId;
            if (pet.AppointmentIds == null)
                pet.AppointmentIds = new List<PetAndAppointments>() { appointment };
            else
                pet.AppointmentIds.Add(appointment);
            
            
            db.Entry(pet).State = EntityState.Modified;
            db.SaveChanges();
            return appointment.PetAppId;
            

        }

        public int CreatePet(Pet pet)
        {
            db.Pets.Add(pet);
            db.SaveChanges();

            PetOwner owner = db.PetOwners.Find(pet.OwnerId);
            OwnerHasPet ownerHasPet = new OwnerHasPet();
            ownerHasPet.PetId = pet.PetId;
            if (owner.PetIds == null)
                owner.PetIds = new List<OwnerHasPet>() { ownerHasPet };
            else
                owner.PetIds.Add(ownerHasPet);

            db.SaveChanges();

            return pet.PetId;

        }

    

        public void DeletePet(int petId)
        {
            Pet pet = db.Pets.Find(petId);
            ownerRepo.DeletePetInOwner(petId, pet.OwnerId);
            db.Pets.Remove(db.Pets.Find(petId));
            db.SaveChanges();

        }

        public Pet EditPet(Pet pet)
        {           
            db.Entry(pet).State = EntityState.Modified;
            
            return pet;
        }

        public List<Pet> GetAllPets()
        {
            return db.Pets.ToList();
        }

        public Pet GetPetById(int id)
        {
            return db.Pets.Find(id);
        }

        public PetAndAppointments GetPetandAppById(int petAppId)
        {
            PetAndAppointments appointment = db.PetAndAppointments.Find(petAppId);
            return appointment;
        }

        /// <summary>
        /// Async Repo Functions
        /// </summary>


        public async Task<int> AddAppointmentIdAsyc(int appId, int petId)
        {
            PetAndAppointments appointment = new PetAndAppointments();
            Pet pet = await db.Pets.FindAsync(petId);
            appointment.AppointmentId = appId;
            if (pet.AppointmentIds == null)
                pet.AppointmentIds = new List<PetAndAppointments>() { appointment };
            else
                pet.AppointmentIds.Add(appointment);


            db.Entry(pet).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return appointment.PetAppId;
        }




        public async Task<int> CreatePetAsync(Pet pet)
        {
            db.Pets.Add(pet);
            await db.SaveChangesAsync();
            PetOwner owner = await db.PetOwners.FindAsync(pet.OwnerId);
            OwnerHasPet ownerHasPet = new OwnerHasPet();
            ownerHasPet.PetId = pet.PetId;
            if (owner.PetIds == null)
                owner.PetIds = new List<OwnerHasPet>() { ownerHasPet };
            else
                owner.PetIds.Add(ownerHasPet);
            await db.SaveChangesAsync();
            return pet.PetId;
        }

        public async void DeletePetAsync(int petId)
        {
            Pet pet = await db.Pets.FindAsync(petId);
            ownerRepo.DeletePetInOwner(petId, pet.OwnerId);//add async func
            db.Pets.Remove(db.Pets.Find(petId));
            await db.SaveChangesAsync();
        }

        public async Task<Pet> EditPetAsync(Pet pet)
        {
           if(await db.Pets.FindAsync(pet.PetId)!=null)
            db.Entry(pet).State = EntityState.Modified;

            
            return pet;
        }

        public Task<List<UpdatePetDto>> GetAllPetsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Pet> GetPetByIdAsync(int id)
        {
            Pet pet = await db.Pets.FindAsync(id);
            return pet;

        }

        public async Task<PetAndAppointments> GetPetandAppByIdAsync(int petAppId)
        {
            PetAndAppointments appointment = await db.PetAndAppointments.FindAsync(petAppId);
            return appointment;
        }
    }
}
