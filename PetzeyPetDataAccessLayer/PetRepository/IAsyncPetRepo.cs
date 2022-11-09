using PetzeyPetDTOs;
using PetzeyPetEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetDataAccessLayer.PetRepository
{
    public interface IAsyncPetRepo
    {
        Task<PetAndAppointments> AddAppointmentId(PetAppDto petAppDto);
        Task<List<UpdatePetDto>> GetAllPets();
        Task<int> CreatePet(Pet pet);
        Task<Pet> EditPet(Pet pet);
        void DeletePet(int petId);
        Task<Pet> GetPetById(int id);
    }
}
