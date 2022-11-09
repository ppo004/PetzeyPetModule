using PetzeyPetEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetDTOs
{
    public class EditOwnerDto
    {
        
        public int PetOwnerId { get; set; }
        
        public string OwnerName { get; set; }
        
        public string OwnerEmail { get; set; }
        
        public string OwnerPhone { get; set; }
        
        public string OwnerLocation { get; set; }
       
        public string ImageUrl { get; set; }
        public List<OwnerHasPet> PetIds { get; set; }
    }
}
