using ArtStore.Data;
using ArtStore.Data.Enums;
using ArtStore.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbInitializer
{
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();

            // Seed Artists if they don't already exist
            if (!context.Artists.Any())
            {
                var artists = new List<Artist>
                {
                    new Artist
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        ArtistName = "John Doe Art",
                        Address1 = "123 Art St",
                        City = "Art City",
                        State = "Art State",
                        PostalCode = "12345",
                        PhoneNumber = "123-456-7890",
                        Biography = "A brief biography of John Doe.",
                        BioPictureURL = "https://some-url-to-picture.com/john_doe.jpg"
                    },
                    new Artist
                    {
                        FirstName = "Jane",
                        LastName = "Smith",
                        ArtistName = "Jane Smith Art",
                        Address1 = "456 Art Ave",
                        City = "Art Town",
                        State = "Art State",
                        PostalCode = "67890",
                        PhoneNumber = "987-654-3210",
                        Biography = "A brief biography of Jane Smith.",
                        BioPictureURL = "https://some-url-to-picture.com/jane_smith.jpg"
                    }
                };

                context.Artists.AddRange(artists);
                context.SaveChanges(); // Save artists to get their IDs

                // Seed Artworks
                var artworks = new List<Artwork>
                {
                    new Artwork { ArtworkName = "Art1", Description = "Description of Art1", Price = 100.00m, ArtMediums = new List<ArtMedium> { ArtMedium.Oil }, ArtType = ArtType.Painting },
                    new Artwork { ArtworkName = "Art2", Description = "Description of Art2", Price = 150.00m, ArtMediums = new List<ArtMedium> { ArtMedium.Acrylic }, ArtType = ArtType.Wall_Hanging },
                    new Artwork { ArtworkName = "Art3", Description = "Description of Art3", Price = 120.00m, ArtMediums = new List<ArtMedium> { ArtMedium.Oil }, ArtType = ArtType.Painting },
                    new Artwork { ArtworkName = "Art4", Description = "Description of Art4", Price = 160.00m, ArtMediums = new List<ArtMedium> { ArtMedium.Acrylic }, ArtType = ArtType.Wall_Hanging },
                    new Artwork { ArtworkName = "Art5", Description = "Description of Art5", Price = 110.00m, ArtMediums = new List<ArtMedium> { ArtMedium.Oil }, ArtType = ArtType.Painting },
                    new Artwork { ArtworkName = "Art6", Description = "Description of Art6", Price = 155.00m, ArtMediums = new List<ArtMedium> { ArtMedium.Acrylic }, ArtType = ArtType.Wall_Hanging }
                };

                context.Artworks.AddRange(artworks);
                context.SaveChanges(); // Save artworks to get their IDs

                // Now associate Artworks with Artists
                var artist1 = context.Artists.FirstOrDefault(a => a.ArtistName == "John Doe Art");
                var artist2 = context.Artists.FirstOrDefault(a => a.ArtistName == "Jane Smith Art");

                if (artist1 != null)
                {
                    var artist1Artworks = new List<Artwork>
                    {
                        context.Artworks.FirstOrDefault(a => a.ArtworkName == "Art1"),
                        context.Artworks.FirstOrDefault(a => a.ArtworkName == "Art2"),
                        context.Artworks.FirstOrDefault(a => a.ArtworkName == "Art3")
                    };
                    foreach (var artwork in artist1Artworks.Where(a => a != null))
                    {
                        context.Artist_Artworks.Add(new Artist_Artwork { ArtistId = artist1.Id, ArtworkId = artwork.Id });
                    }
                }

                if (artist2 != null)
                {
                    var artist2Artworks = new List<Artwork>
                    {
                        context.Artworks.FirstOrDefault(a => a.ArtworkName == "Art4"),
                        context.Artworks.FirstOrDefault(a => a.ArtworkName == "Art5"),
                        context.Artworks.FirstOrDefault(a => a.ArtworkName == "Art6")
                    };
                    foreach (var artwork in artist2Artworks.Where(a => a != null))
                    {
                        context.Artist_Artworks.Add(new Artist_Artwork { ArtistId = artist2.Id, ArtworkId = artwork.Id });
                    }
                }

                context.SaveChanges();
            }
        }
    }
}

