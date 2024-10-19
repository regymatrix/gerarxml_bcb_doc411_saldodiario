using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Infra
{
    public class TransacaoRepository : ITransacaoRepository
    {
        public List<Transacao> ObterTransacaoDoBanco()
        {
            return new List<Transacao>
            {
                new Transacao { NumeroConta = "1234567890", Agencia = "001", Digito = "1", Valor = 1000.50m, CodigoContaCosif = ContaCOSIFEnum.Disponibilidade, DataTransacao = DateTime.Parse("2023-06-01") },
                new Transacao { NumeroConta = "1234567890", Agencia = "001", Digito = "1", Valor = 1000.50m, CodigoContaCosif = ContaCOSIFEnum.Disponibilidade, DataTransacao = DateTime.Parse("2023-06-02") },
                new Transacao { NumeroConta = "1234567891", Agencia = "001", Digito = "1", Valor = 1500.75m, CodigoContaCosif = ContaCOSIFEnum.Caixa, DataTransacao = DateTime.Parse("2023-06-01") },
                // Mais transações...
            };
        }

        public bool SalvarXmlEmArquivo(XElement xml, string fileName)
        {
            try
            {                        
                xml.Save(fileName);
                return true;
            }
            catch (Exception  ex)
            {
                var erro = ex.Message;
                return false;
            }

         
        }
    }
}
