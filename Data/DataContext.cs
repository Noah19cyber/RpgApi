using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RpgApi.Models;

namespace RpgApi.Data
{
    public class DataContext (DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    public DbSet <Personagem> TB_PERSONAGENS { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        (
            ModelBuilder 
}