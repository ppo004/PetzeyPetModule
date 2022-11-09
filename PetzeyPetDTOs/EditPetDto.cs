using PetzeyPetEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetDTOs
{
    public class EditPetDto
    {
        public int PetId { get; set; }

        public int OwnerId { get; set; }

        public string Name { get; set; }

        public string Species { get; set; }

        public string Gender { get; set; }

        public DateTime DOB { get; set; }

        public Boolean IsNeutured { get; set; }

        public string BloodGroup { get; set; }
        public List<string> Allergies { get; set; }

        public string Breed { get; set; }

        public string ImageUrl { get; set; }
       
    }
}
