using App.DTO;
using Domain;
using Infra;
using System.IO.Pipes;
using System.Xml.Linq;

namespace App
{
    public class AppGerarXML : IGerarXML
    {
        private ITransacaoRepository _repositorio;
        private IServicoConta _serviceConta;        
        private ITransacaoWrite _transacaoWrite;
        public AppGerarXML(ITransacaoRepository pRepo, IServicoConta  servico, ITransacaoWrite write )
        {
             _repositorio = pRepo;
            _serviceConta = servico;
            _transacaoWrite = write;
        }

    
        public bool startApp()
        {
            try
            {
                var transacoes = _repositorio.ObterTransacaoDoBanco();
                var contas = _serviceConta.getContasAgrupadasSaldo(transacoes);
                var dados = new DocumentoDTO()
                {
                    contas = contas,
                    codigoDocumento = "4111",
                    cnpj = "09062773000177",
                    dataBase = "2024-10-19",
                    tipoRemessa = "I"
                };


                var xml = gerarDocumento(dados);

                var retorno = _transacaoWrite.SalvarXmlEmArquivo(xml, dados.dataBase + ".xml");
                return retorno;
            }
            catch (Exception ex)
            { 
             
                return false;
            }

        }

        public XElement gerarDocumento(DocumentoDTO dados)
        {
            var documento = new XElement("documento",
            new XAttribute("codigoDocumento", dados.codigoDocumento),
            new XAttribute("cnpj", dados.cnpj),
            new XAttribute("dataBase", dados.dataBase),
            new XAttribute("tipoRemessa", dados.tipoRemessa),
            new XElement("contas",
                  from g in dados.contas
                  select new XElement("conta",
                      new XAttribute("codigoConta", g.CodigoConta),
                      new XAttribute("saldoDia", g.SaldoDia)
                  )
             )
        );

            return documento;
        }

    }
}