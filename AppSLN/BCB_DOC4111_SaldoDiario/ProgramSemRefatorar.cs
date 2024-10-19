using System;
using System.Xml.Linq;

namespace BCB_DOC4111_SaldoDiario // Note: actual namespace depends on the project name.
{
    internal class ProgramSemRefatorar
    {
        static void Main(string[] args)
        {
            var transacoes = Transacao.ObterTransacaoDoBanco();

            var xml = GerarXml(transacoes, "4111", "12345678", DateTime.Now.ToString("yyyy-MM-dd"), "S");

            Console.WriteLine(xml);
            string fileName = $"{DateTime.Now.ToString("yyyy-MM-dd")}_4111.xml";
            SalvarXmlEmArquivo(xml, fileName);
        }

        static XElement GerarXml(List<Transacao> transacoes, string codigoDocumento, string cnpj, string dataBase, string tipoRemessa)
        {
            // Agrupa as transações por CodigoContaCosif e DataTransacao
            var agrupamentos = transacoes
                .GroupBy(t => new { t.CodigoContaCosif, t.DataTransacao })
                .Select(g => new
                {
                    CodigoConta = ((int)g.Key.CodigoContaCosif).ToString(),
                    SaldoDia = g.Sum(t => t.Valor).ToString("F2")
                }).ToList();

            var documento = new XElement("documento",
                new XAttribute("codigoDocumento", codigoDocumento),
                new XAttribute("cnpj", cnpj),
                new XAttribute("dataBase", dataBase),
                new XAttribute("tipoRemessa", tipoRemessa),
                new XElement("contas",
                    from g in agrupamentos
                    select new XElement("conta",
                        new XAttribute("codigoConta", g.CodigoConta),
                        new XAttribute("saldoDia", g.SaldoDia)
                    )
                )
            );

            return documento;
        }

        static void SalvarXmlEmArquivo(XElement xml, string fileName)
        {
            // Salva o arquivo no sistema de arquivos
            xml.Save(fileName);
        }

    }

    public enum CodigoContaCosif
    {
        Disponibilidade = 1100000002,
        Caixa = 1110000009,
        DepositoBancario = 1120000006
    }

    public class Transacao
    {
        public int ID { get; set; }
        public string NumeroConta { get; set; }
        public string Agencia { get; set; }
        public string Digito { get; set; }
        public decimal Valor { get; set; }
        public CodigoContaCosif CodigoContaCosif { get; set; }
        public DateTime DataTransacao { get; set; }

        public static List<Transacao> ObterTransacaoDoBanco()
        {
            // Simulação de dados do banco. Em um caso real, use ADO.NET ou Entity Framework para obter os dados.
            return new List<Transacao>
            {
                new Transacao { NumeroConta = "1234567890", Agencia = "001", Digito = "1", Valor = 1000.50m, CodigoContaCosif = CodigoContaCosif.Disponibilidade, DataTransacao = DateTime.Parse("2023-06-01") },
                new Transacao { NumeroConta = "1234567891", Agencia = "001", Digito = "1", Valor = 1500.75m, CodigoContaCosif = CodigoContaCosif.Caixa, DataTransacao = DateTime.Parse("2023-06-01") },
                // Mais transações...
            };
        }
    }







}