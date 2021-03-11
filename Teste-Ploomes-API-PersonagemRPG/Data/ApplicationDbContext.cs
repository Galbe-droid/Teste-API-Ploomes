using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Teste_Ploomes_API_PersonagemRPG.Models;

namespace Teste_Ploomes_API_PersonagemRPG.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Teste_Ploomes_API_PersonagemRPG.Models.Personagem> Personagem { get; set; }
    }
}
