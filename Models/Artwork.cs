using ArtStore.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ArtStore.Models
{
    public class Artwork
    {
        public int Id { get; set; }
        public string ArtworkName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ArtworkImageURL { get; set; } = string.Empty;
        public List<ArtMedium> ArtMediums { get; set; } = new List<ArtMedium>();
        public ArtType? ArtType { get; set; }

        // Relationships
        public List<Artist_Artwork> Artist_Artworks { get; set; } = new List<Artist_Artwork>();
    }
}
