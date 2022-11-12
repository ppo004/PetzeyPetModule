using PetzeyPetEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetDataAccessLayer.AllergyRepository
{
    public interface IAllergyRepository
    {
        Task<Allergy> AddAllergyAsync(Allergy allergy);
        List<Allergy> GetAllergies();
    }
}
