using System;
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

            if (stark.Cursos.TryGetValue(int.Parse(itens[0]), out Curso curso1))
            {
                curso1.ListaOrdenada.Add(new Candidato(itens[0], int.Parse(itens[1]), int.Parse(itens[2]), int.Parse(itens[3]), int.Parse(itens[4]),
                    int.Parse(itens[5])));
            }
            else
            {
                throw new Exception("Não foi possível encontrar um curso com esse código de identifição");
            }

            if (stark.Cursos.TryGetValue(int.Parse(itens[0]), out Curso curso2))
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
                for (int i = 0; primeiroCurso.ListaOrdenada.Count >=1 && i < j; i++)
                {
                    if (primeiroCurso.ListaOrdenada[i].OpcaoDeCurso1 == codCurso)
                    {
                        primeiroCurso.Selecionados.Add(primeiroCurso.ListaOrdenada[i]);

                        if (stark.Cursos.TryGetValue(primeiroCurso.ListaOrdenada[i].OpcaoDeCurso2, out Curso segundoCurso))
                        {
                            segundoCurso.ListaOrdenada.Remove(primeiroCurso.ListaOrdenada[i]);
                            //if (segundoCurso.FilaDeEspera.Contains(primeiroCurso.ListaOrdenada[i]))
                            //{
                            //    segundoCurso.FilaDeEspera.Remove(primeiroCurso.ListaOrdenada);
                            //    ReorganizarFila(codCurso, stark)
                            //}
                            //A FilaLinear ainda não existe...

                            if (segundoCurso.Selecionados.Contains(primeiroCurso.ListaOrdenada[i]))
                            {
                                segundoCurso.Selecionados.Remove(primeiroCurso.ListaOrdenada[i]);
                                ReorganizarLista(segundoCurso);
                            }
                        }

                        primeiroCurso.ListaOrdenada.Remove(primeiroCurso.ListaOrdenada[i]);
                        i--; j--;

                    }
                    else if (primeiroCurso.ListaOrdenada[i].OpcaoDeCurso2 == codCurso)
                    {
                        primeiroCurso.Selecionados.Add(primeiroCurso.ListaOrdenada[i]);
                        primeiroCurso.ListaOrdenada.Remove(primeiroCurso.ListaOrdenada[i]);
                        i--;  j--;
                    }
                    else
                    {
                        Console.WriteLine("Houve um erro ao inserir na lista de selecionados");
                    }
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
                for (int i = 0, j = curso.QuantVagas; curso.ListaOrdenada.Count >= 1 && i < 10; i++, j++)
                {
                    //curso.FilaDeEspera.Add(curso.ListaOrdenada);
                    curso.ListaOrdenada.Remove(curso.ListaOrdenada[i]);
                }
            }
        }

        public static void ReorganizarLista(Curso curso)
        {
            //if(curso.FilaDeEspera.Count >= 1){
            //curso.Selecionados.Add(curso.FilaDeEspera.Deqeue());
            ReorganizarFIla(curso);
            //}
        }

        public static void ReorganizarFIla(Curso curso)
        {
            if (curso.ListaOrdenada.Count >= 1)
            {
                //curso.FilaDeEspera.Add(curso.ListaOrdenada[0]);
                curso.ListaOrdenada.RemoveAt(0);
            }
        }

        public static void OrdenarLista(Curso curso)
        {

        }

    }
}
