using Domain;
using System.Xml.Linq;

namespace Infra
{
    public interface ITransacaoWrite
    {        

        bool SalvarXmlEmArquivo(XElement xml, string fileName);
    }
}