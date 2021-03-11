using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_Ploomes_API_PersonagemRPG.Models
{
    public class Personagem
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Nome { get; set; }
        public string Aparencia { get; set; }
        public string Historia { get; set; }
        public int Vida { get; set; }
        public int Mana { get; set; }
        public int Forca { get; set; }
        public int Agilidade { get; set; }
        public int Inteligencia { get; set; }
        public int Vitalidade { get; set; }
        public int Carisma { get; set; }


        [Required]
        [Range(0, 30, ErrorMessage = "Os atributos precisam estar entre {1} e {2}")]
        public int TotalAtributos { get; set;  }


        public Personagem()
        {

        }
    }
}
