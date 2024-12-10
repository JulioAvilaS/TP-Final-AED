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
        int primeiro, ultimo, cont;
        public FilaLinear(int tamanho)
        {
            array = new Candidato[tamanho + 1];
            primeiro = ultimo = cont = 0;
        }
        public void Add(Candidato x)
        {
            if (((ultimo + 1) % array.Length) == primeiro)
                throw new Exception("Erro!");
            array[ultimo] = x;
            ultimo = (ultimo + 1) % array.Length;
            cont++;
        }
        public int Cont
        {
            get { return cont; }
        }
        public bool Contains(Candidato x)
        {
            for (int i = primeiro; i != ultimo; i = (i + 1) % array.Length)
            {
                if (array[i].Equals(x))
                {
                    return true;
                }
            }
            return false;
        }
        public void Remove(Candidato aluno)
        {
            if (primeiro == ultimo)
                throw new Exception("Fila vazia!");

            int posicaoRemover = -1;

            for (int i = primeiro; i != ultimo; i = (i + 1) % array.Length)
            {
                if (array[i] != null && array[i].Equals(aluno))
                {
                    posicaoRemover = i;
                    i = ultimo;
                }
            }

            if (posicaoRemover == -1)
                throw new Exception("Elemento não encontrado!");


            for (int i = posicaoRemover; i != ultimo; i = (i + 1) % array.Length)
            {
                int proximo = (i + 1) % array.Length;
                array[i] = array[proximo];
            }


            ultimo = (ultimo - 1 + array.Length) % array.Length;
            array[ultimo] = null;
        }
        public Candidato Dequeue()
        {
            if (primeiro == ultimo)
            {
                throw new Exception("Fila vazia!");
            }

            
            Candidato itemRemovido = array[primeiro];

            
            primeiro = (primeiro + 1) % array.Length;

            
            return itemRemovido;
        }
    }
}