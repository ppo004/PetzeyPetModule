using PetzeyPetDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetBusinessLayer
{
    public interface IPetBll
    {
        bool AddAppointmentsToPet(PetAppDto petAppdto);
        UpdatePetDto CreatePet(AddPetDto petDto);
        UpdatePetDto EditPet(UpdatePetDto petDto);
        bool DeletePet(int id);
        UpdatePetDto GetPetById(int id);
        Task<UpdatePetDto> CreatePetAsync(AddPetDto petDto);
        Task<UpdatePetDto> EditPetAsync(UpdatePetDto petDto);
        Task<bool> DeletePetAsync(int id);
        Task<UpdatePetDto> GetPetByIdAsync(int id);
        List<UpdatePetDto> GetAllPets();
    }
}
