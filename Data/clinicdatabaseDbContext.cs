using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_project.Data
{
    public class clinicdatabaseDbContext : DbContext
    {
        public clinicdatabaseDbContext(DbContextOptions<clinicdatabaseDbContext> options)
            : base(options)
        {
        }
        public DbSet<MVC_project.Models.Appointment> Appointment { get; set; }

        public DbSet<MVC_project.Models.clinic> clinic { get; set; }

        public DbSet<MVC_project.Models.docter> docter { get; set; }

        public DbSet<MVC_project.Models.patient> patient { get; set; }
    }
}
