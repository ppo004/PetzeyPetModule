using PetzeyPetDTOs;
using PetzeyPetEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetDataAccessLayer.PetRepository
{
    public class AsyncPetRepo : IAsyncPetRepo
    {
        PetDbContext db = new PetDbContext();

        public async Task<PetAndAppointments> AddAppointmentId(PetAppDto petAppDto)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CreatePet(Pet pet)
        {
            db.Pets.Add(pet);
          await  db.SaveChangesAsync();
            return pet.PetId;
        }

        public async void DeletePet(int petId)
        {
            db.Pets.Remove(db.Pets.Find(petId));
            await db.SaveChangesAsync();
        }

        public Task<Pet> EditPet(Pet pet)
        {
            throw new NotImplementedException();
        }

        public Task<List<UpdatePetDto>> GetAllPets()
        {
            throw new NotImplementedException();
        }

        public Task<Pet> GetPetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
