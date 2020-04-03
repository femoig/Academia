using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academia.Models
{
    public class Exercicio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Series { get; set; }
        public int Repeticoes { get; set; }

        public Treino Treino { get; set; }

        //public CategoriaExercicio Categoria { get; set; }

    }
}
