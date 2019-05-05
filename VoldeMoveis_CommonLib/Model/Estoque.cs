using System;
using System.Collections.Generic;
using System.Text;

namespace VoldeMoveis_CommonLib.Model
{
    [Serializable]
    public class Estoque
    {
        public int ID { get; set; }

        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
    }
}
