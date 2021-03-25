using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_project.Models
{
    public class patient
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
