using System;

namespace AplicacaoOrdenacao
{
    public class Ordenadores
    {
        public static void InsertionSort(Transacao[] v)
        {
            for (int i = 1; i < v.Length; i++)
            {
                Transacao atual = v[i];
                int j = i - 1;

                while (j >= 0 && v[j].Valor > atual.Valor)
                {
                    v[j + 1] = v[j];
                    j--;
                }

                v[j + 1] = atual;
            }
        }

        public static void MergeSort(Transacao[] v)
        {
            Transacao[] auxiliar = new Transacao[v.Length];
            MergeSort(v, auxiliar, 0, v.Length - 1);
        }

        private static void MergeSort(Transacao[] v, Transacao[] auxiliar, int inicio, int fim)
        {
            if (inicio < fim)
            {
                int meio = (inicio + fim) / 2;

                MergeSort(v, auxiliar, inicio, meio);
                MergeSort(v, auxiliar, meio + 1, fim);
                Intercalar(v, auxiliar, inicio, meio, fim);
            }
        }

        private static void Intercalar(Transacao[] v, Transacao[] auxiliar, int inicio, int meio, int fim)
        {
            for (int k = inicio; k <= fim; k++)
            {
                auxiliar[k] = v[k];
            }

            int i = inicio;
            int j = meio + 1;

            for (int k = inicio; k <= fim; k++)
            {
                if (i > meio)
                {
                    v[k] = auxiliar[j];
                    j++;
                }
                else if (j > fim)
                {
                    v[k] = auxiliar[i];
                    i++;
                }
                else if (auxiliar[i].Valor <= auxiliar[j].Valor)
                {
                    v[k] = auxiliar[i];
                    i++;
                }
                else
                {
                    v[k] = auxiliar[j];
                    j++;
                }
            }
        }

        public static void QuickSort(Transacao[] v)
        {
            QuickSort(v, 0, v.Length - 1);
        }

        private static void QuickSort(Transacao[] v, int inicio, int fim)
        {
            if (inicio < fim)
            {
                int posicaoPivo = Particionar(v, inicio, fim);

                QuickSort(v, inicio, posicaoPivo - 1);
                QuickSort(v, posicaoPivo + 1, fim);
            }
        }

        private static int Particionar(Transacao[] v, int inicio, int fim)
        {
            decimal pivo = v[fim].Valor;
            int i = inicio - 1;

            for (int j = inicio; j < fim; j++)
            {
                if (v[j].Valor <= pivo)
                {
                    i++;
                    Trocar(v, i, j);
                }
            }

            Trocar(v, i + 1, fim);
            return i + 1;
        }

        public static void HeapSort(Transacao[] v)
        {
            int n = v.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Peneirar(v, n, i);
            }

            for (int fim = n - 1; fim > 0; fim--)
            {
                Trocar(v, 0, fim);
                Peneirar(v, fim, 0);
            }
        }

        private static void Peneirar(Transacao[] v, int tamanho, int i)
        {
            while (true)
            {
                int maior = i;
                int esquerda = 2 * i + 1;
                int direita = 2 * i + 2;

                if (esquerda < tamanho && v[esquerda].Valor > v[maior].Valor)
                {
                    maior = esquerda;
                }

                if (direita < tamanho && v[direita].Valor > v[maior].Valor)
                {
                    maior = direita;
                }

                if (maior == i)
                {
                    break;
                }

                Trocar(v, i, maior);
                i = maior;
            }
        }

        private static void Trocar(Transacao[] v, int a, int b)
        {
            Transacao temp = v[a];
            v[a] = v[b];
            v[b] = temp;
        }
    }
}
