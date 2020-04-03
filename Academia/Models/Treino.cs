using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Academia.Models
{
    public class Treino
    {
        public int Id { get; set; }

        [Display(Name = "Ínicio do Treino")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Fim do Treino")]
        [DataType(DataType.Date)]
        public DateTime DataFim { get; set; }
        public int Progresso { get; set; }

        public virtual Aluno Aluno { get; set; }

        public virtual List<Exercicio> Exercicios { get; private set; } = new List<Exercicio>();

    }
}
