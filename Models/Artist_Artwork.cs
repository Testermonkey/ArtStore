using ArtStore.Models; // Add this using directive

namespace ArtStore.Models
{
    public class Artist_Artwork
    {
        public int ArtistId { get; set; }
        public Artist? Artist { get; set; }

        public int ArtworkId { get; set; }
        public Artwork? Artwork { get; set; }
    }
}
