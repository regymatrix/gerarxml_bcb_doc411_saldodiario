using App.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App
{
    public interface IGerarXML
    {
        bool startApp();
        XElement gerarDocumento(DocumentoDTO dados);
    }
}
