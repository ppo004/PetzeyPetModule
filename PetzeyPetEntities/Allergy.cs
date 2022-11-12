using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetEntities
{
    public class Allergy
    {
        [Key]
        public int AllergyId { get; set; }
        [Required, MaxLength(64), Index(IsUnique = true)]
        public string Name { get; set; }
    }
}
