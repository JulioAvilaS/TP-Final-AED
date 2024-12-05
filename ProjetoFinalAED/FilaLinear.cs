using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalAED
{
    internal class FilaLinear
    {
        private Candidato[] array;
        int primeiro, ultimo;
        public FilaLinear(int tamanho)
        {
            array = new Candidato[tamanho + 1];
            primeiro = ultimo = 0;
        }
        public void Inserir(Candidato x)
        {
            if (((ultimo + 1) % array.Length) == primeiro)
                throw new Exception("Erro!");
            array[ultimo] = x;
            ultimo = (ultimo + 1) % array.Length;
        }
    }
}
