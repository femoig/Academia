using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Academia.Models
{
    public class Aluno
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        [Required]
        public string Email { get; set; }
        
        [Display(Name ="Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Data de Inscrição")]
        [DataType(DataType.Date)]
        public DateTime DataInscricao { get; set; }
        public virtual Treino Treino { get; set; }


        public Aluno()
        {

        }

        public Aluno(string nome, string sobrenome, string email)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
        }

        public override string ToString()
        {
            return $"{this.Id}, Aluno: {this.Nome}, {this.Sobrenome}";
        }
    }
}
