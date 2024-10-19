using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class ServicoConta : IServicoConta
    {

        public List<Conta> getContasAgrupadasSaldo(List<Transacao> transacoes)
        {
            var agrupamentos = transacoes
             .GroupBy(t => new { t.CodigoContaCosif })
             .Select(g => new Conta()
             {
                 CodigoConta = ((int)g.Key.CodigoContaCosif).ToString(),
                 SaldoDia = g.Sum(t => t.Valor).ToString("F2")
             }).ToList();

            return agrupamentos;
        }
    }
}
