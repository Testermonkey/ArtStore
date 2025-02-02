using ArtStore.Models;

namespace ArtStore.Data.Services
{
    public interface IArtistsService
    {
        Task<IEnumerable<Artist>> GetAllAsync();
        Artist GetByIdAsync(int id);
        Task AddAsync(Artist artist);
        Artist UpdateAsync(int id, Artist newArtist);
        void Delete(int id);
    }
}
