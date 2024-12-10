using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalAED
{
    public class Candidato
    {
        public string Nome { get; set; }
        public double Redacao { get; set; }
        public double Matematica { get; set; }
        public double Linguagens { get; set; }
        public double Media { get; set; }
        public int OpcaoDeCurso1 { get; set; }
        public int OpcaoDeCurso2 { get; set; }

        public Candidato(string nome, double redacao, double matematica, double linguagens, int opcao1, int opcao2) 
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

        public override bool Equals(object obj)
        {
            if (obj is Candidato candidato)
            {
                return Nome == candidato.Nome &&
                       Matematica == candidato.Matematica &&
                       Redacao == candidato.Redacao &&
                       OpcaoDeCurso1 == candidato.OpcaoDeCurso1 &&
                       OpcaoDeCurso2 == candidato.OpcaoDeCurso2 &&
                       Media == candidato.Media;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{Nome} {Math.Round(Media, 2)} {Redacao} {Matematica} {Linguagens}";
        }

    }
}
