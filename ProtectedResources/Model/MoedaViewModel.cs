using System.Collections.Generic;

namespace ProtectedResources.Model
{
    public class MoedaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Simbolo { get; set; }
        public int Rank { get; set; }   
        public decimal Preco { get; set; }
    }

    public class ListaMoedas
    {
        public IEnumerable<Moeda> data { get; set; }
    }


    public class Cotacao
    {
        public decimal price { get; set; }
    }
    public class ListaCotacao
    {
        public Dictionary<string, Cotacao> quotes { get; set; }
    }

    public class Moeda
    {
        public int id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public int cmc_rank { get; set; }
        public Dictionary<string, Cotacao> quote { get; set; }
    }
}
