using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_project.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public int ClinicId { get; set; }
        public clinic Clinic { get; set; }
        public int DocterID { get; set; }
        public docter Docter { get; set; }
        public int PatientID { get; set; }
        public patient Patient { get; set; }
        public DateTime Appointment_date_time { get; set; }

    }
}
