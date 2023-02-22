using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DepartamentosMunicipiosMVC.Models;

namespace DepartamentosMunicipiosMVC.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Departamento> Departamentos { get; set; } = default!;

        public DbSet<Municipio> Municipios { get; set; } = default!;
    }
}
