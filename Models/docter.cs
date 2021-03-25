using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_project.Models
{
    public class docter
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Sepicaligation { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
