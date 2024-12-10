using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalAED
{
    public class FilaLinear
    {
        internal Candidato[] array;
        private int primeiro, ultimo, count;
        public int Primeiro
        {
            get { return primeiro; } 
        }
        public int Ultimo
        {
            get { return ultimo; }
        }
        public int Count
        {
            get { return count; }
        }
        public FilaLinear()
        {
            array = new Candidato[11];
            primeiro = ultimo = count = 0;
        }
        public int GetArrayLength()
        {
            return array.Length;
        }
        public void Add(Candidato x)
        {
            if (((ultimo + 1) % array.Length) == primeiro)
                throw new Exception("Erro!");
            array[ultimo] = x;
            ultimo = (ultimo + 1) % array.Length;
            count++;
        }
        public bool Contains(Candidato candidato)
        {
            for (int i = primeiro; i != ultimo; i = (i + 1) % array.Length)
            {
                if (array[i] == candidato)
                {
                    return true;
                }
            }
            return false;
        }
        public bool Remove(Candidato candidato)
        {
            if (primeiro == ultimo)
                throw new Exception("Fila vazia!");

            int posicaoRemover = -1;

            for (int i = primeiro; i != ultimo; i = (i + 1) % array.Length)
            {
                if (array[i] != null && array[i].Equals(candidato))
                {
                    posicaoRemover = i;
                    i = ultimo;
                }
            }

            if (posicaoRemover == -1)
                return false;


            for (int i = posicaoRemover; i != ultimo; i = (i + 1) % array.Length)
            {
                int proximo = (i + 1) % array.Length;
                array[i] = array[proximo];
            }


            ultimo = (ultimo - 1 + array.Length) % array.Length;
            array[ultimo] = null;
            count--;

            return true;
        }
        public Candidato Dequeue()
        {
            if (primeiro == ultimo)
            {
                throw new Exception("Fila vazia!");
            }

            
            Candidato itemRemovido = array[primeiro];

            
            primeiro = (primeiro + 1) % array.Length;
            count--;

            return itemRemovido;
        }
    }
}