using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalAED
{
    internal class Curso
    {
        public string Nome { get; set; }
        public int QuantVagas { get; set; }
        public double NotaCorte { get; set; }
        List<Candidato> Selecionados { get; set;}
        public FilaLinear FilaDeEspera { get; set; }


        public Curso(string nomeDoCurso, int quantVagas)
        {
            Nome = nomeDoCurso;
            QuantVagas = quantVagas;
            NotaCorte = 0;
            Selecionados = new List<Candidato>();
            FilaDeEspera = new FilaLinear(10);
        }
    }
}
