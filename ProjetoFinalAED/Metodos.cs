using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalAED
{
    internal static class Metodos
    {
        public static void AdicionarNaListaGeral(string frase, Universidade stark)
        {
            string[] itens = frase.Split(";");

            if (stark.Cursos.TryGetValue(int.Parse(itens[4]), out Curso curso1))   // --- ATENÇÂO --- O método TryGetValue manda como referência a key a ser procurada e retorna com o out o value dessa chave. 
            {
                curso1.ListaOrdenada.Add(new Candidato(itens[0], int.Parse(itens[1]), int.Parse(itens[2]), int.Parse(itens[3]), int.Parse(itens[4]),
                    int.Parse(itens[5])));
            }
            else
            {
                throw new Exception("Não foi possível encontrar um curso com esse código de identifição");
            }

            if (stark.Cursos.TryGetValue(int.Parse(itens[5]), out Curso curso2))
            {
                curso2.ListaOrdenada.Add(new Candidato(itens[0], int.Parse(itens[1]), int.Parse(itens[2]), int.Parse(itens[3]), int.Parse(itens[4]),
                    int.Parse(itens[5])));
            }
            else
            {
                throw new Exception("Não foi possível encontrar um curso com esse código de identifição");
            }

        }
        public static void AdicionarNoDicionario(string frase, Universidade stark)
        {
            try
            {
                string[] itens = frase.Split(";");
                stark.Cursos.Add(int.Parse(itens[0]), new Curso(itens[1], int.Parse(itens[2])));
            }
            catch (Exception err)
            {
                Console.WriteLine($"Erro ao adicionar no Dicionario: {err}");
            }
        }

        public static void InserirNaListaSelecionados(int codCurso, Universidade stark)
        {
            if (stark.Cursos.TryGetValue(codCurso, out Curso primeiroCurso))
            {
                int j = primeiroCurso.QuantVagas;
                for (int i = 0; primeiroCurso.ListaOrdenada.Count >= 1 && i < j; j--)
                {
                    var aluno = primeiroCurso.ListaOrdenada[i];
                    if (aluno.OpcaoDeCurso1 == codCurso)
                    {
                        primeiroCurso.Selecionados.Add(aluno);

                        if (stark.Cursos.TryGetValue(aluno.OpcaoDeCurso2, out Curso segundoCurso))
                        {
                            segundoCurso.ListaOrdenada.Remove(aluno);
                            //if (segundoCurso.FilaDeEspera.Contains(aluno))
                            //{
                            //    segundoCurso.FilaDeEspera.Remove(aluno);
                            //    ReorganizarFila(codCurso, stark)
                            //}
                            //A FilaLinear ainda não existe...

                            if (segundoCurso.Selecionados.Contains(aluno))
                            {
                                segundoCurso.Selecionados.Remove(aluno);
                                ReorganizarLista(segundoCurso);
                            }
                        }

                    }
                    else if (aluno.OpcaoDeCurso2 == codCurso)
                    {
                        primeiroCurso.Selecionados.Add(aluno);
                        j--;
                    }
                    else
                    {
                        Console.WriteLine("Houve um erro ao inserir na lista de selecionados");
                    }

                    primeiroCurso.ListaOrdenada.Remove(aluno);
                }
            }
            else
            {
                Console.WriteLine("Não foi possível encontrar um curso com esse código de identifição");
            }
        }
        public static void InserirNaFilaDeEspera(int codCurso, Universidade stark)
        {
            if (stark.Cursos.TryGetValue(codCurso, out Curso curso))
            {
                for (int i = 0; curso.ListaOrdenada[i] != null && i < 10; i++)
                {
                    //curso.FilaDeEspera.Add(curso.ListaOrdenada[i]);
                    curso.ListaOrdenada.Remove(curso.ListaOrdenada[i]);
                }
            }
        }

        public static void ReorganizarLista(Curso curso)
        {
            //if(curso.FilaDeEspera.Count >= 1){
            //curso.Selecionados.Add(curso.FilaDeEspera.Dequeue());     //Recebe o retorno da remoção da fila de espera e adiciona.
            ReorganizarFIla(curso);
            //}
        }

        public static void ReorganizarFIla(Curso curso)
        {
            if (curso.ListaOrdenada.Count >= 1)
            {
                //curso.FilaDeEspera.Add(curso.ListaOrdenada[0]);      //Adiciona a primeira posição da lista de espera
                curso.ListaOrdenada.RemoveAt(0);
            }
        }
        public static void OrdenarLista(int codCurso, Universidade stark)
        {
            if (stark.Cursos.TryGetValue(codCurso, out Curso curso))
            {
                curso.ListaOrdenada = MergeSort(MergeSort(MergeSort(curso.ListaOrdenada, 1), 2), 3);
            }

        }
        public static List<Candidato> MergeSort(List<Candidato> lista, int op)
        {
            if (lista.Count <= 1)
                return lista;

            int mid = lista.Count / 2;
            List<Candidato> esq = MergeSort(lista.GetRange(0, mid), op);
            List<Candidato> dir = MergeSort(lista.GetRange(mid, lista.Count - mid), op);

            return Intercala(esq, dir, op);
        }
        public static List<Candidato> Intercala(List<Candidato> esq, List<Candidato> dir, int op)
        {
            List<Candidato> candidatos = new List<Candidato>();
            int i = 0, j = 0;
            double notaEsq, notaDir;
            while (i < esq.Count && j < dir.Count)
            {
                if (op == 1)
                {
                    notaEsq = esq[i].Matematica;
                    notaDir = dir[j].Matematica;
                }
                else if (op == 2)
                {
                    notaEsq = esq[i].Redacao;
                    notaDir = dir[j].Redacao;
                }
                else
                {
                    notaEsq = esq[i].Media;
                    notaDir = dir[j].Media;
                }
                if (notaEsq >= notaDir)
                {
                    candidatos.Add(esq[i]);
                    i++;
                }
                else
                {
                    candidatos.Add(dir[j]);
                    j++;
                }
            }
            candidatos.AddRange(esq.GetRange(i, esq.Count - i));
            candidatos.AddRange(dir.GetRange(j, dir.Count - j));
            return candidatos;
        }
    }
}
