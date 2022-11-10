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
        int AddAppointmentsToPet(PetAppDto petAppdto);
        UpdatePetDto CreatePet(AddPetDto petDto);
        UpdatePetDto EditPet(UpdatePetDto petDto);
        bool DeletePet(int id);
        UpdatePetDto GetPetById(int id);
        List<UpdatePetDto> GetAllPets();
        Task<UpdatePetDto> CreatePetAsync(AddPetDto petDto);
        Task<UpdatePetDto> EditPetAsync(UpdatePetDto petDto);
        Task<bool> DeletePetAsync(int id);
        Task<UpdatePetDto> GetPetByIdAsync(int id);
        //Task<List<UpdatePetDto>> GetAllPetsAsync();
        Task<bool> AddAppointmentsToPetAsync(PetAppDto petAppdto);

    }
}
