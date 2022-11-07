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
        void AddAppointmentId(int appointmentId, int petId);
        List<string> GetAllPets();
        void CreatePet(Pet pet);
        void EditPet(Pet pet);
        void DeletePet(int petId);

    }
}
