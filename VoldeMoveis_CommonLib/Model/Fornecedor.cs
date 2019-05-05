using System;
using System.Collections.Generic;
using System.Text;

namespace VoldeMoveis_CommonLib.Model
{
    [Serializable]
    public class Fornecedor
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Cnpj { get; set; }

        public string Telefone { get; set; }
    }
}
