using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetEntities
{
    public class PetOwner
    {
        [Key]
        public int PetOwnerId { get; set; }
        [Required]
        public string OwnerName { get; set; }
        [Required]
        public string OwnerEmail { get; set; }
        [Required]
        public string OwnerPhone { get; set; }
        [Required]
        public string OwnerLocation { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public List<OwnerHasPet> PetIds { get; set; }
    }
}
