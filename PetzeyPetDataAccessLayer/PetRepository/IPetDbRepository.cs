using PetzeyPetDTOs;
using PetzeyPetEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetDataAccessLayer
{
    public interface IPetDbRepository
    {
        int AddAppointmentId(int appId, int petId);
        List<Pet> GetAllPets();
        int CreatePet(Pet pet);
        Pet EditPet(Pet pet);
        void DeletePet(int petId);
        Pet GetPetById(int id);
        PetAndAppointments GetPetandAppById(int appId);

        Task<int> AddAppointmentIdAsyc(int appId, int petId);
        Task<List<UpdatePetDto>> GetAllPetsAsync();
        Task<int> CreatePetAsync(Pet pet);
        Task<Pet> EditPetAsync(Pet pet);
        void DeletePetAsync(int petId);
        Task<Pet> GetPetByIdAsync(int id);
        Task<PetAndAppointments> GetPetandAppByIdAsync(int petAppId);
    }
}
