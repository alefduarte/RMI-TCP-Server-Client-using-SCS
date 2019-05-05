using System;
using System.Collections.Generic;
using System.Text;

namespace VoldeMoveis_CommonLib.Model
{
    [Serializable]
    public class Madeira
    {
        public int ID { get; set; }
        
        public string tipo { get; set; }

        public float preco { get; set; }

        public Fornecedor Fornecedor { get; set; }
    }
}
