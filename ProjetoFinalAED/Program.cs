

namespace ProjetoFinalAED
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Universidade stark = new Universidade();
            string linha;
            int forCursos = 0, forAlunos = 0;
            try
            {
                StreamReader entrada = new StreamReader("entrada.txt");
                linha = entrada.ReadLine();

                string[] numerosFor = linha.Split(";");

                forCursos = int.Parse(numerosFor[0]);
                forAlunos = int.Parse(numerosFor[1]);

                for (int i = 0; i < forCursos; i++)
                {
                    linha = entrada.ReadLine();
                    Metodos.AdicionarNoDicionario(linha, stark);
                }

                for (int i = 0; i < forAlunos; i++)
                {
                    linha = entrada.ReadLine();
                    Metodos.AdicionarNaListaGeral(linha, stark);
                }

                entrada.Close();
            }
            catch (Exception err)
            {
                Console.WriteLine($"Erro ao ler o arquivo: {err}");
            }
            
            for (int i = 1; i <= forCursos; i++)
            {
                Metodos.OrdenarLista(i, stark);
                Metodos.InserirNaListaSelecionados(i, stark);
                Metodos.InserirNaFilaDeEspera(i, stark);
            }


            try
            {
                StreamWriter saida = new StreamWriter("saida.txt");

                foreach(var curso in stark.Cursos)
                {
                    saida.WriteLine(curso.Value);
                    saida.WriteLine("Selecionados");
                    foreach (var candidato in curso.Value.Selecionados)
                    {
                        saida.WriteLine(candidato);
                    }

                    saida.WriteLine("Fila de Espera");

                    var fila = curso.Value.FilaDeEspera;

                    for (int i = fila.Primeiro; i != fila.Ultimo; i = (i + 1) % fila.GetArrayLength())
                    {
                        saida.WriteLine(fila.array[i]);
                    }
                    saida.WriteLine();
                }

                saida.Close();
            }
            catch (Exception err)
            {
                Console.WriteLine($"Erro ao escrever o arquivo: {err}");
            }


        }
    }
}
