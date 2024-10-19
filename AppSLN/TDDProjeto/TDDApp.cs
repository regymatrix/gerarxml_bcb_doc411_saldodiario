using App;
using Moq;
using Infra;
using Domain;
using App.DTO;
using Domain.Servicos;

namespace TDDProjeto
{
    public class TDDApp
    {
        private readonly IGerarXML? _app;
     
        [Fact]
        public void salvarArquivo()
        {
            var mockRepoTranscao = new Mock<ITransacaoRepository>();
            var mockServicoConta = new Mock<IServicoConta>();           
            var mockApp = new AppGerarXML(mockRepoTranscao.Object,mockServicoConta.Object, new TransacaoWrite());
        

            var transacoesFake = new List<Transacao>
            {
                new Transacao { NumeroConta = "0010", Agencia = "001", Digito = "1", Valor = 100.00m, CodigoContaCosif = ContaCOSIFEnum.DepositoBancario, DataTransacao = DateTime.Parse("2023-06-01") },               
                new Transacao { NumeroConta = "0020", Agencia = "001", Digito = "1", Valor = 200.00m, CodigoContaCosif = ContaCOSIFEnum.Caixa, DataTransacao = DateTime.Parse("2023-06-01") },
                
            };

            var contasFake = new List<Conta>
            {
                new Conta { CodigoConta = "0010", SaldoDia = "100.00" },
                new Conta { CodigoConta = "0020", SaldoDia = "200.00" }
            };


            mockRepoTranscao.Setup(x => x.ObterTransacaoDoBanco()).Returns(transacoesFake).Verifiable();
            mockServicoConta.Setup(x => x.getContasAgrupadasSaldo(transacoesFake)).Returns(contasFake).Verifiable();


            var retorno = mockApp.startApp();

            Assert.True(retorno);

        }
    }
}