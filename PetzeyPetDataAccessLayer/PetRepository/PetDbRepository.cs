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

namespace PetzeyPetDataAccessLayer
{
    public class PetDbRepository : IPetDbRepository
    {
        
        PetDbContext db = new PetDbContext();
       
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
            return pet.PetId;
        }

    

        public void DeletePet(int petId)
        {
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
    }
}
