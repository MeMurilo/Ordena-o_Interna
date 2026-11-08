using System;
using System.Diagnostics;

namespace AplicacaoOrdenacao
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tamanhos = { 100, 1000, 10000, 100000, 1000000, 10000000, 100000000 };

            int limiteInsertion = 100000;

            Aquecer();

            foreach (int n in tamanhos)
            {
                Console.WriteLine();
                Console.WriteLine("===== n = " + n + " =====");

                Transacao[] original;
                try
                {
                    original = GeradorDeTransacoes.Gerar(n);
                }
                catch (OutOfMemoryException)
                {
                    Console.WriteLine("Sem memória para gerar este dataset. Fim do teste.");
                    break;
                }

                if (n <= limiteInsertion)
                {
                    Transacao[] copia = (Transacao[])original.Clone();

                    Stopwatch cronometro = Stopwatch.StartNew();
                    Ordenadores.InsertionSort(copia);
                    cronometro.Stop();

                    MostrarTempo("Insertion Sort", cronometro, copia);
                }
                else
                {
                    Console.WriteLine("Insertion Sort: não executado (muito lento para este n)");
                }

                Transacao[] copiaMerge = (Transacao[])original.Clone();

                Stopwatch cronometroMerge = Stopwatch.StartNew();
                Ordenadores.MergeSort(copiaMerge);
                cronometroMerge.Stop();

                MostrarTempo("Merge Sort", cronometroMerge, copiaMerge);

                Transacao[] copiaQuick = (Transacao[])original.Clone();

                Stopwatch cronometroQuick = Stopwatch.StartNew();
                Ordenadores.QuickSort(copiaQuick);
                cronometroQuick.Stop();

                MostrarTempo("Quick Sort", cronometroQuick, copiaQuick);

                Transacao[] copiaHeap = (Transacao[])original.Clone();

                Stopwatch cronometroHeap = Stopwatch.StartNew();
                Ordenadores.HeapSort(copiaHeap);
                cronometroHeap.Stop();

                MostrarTempo("Heap Sort", cronometroHeap, copiaHeap);

                Console.WriteLine();
                Console.WriteLine("10 maiores transações:");
                for (int i = 0; i < 10; i++)
                {
                    Transacao t = copiaQuick[copiaQuick.Length - 1 - i];
                    Console.WriteLine((i + 1) + ". " + t);
                }
            }
        }

        static void MostrarTempo(string nome, Stopwatch cronometro, Transacao[] v)
        {
            string tempo = cronometro.Elapsed.TotalMilliseconds.ToString("F3");
            string ordenado = EstaOrdenado(v) ? "ordenado" : "ERRO: NÃO ORDENADO";
            Console.WriteLine(nome + ": " + tempo + " ms (" + ordenado + ")");
        }

        static bool EstaOrdenado(Transacao[] v)
        {
            for (int i = 1; i < v.Length; i++)
            {
                if (v[i - 1].Valor > v[i].Valor)
                {
                    return false;
                }
            }
            return true;
        }

        static void Aquecer()
        {
            Transacao[] pequeno = GeradorDeTransacoes.Gerar(1000);
            Ordenadores.InsertionSort((Transacao[])pequeno.Clone());
            Ordenadores.MergeSort((Transacao[])pequeno.Clone());
            Ordenadores.QuickSort((Transacao[])pequeno.Clone());
            Ordenadores.HeapSort((Transacao[])pequeno.Clone());
        }
    }
}
