using System;
using System.Collections.Generic;

namespace ProjetoFinalAED
{
    internal static class Metodos
    {
        public static void AdicionarNaListaGeral(string frase, Universidade stark)
        {
            string[] itens = frase.Split(";");

            if (stark.Cursos.TryGetValue(int.Parse(itens[4]), out Curso curso1))
            {
                curso1.ListaOrdenada.Add(new Candidato(itens[0], double.Parse(itens[1]), double.Parse(itens[2]), double.Parse(itens[3]), int.Parse(itens[4]),
                    int.Parse(itens[5])));
            }
            else
            {
                Console.WriteLine("Houve um erro ao inserir na lista de selecionados");
            }

            if (stark.Cursos.TryGetValue(int.Parse(itens[5]), out Curso curso2))
            {
                curso2.ListaOrdenada.Add(new Candidato(itens[0], double.Parse(itens[1]), double.Parse(itens[2]), double.Parse(itens[3]), int.Parse(itens[4]),
                    int.Parse(itens[5])));
            }
            else
            {
                Console.WriteLine("Houve um erro ao inserir na lista de selecionados");
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
                Console.WriteLine($"Erro ao adicionar no Dicionário: {err}");
            }
        }

        public static void InserirNaListaSelecionados(int codCurso, Universidade stark)
        {
            if (stark.Cursos.TryGetValue(codCurso, out Curso primeiroCurso))
            {

                for (int j = primeiroCurso.QuantVagas; primeiroCurso.ListaOrdenada.Count >= 1 && j > 0; j--)
                {
                    var candidato = primeiroCurso.ListaOrdenada[0];
                    if (candidato.OpcaoDeCurso1 == codCurso)
                    {
                        primeiroCurso.Selecionados.Add(candidato);

                        if (stark.Cursos.TryGetValue(candidato.OpcaoDeCurso2, out Curso segundoCurso))
                            DeletarSegundoCurso(candidato, segundoCurso, stark);
                    }
                    else if (candidato.OpcaoDeCurso2 == codCurso)
                    {
                        primeiroCurso.Selecionados.Add(candidato);
                    }
                    else
                    {
                        Console.WriteLine("Houve um erro ao inserir na lista de selecionados");
                    }

                    primeiroCurso.ListaOrdenada.Remove(candidato);
                }
            }
            else
            {
                Console.WriteLine("Não foi possível encontrar um curso com esse código de identificação");
            }
        }
        public static void DeletarSegundoCurso(Candidato candidato, Curso segundoCurso, Universidade stark)
        {
            if (segundoCurso.ListaOrdenada.Contains(candidato))
            {
                segundoCurso.ListaOrdenada.Remove(candidato);
            }

            if (segundoCurso.Selecionados.Contains(candidato))
            {
                segundoCurso.Selecionados.Remove(candidato);
                ReorganizarLista(segundoCurso, stark);
            }

            if (segundoCurso.FilaDeEspera.Contains(candidato))
            {
                segundoCurso.FilaDeEspera.Remove(candidato);
            }
        }

        public static void ReorganizarLista(Curso curso, Universidade stark)
        {
            if (curso.FilaDeEspera.Count >= 1)
            {
                Candidato candidato = curso.FilaDeEspera.Dequeue();
                curso.Selecionados.Add(candidato);
                if (stark.Cursos.TryGetValue(candidato.OpcaoDeCurso1, out Curso primeiroCurso))
                {
                    if (primeiroCurso == curso)
                    {
                        if (stark.Cursos.TryGetValue(candidato.OpcaoDeCurso2, out Curso segundoCurso))
                        {
                            DeletarSegundoCurso(candidato, segundoCurso, stark);
                        }
                    }
                    
                }
                ReorganizarFIla(curso);
            }
        }

        public static void ReorganizarFIla(Curso curso)
        {
            if (curso.ListaOrdenada.Count >= 1)
            {
                curso.FilaDeEspera.Add(curso.ListaOrdenada[0]);
                curso.ListaOrdenada.RemoveAt(0);
            }
        }
        public static void InserirNaFilaDeEspera(int codCurso, Universidade stark)
        {
            if (stark.Cursos.TryGetValue(codCurso, out Curso curso))
            {
                for (int i = 0; curso.ListaOrdenada.Count > i && i < 10; i++)
                {
                    curso.FilaDeEspera.Add(curso.ListaOrdenada[i]);
                    curso.ListaOrdenada.Remove(curso.ListaOrdenada[i]);
                }
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
                notaEsq = op == 1 ? esq[i].Matematica : (op == 2 ? esq[i].Redacao : esq[i].Media);
                notaDir = op == 1 ? dir[j].Matematica : (op == 2 ? dir[j].Redacao : dir[j].Media);

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

