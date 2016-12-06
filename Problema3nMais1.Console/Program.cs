using System;

namespace Problema3nMais1.Console
{
  class Program
  {
    static void Main(string[] args)
    {
      bool fimEntrada;
      int inicio = 0, fim = 0;
      do
      {
        fimEntrada = !int.TryParse(System.Console.ReadLine(), out inicio) ||
          !int.TryParse(System.Console.ReadLine(), out fim);
        if (!fimEntrada)
        {
          System.Console.Write(inicio + " " + fim);
          Processa(inicio, fim);          
        }        
      } while (!fimEntrada);  
    }

    private static long[] cache = new long[1000001];

    private static void Processa(int inicio, int fim)
    {
      if (inicio > fim)
      {
        Processa(fim, inicio);
        return;
      }
      
      long maior = 1;
      for (int i = inicio; i <= fim; i++)
      {
        long quantidade;
        if (cache[i] != 0)
        {
          quantidade = cache[i];
        }
        else
        {
          quantidade = Collatz2(i);
          cache[i] = quantidade;
        }        

        maior = Math.Max(maior, quantidade);
      }
      System.Console.WriteLine(" " + maior);
    }

    private static long Collatz2(long x)
    {
      if (x == 1) return 1;

      if (x <= 1000000 && cache[x] != 0)
      {
        return cache[x];
      }

      long quantidade = ProcessaParImpar(x);
      if (x <= 1000000) cache[x] = quantidade;
      return quantidade;
    }

    private static long ProcessaParImpar(long x)
    {
      if (x % 2 != 0)
      {
        long quantidade = Collatz2(3 * x + 1) + 1;
        return quantidade;
      }
      else
      {
        long quantidade = Collatz2(x / 2) + 1;
        return quantidade;
      }      
    }
  }
}
