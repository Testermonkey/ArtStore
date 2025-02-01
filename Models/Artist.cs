using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ArtStore.Models
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;
        [Display(Name = "Artist Name")]
        public string ArtistName { get; set; } = string.Empty;
        public string Address1 { get; set; } = string.Empty;
        public string Address2 { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        [Display(Name ="Biography")]
        public string Biography { get; set; } = string.Empty;
        [Display(Name = "Profile Picture")]
        public string BioPictureURL { get; set; } = string.Empty;

        // Relationships
        public List<Artist_Artwork> Artist_Artworks { get; set; }

    }
}

