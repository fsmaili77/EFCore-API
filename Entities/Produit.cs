using System.ComponentModel.DataAnnotations;

namespace efCoreApi.Entities
{
    public class Produit
    {
        // Identifiant du produit (clé primaire)
        [Key]
        public int Id { get; set; }

        // Nom du produit
        public string? Nom { get; set; }

        // Prix du produit
        public decimal Prix { get; set; }
    }
}
