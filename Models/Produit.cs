using System.ComponentModel.DataAnnotations;

namespace tpFINAL.Models
{
    public class Produit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
