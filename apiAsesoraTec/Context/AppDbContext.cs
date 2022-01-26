﻿using apiAsesoraTec.Models;
using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiAsesoraTec.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<Sexo> Sexo { get; set; }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
