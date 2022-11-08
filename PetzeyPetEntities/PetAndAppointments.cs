using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetEntities
{
    public class PetAndAppointments
    {
        [Key]
        public int PetAppId { get; set; }
        [Required]
        public int AppointmentId { get; set; }
    }
}
