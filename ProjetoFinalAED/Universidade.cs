using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalAED
{
    internal class Universidade
    {
        public string Nome { get; } = "Stark";
        public Dictionary<int, Curso> Cursos { get; set; }

        public Universidade()
        {
            Cursos = new Dictionary<int, Curso>();

        }
    }
}
