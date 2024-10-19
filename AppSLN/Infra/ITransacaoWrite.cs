using Domain;
using System.Xml.Linq;

namespace Infra
{
    public interface ITransacaoRepository
    {
        List<Transacao> ObterTransacaoDoBanco();
        
    }
}