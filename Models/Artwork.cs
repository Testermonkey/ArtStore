using ArtStore.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ArtStore.Models
{
    public class Artwork
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public List<ArtMedium> ArtMediums { get; set; } = new List<ArtMedium>();
        public ArtType? ArtType { get; set; }

        // Relationships
        public List<Artist_Artwork> Artist_Artworks { get; set; } = new List<Artist_Artwork>();

        
        public int ArtistId { get; set; }
        public Artist? Artist { get; set; }
    }
}
