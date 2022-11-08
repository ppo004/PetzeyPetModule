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
        MapperConfiguration config = new MapperConfiguration(cfg =>

                   cfg.CreateMap<AddPetDto, Pet>().ForMember(dest => dest.AppointmentIds, act => act.Ignore())

               );
        MapperConfiguration config1 = new MapperConfiguration(cfg =>

                  cfg.CreateMap<PetDto, Pet>()

              );
        PetDbContext db = new PetDbContext();
       
        public void AddAppointmentId(PetAppDto petAppDto)
        {
            PetAndAppointments petAppointment = new PetAndAppointments();
            petAppointment.AppointmentId = petAppDto.AppointmentId;
            db.PetAndAppointments.Add(petAppointment);
            db.SaveChanges();
            
            Pet pet = db.Pets.Find(petAppDto.petId);
            pet.AppointmentIds.Add(petAppointment);
            db.Entry(pet).State = EntityState.Modified;

        }

        public void CreatePet(AddPetDto petDto)
        {
            Mapper mapper = new Mapper(config);
            Pet newPetObj = mapper.Map<Pet>(petDto);
            newPetObj.AppointmentIds = null;

            db.Pets.Add(newPetObj);
            db.SaveChanges();
            return;
           


        }

        //public Pet Getpetbyname(string name)
        //{
        //    return db.Pets.Find(db.Pets.FirstOrDefault(p => p.Name == name));
            
        //}

        public void DeletePet(int petId)
        {
            db.Pets.Remove(db.Pets.Find(petId));
            db.SaveChanges();
        }

        public void EditPet(AddPetDto petDto)
        {
            Mapper mapper = new Mapper(config);
            Pet editPetObj = mapper.Map<Pet>(petDto);
           
            db.Entry(editPetObj).State = EntityState.Modified;

            db.SaveChanges();
        }

        public List<PetDto> GetAllPets()
        {
            Mapper mapper = new Mapper(config1);
            List<PetDto> petDtos = new List<PetDto>();
            List<Pet>  pets = db.Pets.ToList();
            petDtos = mapper.Map<List<PetDto>>(pets);

            return petDtos;

        }

        public Pet GetPetById(int id)
        {
            return db.Pets.Find(id);
        }
    }
}
