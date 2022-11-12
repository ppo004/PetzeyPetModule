using PetzeyPetEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetBusinessLayer
{
    public interface IAllergyBll
    {
        Task<Allergy> AddAllergy(Allergy allergy);
        List<Allergy> GetAllAllergies();
    }
}
