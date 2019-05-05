using System;

namespace VoldeMoveis_CommonLib.Model
{
    [Serializable]
    public class Venda
    {
        public int ID { get; set; }

        public Produto Produto { get; set; }

        public float Preco { get; set; }
    }
}
