using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalAED
{
    internal class Candidato
    {
        public string Nome { get; set; }
        public double Redacao { get; set; }
        public double Matematica { get; set; }
        public double Linguagens { get; set; }
        public double Media { get; set; }
        public int OpcaoDeCurso1 { get; set; }
        public int OpcaoDeCurso2 { get; set; }

        Candidato(string nome, double redacao, double matematica, double linguagens, int opcao1, int opcao2) 
        {
            Nome = nome;
            Redacao = redacao;
            Matematica = matematica;
            Linguagens = linguagens;
            OpcaoDeCurso1 = opcao1;
            OpcaoDeCurso2 = opcao2;
            Media = CalcularMedia();
        }

        public double CalcularMedia()
        {
            return (Redacao + Matematica + Linguagens) / 3;
        }

    }
}
