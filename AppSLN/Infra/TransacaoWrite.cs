using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Infra
{
    public class TransacaoWrite : ITransacaoWrite
    {
      
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
