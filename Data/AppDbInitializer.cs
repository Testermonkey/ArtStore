using ArtStore.Models;
using ArtStore.Data.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace ArtStore.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                // List of artists and their details
                var artists = new List<(string FirstName, string LastName, string ArtistName, string Address1, string Address2, string City, string State, string PostalCode, string PhoneNumber, string Biography, string BioPictureUrl)>
                {
                    ("Leann", "Underwood", "Arden Art", "456 Art Ave.", "Suite 5D", "Creative City", "NY", "54321", "987-654-3210", "An Encaustic artist with a focus on modern shapes and colors.", "http://example.com/leannbio.jpg"),
                    ("John", "Doe", "John Doe Art", "789 Creative Rd.", "Studio 3", "Artville", "CA", "90210", "123-555-9876", "Acrylic artist specializing in surreal landscapes.", "http://example.com/johndoebio.jpg"),
                    ("Emily", "Smith", "E. Smith Creations", "321 Ocean Blvd.", "Apt 2A", "Sunny Beach", "FL", "33111", "555-123-4567", "Mixed media artist exploring the concept of time and change.", "http://example.com/emilysmithbio.jpg"),
                    ("David", "Jones", "D. Jones Sculpture", "987 Sculptor St.", "Floor 4", "Metal City", "TX", "75001", "888-999-4444", "Sculptor who blends modernism with classical techniques.", "http://example.com/davidjonesbio.jpg"),
                    ("Olivia", "Brown", "Olivia's Canvas", "123 Artistry Ln.", "Suite 7", "Artist Town", "WA", "98001", "111-222-3333", "Watercolor artist known for delicate and ethereal designs.", "http://example.com/oliviabrownbio.jpg"),
                    ("Mark", "Taylor", "Mark's Masterpieces", "555 Gallery St.", "Unit 9", "Creative Bay", "OR", "97001", "555-777-8888", "Abstract painter with a passion for bold, expressive color.", "http://example.com/marktaylorbio.jpg")
                };

                // Loop through the artists and add them if they don't already exist
                foreach (var artistDetails in artists)
                {
                    if (!context.Artists.Any(a => a.ArtistName == artistDetails.ArtistName || (a.FirstName == artistDetails.FirstName && a.LastName == artistDetails.LastName)))
                    {
                        context.Artists.Add(new Artist()
                        {
                            FirstName = artistDetails.FirstName,
                            LastName = artistDetails.LastName,
                            ArtistName = artistDetails.ArtistName,
                            Address1 = artistDetails.Address1,
                            Address2 = artistDetails.Address1,
                            City = artistDetails.City,
                            State = artistDetails.State,
                            PostalCode = artistDetails.PostalCode,
                            PhoneNumber = artistDetails.PhoneNumber,
                            Biography = artistDetails.Biography,
                            BioPictureURL = artistDetails.BioPictureUrl
                        });
                        context.SaveChanges();  // Save to get ArtistId
                    }

                    // Get the artist to add artworks
                    var artist = context.Artists.FirstOrDefault(a => a.ArtistName == artistDetails.ArtistName);

                    if (artist != null)
                    {
                        // Define artworks for each artist
                        var artworks = new List<(string Name, string Description, decimal Price, ArtMedium Medium, ArtType Type)>
                        {
                            ("Surreal Dreamscape", "Acrylic painting with surreal elements", 200.00M, ArtMedium.Acrylic, ArtType.Wall_Hanging),
                            ("Evolving Time", "Mixed media artwork showing the passage of time", 180.00M, ArtMedium.Paper, ArtType.Wall_Hanging),
                            ("Modern Elegance", "Sculpture combining classical and modern styles", 250.00M, ArtMedium.Metal, ArtType.Sculpture),
                            ("Soft Whispers", "Watercolor painting with an ethereal feel", 100.00M, ArtMedium.Watercolor, ArtType.Wall_Hanging),
                            ("Timeless Beauty", "Abstract expressionist painting depicting nature", 220.00M, ArtMedium.Oil, ArtType.Wall_Hanging)
                        };

                        // Loop through the artworks list and associate them with the artist
                        foreach (var artwork in artworks)
                        {
                            context.Artworks.Add(new Artwork()
                            {
                                Name = artwork.Name,
                                Description = artwork.Description,
                                Price = artwork.Price,
                                ArtMediums = new List<ArtMedium> { artwork.Medium },
                                ArtType = artwork.Type,
                                ArtistId = artist.Id  // Link the artwork to the artist using ArtistId
                            });
                        }
                    }
                }

                context.SaveChanges(); // Persist changes to the database
            }
        }
    }
}
