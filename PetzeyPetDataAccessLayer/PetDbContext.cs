using PetzeyPetEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetDataAccessLayer
{
    public class PetDbContext : DbContext
    {
        public PetDbContext() : base("name=DefaultConnection")
        {

        }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetOwner> PetOwners { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<OwnerHasPet> OwnerHasPets { get; set; }
        public DbSet<PetAndAppointments> PetAndAppointments { get; set; }

    }
}
