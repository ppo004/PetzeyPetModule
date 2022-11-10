using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetEntities
{
    public class PetAndAppointments
    {
        [Key]
        public int PetAppId { get; set; }
        [Required,Index(IsUnique = true)]
        public int AppointmentId { get; set; }
    }
}
