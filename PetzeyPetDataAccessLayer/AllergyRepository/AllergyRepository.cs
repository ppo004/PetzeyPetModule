using PetzeyPetEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetDataAccessLayer.AllergyRepository
{
    public class AllergyRepository : IAllergyRepository
    {
        PetDbContext dbContext;
        public AllergyRepository(){
            dbContext  = new PetDbContext();
    }
        public List<Allergy> GetAllergies()
        {
            return dbContext.Allergies.ToList();
        }
        public async Task<Allergy> AddAllergyAsync(Allergy allergy)
        {
            dbContext.Allergies.Add(allergy);
            await dbContext.SaveChangesAsync();
            return allergy;
        }
    }
}
