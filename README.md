# Aplicação Prática: Ordenação de Transações (C#)

Programa simples que:

1. gera `n` transações aleatórias (ID, valor, data e status);
2. ordena por **valor crescente** com Insertion Sort, Merge Sort e Quick Sort (e Heap Sort, extra);
3. mede o tempo de cada um com `Stopwatch`;
4. mostra as **10 maiores transações**.

## Como executar

Precisa do [.NET SDK](https://dotnet.microsoft.com/download) (o projeto usa `net8.0`; se você tiver outra versão, troque no arquivo `.csproj`).

```bash
dotnet run -c Release
```

Use sempre `-c Release`. No modo Debug os tempos ficam bem maiores e distorcidos.

## Arquivos

| Arquivo | O que tem |
|---|---|
| `Transacao.cs` | A classe `Transacao` (Id, Valor, Data, Status) |
| `GeradorDeTransacoes.cs` | Gera o array com `n` transações aleatórias |
| `Ordenadores.cs` | Os quatro algoritmos, todos usando `Valor` como chave |
| `Program.cs` | Roda os testes para cada `n`, mede os tempos e mostra o Top 10 |

## Detalhes importantes

- **Clonar o array:** antes de cada ordenação usamos `Clone()`, para todos os algoritmos começarem do mesmo conjunto desordenado. A clonagem não entra no tempo medido.
- **10 maiores:** depois de ordenar em ordem crescente, os 10 últimos elementos são os maiores.
- **Insertion Sort:** é O(n²). Para n acima de 100.000 o programa não o executa, porque levaria horas ou dias. É só mudar `limiteInsertion` no `Program.cs` se quiser testar.
- **Memória:** com n = 100.000.000 o programa precisa de vários GB de RAM. Se der erro ou faltar memória, apague os maiores valores da lista `tamanhos` no `Program.cs`.
- **Quick Sort:** usa o último elemento como pivô (partição de Lomuto). Com dados aleatórios funciona muito bem; com dados já ordenados ele cai no pior caso, O(n²).

## Complexidades

| Algoritmo | Melhor | Médio | Pior | Memória extra | Estável |
|---|---|---|---|---|---|
| Insertion Sort | O(n) | O(n²) | O(n²) | O(1) | Sim |
| Merge Sort | O(n log n) | O(n log n) | O(n log n) | O(n) | Sim |
| Quick Sort | O(n log n) | O(n log n) | O(n²) | O(log n) | Não |
| Heap Sort | O(n log n) | O(n log n) | O(n log n) | O(1) | Não |
