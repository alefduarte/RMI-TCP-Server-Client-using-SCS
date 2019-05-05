using System;
using System.Collections.Generic;
using System.Text;

namespace VoldeMoveis_CommonLib.Model
{
    [Serializable]
    public class Produto
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        public float Preco { get; set; }

        public float Altura { get; set; }

        public float Largura { get; set; }

        public float Espessura { get; set; }

        public int Quantidade { get; set; }

        public Madeira Madeira { get; set; }

        public Tinta Tinta { get; set; }

    }
}
