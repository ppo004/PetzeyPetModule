using AutoMapper;
using PetzeyPetDataAccessLayer.AllergyRepository;
using PetzeyPetDTOs;
using PetzeyPetEntities;
using PetzeyPetExceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetBusinessLayer
{
    public class AllergyBll : IAllergyBll
    {
        IAllergyRepository repo;
        public AllergyBll()
        {
            this.repo  = new AllergyRepository();
        }
        public async Task<Allergy> AddAllergy(Allergy allergy)
        {
            try
            {
                Allergy res = await repo.AddAllergyAsync(allergy);
                return res;
            }
            catch(DbUpdateException e)
            {
                throw new AllergyAlreadyExistsException();
            }
        }
        public List<Allergy> GetAllAllergies()
        {
            List<Allergy> allergies = new List<Allergy>();
            foreach (Allergy allergy in repo.GetAllergies())
                allergies.Add(allergy);
            return allergies;
        }
        
    }
}
