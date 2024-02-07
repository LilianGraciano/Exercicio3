using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
namespace EXERCICIO3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string caminhodoarquivojson = "faturamento.json";
            FaturamentoMensal faturMensal = LerFaturamentoJson(caminhodoarquivojson);

            decimal menorValor = faturMensal.Faturamento.Min();
            decimal maiorValor = faturMensal.Faturamento.Max();
            decimal mediaMensal = faturMensal.Faturamento.Average();
            int diasAcimaDaMedia = faturMensal.Faturamento.Count(valor => valor > mediaMensal);

          
            Console.WriteLine($"Menor valor de faturamento: {menorValor}");
            Console.WriteLine($"Maior valor de faturamento: {maiorValor}");
            Console.WriteLine($"Número de dias com faturamento acima da média mensal: {diasAcimaDaMedia}");
        }

        static FaturamentoMensal LerFaturamentoJson(string caminhoDoArquivo)
        {
            using (StreamReader r = new StreamReader(caminhoDoArquivo))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<FaturamentoMensal>(json);
            }
        }
    }

    class FaturamentoMensal
    {
        public decimal[] Faturamento { get; set; }
    }
}
