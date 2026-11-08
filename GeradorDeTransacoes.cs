using System;

namespace AplicacaoOrdenacao
{
    public class GeradorDeTransacoes
    {
        public static Transacao[] Gerar(int n)
        {
            Random aleatorio = new Random(42);
            string[] listaStatus = { "Pendente", "Aprovada", "Recusada", "Estornada" };

            Transacao[] transacoes = new Transacao[n];

            for (int i = 0; i < n; i++)
            {
                decimal valor = aleatorio.Next(1, 100000000) / 100m;

                DateTime data = DateTime.Today.AddSeconds(aleatorio.Next(0, 86400));

                string status = listaStatus[aleatorio.Next(listaStatus.Length)];

                transacoes[i] = new Transacao(i + 1, valor, data, status);
            }

            return transacoes;
        }
    }
}
