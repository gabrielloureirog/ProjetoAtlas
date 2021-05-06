using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjetoAlans_API.models;

namespace ProjetoAlans_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }        
        public  DbSet < Funcionario > Funcionarios { get ; set ; }
                
        protected override void OnModelCreating(ModelBuilder builder)
        {  
            builder.Entity<Funcionario>()
            .HasData(new List<Funcionario>(){
                //5x2, 6x1, 6x2 e 12x36
                    new Funcionario(1, "Marta", "5x2", 200),
                    new Funcionario(2, "Paula", "12x36", 300),
                    new Funcionario(3, "Laura", "6x1", 500),
                    new Funcionario(4, "Luiza", "5x2", 150),
                    new Funcionario(5, "Lucas", "12x36", 50),
                    new Funcionario(6, "Pedro", "6x1", 60),
                    new Funcionario(7, "Paulo", "12x36", 75)
            });
        }
    }
}

