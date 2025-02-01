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
                        FirstName = "Alex",
                        LastName = "Underwood",
                        ArtistName = "Carving by Alex",
                        Address1 = "123 Art St",
                        City = "Art City",
                        State = "Art State",
                        PostalCode = "12345",
                        PhoneNumber = "123-456-7890",
                        Biography = "A brief biography of Alex.",
                        BioPictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg"
                    },
                    new Artist
                    {
                        FirstName = "Leann",
                        LastName = "Underwood",
                        ArtistName = "Arden Art Studio",
                        Address1 = "456 Art Ave",
                        City = "Art Town",
                        State = "Art State",
                        PostalCode = "67890",
                        PhoneNumber = "987-654-3210",
                        Biography = "A brief biography of Leann.",
                        BioPictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                    }
                };

                context.Artists.AddRange(artists);
                context.SaveChanges(); // Save artists to get their IDs

                // Seed Artworks
                var artworks = new List<Artwork>
                {
                    //Wood carvings
                    new Artwork { ArtworkName = "Red Alder Bowl 1", Description = "Red Alder Bowl face up", Price = 100.00m, ArtMediums = new List<ArtMedium> { ArtMedium.Wood, ArtMedium.Other }, ArtType = ArtType.Carving,
                        ArtworkImageURL ="https://ardensartstudio.com/wp-content/uploads/2022/10/bowl3.png" },
                    new Artwork { ArtworkName = "Red Alder Bowl 2", Description = "Red Alder Bowl ", Price = 150.00m, ArtMediums = new List<ArtMedium> { ArtMedium.Wood }, ArtType = ArtType.Carving,
                        ArtworkImageURL="https://ardensartstudio.com/wp-content/uploads/2022/10/bowl2.png"},
                    new Artwork { ArtworkName = "Spalted Alder Cup", Description = "Alder cup", Price = 120.00m, ArtMediums = new List<ArtMedium> { ArtMedium.Wood }, ArtType = ArtType.Carving,
                        ArtworkImageURL="https://i0.wp.com/ardensartstudio.com/wp-content/uploads/2022/10/mug.jpg"},
                    new Artwork { ArtworkName = "Birch Salad Set", Description = "Make from Ikea spoons", Price = 120.00m, ArtMediums = new List<ArtMedium> { ArtMedium.Wood }, ArtType = ArtType.Carving,
                        ArtworkImageURL="https://ardensartstudio.com/wp-content/uploads/2022/10/saladtools.jpg"},
                    //Encaustic
                    new Artwork { ArtworkName = "Field of flowers", Description = "Encaustic painting on wood panel", Price = 160.00m, ArtMediums = new List<ArtMedium> { ArtMedium.Wax, ArtMedium.Wood }, ArtType = ArtType.Wall_Hanging,
                        ArtworkImageURL="https://i0.wp.com/ardensartstudio.com/wp-content/uploads/2020/12/leann-with-painting.jpg"},
                    new Artwork { ArtworkName = "Sunset", Description = "Encaustic painting on wood panel", Price = 110.00m, ArtMediums = new List<ArtMedium> { ArtMedium.Wax, ArtMedium.Wood }, ArtType = ArtType.Wall_Hanging,
                        ArtworkImageURL="https://i0.wp.com/ardensartstudio.com/wp-content/uploads/2020/11/stormng-sunset.png" },
                    new Artwork { ArtworkName = "Seafoam sunrise", Description = "Encaustic painting on wood panel", Price = 155.00m, ArtMediums = new List<ArtMedium> { ArtMedium.Wax, ArtMedium.Wood }, ArtType = ArtType.Wall_Hanging,
                        ArtworkImageURL="https://i0.wp.com/ardensartstudio.com/wp-content/uploads/2020/11/ocean-above.png?fit=560%2C560&ssl=1" }
                };

                context.Artworks.AddRange(artworks);
                context.SaveChanges(); // Save artworks to get their IDs

                // Now associate Artworks with Artists
                var artist1 = context.Artists.FirstOrDefault(a => a.ArtistName == "Carving by Alex");
                var artist2 = context.Artists.FirstOrDefault(a => a.ArtistName == "Arden Art Studio");

                if (artist1 != null)
                {
                    var artist1Artworks = new List<Artwork>
                    {
                        context.Artworks.FirstOrDefault(a => a.ArtworkName == "Red Alder Bowl 1"),
                        context.Artworks.FirstOrDefault(a => a.ArtworkName == "Red Alder Bowl 2"),
                        context.Artworks.FirstOrDefault(a => a.ArtworkName == "Spalted Alder Cup"),
                        context.Artworks.FirstOrDefault(a => a.ArtworkName == "Birch Salad Set")
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
                        context.Artworks.FirstOrDefault(a => a.ArtworkName == "Field of flowers"),
                        context.Artworks.FirstOrDefault(a => a.ArtworkName == "Sunset"),
                        context.Artworks.FirstOrDefault(a => a.ArtworkName == "Seafoam sunrise")
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

