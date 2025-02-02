using ArtStore.Models;

namespace ArtStore.Data.Services
{
    public interface IArtistsService
    {
        Task<IEnumerable<Artist>> GetAllArtists();
        Artist GetArtistById(int id);
        void AddArtist(Artist artist);
        Artist UpdateArtist(int id, Artist newArtist);
        void DeleteArtist(int id);
    }
}
