using System;
using System.Collections.Generic;
using System.Text;

namespace VoldeMoveis_CommonLib.Model
{
    [Serializable]
    public class Tinta
    {
        public int ID { get; set; }

        public string Cor { get; set; }

        public float Preco { get; set; }

        public Fornecedor Fornecedor { get; set; }
    }
}
