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
        public int PetOwnerId;
        [Required]
        public string OwnerName;
        [Required]
        public string OwnerEmail;
        [Required]
        public string OwnerPhone;
        [Required]
        public string OwnerLocation;
        [Required]
        public string ImageUrl;
        public List<int> PetIds;
    }
}
