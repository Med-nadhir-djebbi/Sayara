using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tpFINAL.Models
{
    public class PanierParUser
    {
        public Guid Id { get; set; }
        public string UserID { get; set; }
        public Guid ProduitId { get; set; }
        public List<Produit> produits { get; set; }
    }
}
