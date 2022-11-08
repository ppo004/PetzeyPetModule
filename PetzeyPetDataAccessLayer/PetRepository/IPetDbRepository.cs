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
        void AddAppointmentId(PetAppDto petAppDto);
        List<PetDto> GetAllPets();
        void CreatePet(AddPetDto petDto);
        void EditPet(AddPetDto petDto);
        void DeletePet(int petId);
        Pet GetPetById(int id);

    }
}
