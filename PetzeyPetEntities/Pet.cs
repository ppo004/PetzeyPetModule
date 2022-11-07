using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

using Microsoft.Build.Framework;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace PetzeyPetEntities
{
    public class Pet
    {
        [Key]
        public int PetId { get; set; }
        [Required]
        public int OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Species { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public Boolean IsNeutured { get; set; }
        [Required]
        public string BloodGroup { get; set; }
        public List<string> Allergies { get; set; }
        [Required]
        public string Breed { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public List<PetAndAppointments> AppointmentIds { get; set; }

    }
}
