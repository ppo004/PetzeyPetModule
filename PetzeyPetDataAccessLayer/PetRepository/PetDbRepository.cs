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

        public PetAndAppointments AddAppointmentId(PetAppDto petAppDto)
        {
            PetAndAppointments petAppointment = new PetAndAppointments();
            petAppointment.AppointmentId = petAppDto.AppointmentId;
            db.PetAndAppointments.Add(petAppointment);
            db.SaveChanges();
            
            Pet pet = db.Pets.Find(petAppDto.petId);
            pet.AppointmentIds.Add(petAppointment);
            db.Entry(pet).State = EntityState.Modified;
            return petAppointment;

        }

        public int CreatePet(Pet pet)
        {
            db.Pets.Add(pet);
            db.SaveChanges();

            

            PetOwner owner = db.PetOwners.Find(pet.OwnerId);
            OwnerHasPet ownerHasPet = new OwnerHasPet();
            ownerHasPet.PetId = pet.PetId;
            if (owner.PetIds == null)
            {
                List<OwnerHasPet> ownerHasPetList = new List<OwnerHasPet>();
                ownerHasPetList.Add(ownerHasPet);
                owner.PetIds = ownerHasPetList;
            }
            else
            {
                owner.PetIds.Add(ownerHasPet);
            }
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
            db.SaveChanges();
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

/// <summary>
/// Async Repo Functions
/// </summary>

        public async Task<PetAndAppointments> AddAppointmentIdAsyc(PetAppDto petAppDto)
        {
            PetAndAppointments petAppointment = new PetAndAppointments();
            petAppointment.AppointmentId = petAppDto.AppointmentId;
            db.PetAndAppointments.Add(petAppointment);
            await db.SaveChangesAsync();

            Pet pet = await db.Pets.FindAsync(petAppDto.petId);
            pet.AppointmentIds.Add(petAppointment);
            db.Entry(pet).State = EntityState.Modified;
            return petAppointment;
        }
        public async Task<int> CreatePetAsync(Pet pet)
        {
            db.Pets.Add(pet);
            await db.SaveChangesAsync();
            PetOwner owner = await db.PetOwners.FindAsync(pet.OwnerId);
            OwnerHasPet ownerHasPet = new OwnerHasPet();
            ownerHasPet.PetId = pet.PetId;
            if (owner.PetIds == null)
            {
                List<OwnerHasPet> ownerHasPetList = new List<OwnerHasPet>();
                ownerHasPetList.Add(ownerHasPet);
                owner.PetIds = ownerHasPetList;
            }
            else
            {
                owner.PetIds.Add(ownerHasPet);
            }
            await db.SaveChangesAsync();
            return pet.PetId;
        }

        public async void DeletePetAsync(int petId)
        {
            Pet pet = await db.Pets.FindAsync(petId);
            ownerRepo.DeletePetInOwner(petId, pet.OwnerId);
            db.Pets.Remove(db.Pets.Find(petId));
            await db.SaveChangesAsync();
        }

        public async Task<Pet> EditPetAsync(Pet pet)
        {
            db.Entry(pet).State = EntityState.Modified;

            await db.SaveChangesAsync();
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


    }
}
