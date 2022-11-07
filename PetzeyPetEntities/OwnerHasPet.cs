using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetEntities
{
    public class OwnerHasPet
    {
        [Key]
        public int OwnerPetId { get; set; }
        public int PetId { get; set; }
    }
}
