using Academia.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academia
{
    public class AcademiaContext : DbContext
    {
        public AcademiaContext(DbContextOptions options) : base(options)
        {
        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aluno>().HasKey(a => a.Id);
            modelBuilder.Entity<Aluno>().HasOne(a => a.Treino).WithOne(t => t.Aluno).HasForeignKey<Treino>(v => v.Id);


            modelBuilder.Entity<Treino>().HasKey(a => a.Id);            
            modelBuilder.Entity<Treino>().HasMany(a => a.Exercicios).WithOne(a => a.Treino).IsRequired();

            


        }

        

        public DbSet<Academia.Models.Aluno> Aluno { get; set; }

        

        public DbSet<Academia.Models.Exercicio> Exercicio { get; set; }

        

        public DbSet<Academia.Models.Treino> Treino { get; set; }
    }
}
