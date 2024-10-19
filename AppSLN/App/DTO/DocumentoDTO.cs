using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DTO
{
    public class DocumentoDTO
    {
        public List<Conta> contas { get; set; }
        public string codigoDocumento { get; set; }

        public string cnpj { get; set; }

        public string dataBase { get; set; }

        public string tipoRemessa { get; set; }
    }
}
