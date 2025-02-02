using ArtStore.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtStore.Data.Services
{
    public class ArtistsServices : IArtistsService
    {
        private readonly AppDbContext _context;

        public ArtistsServices(AppDbContext context)
        {
            _context = context;
        }

        public void AddArtist(Artist artist)
        {
            throw new NotImplementedException();
        }

        public void DeleteArtist(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Artist>> GetAllArtists()
        {
            var result = await _context.Artists.ToListAsync();
            return result;
        }

        public Artist GetArtistById(int id)
        {
            throw new NotImplementedException();
        }

        public Artist UpdateArtist(int id, Artist newArtist)
        {
            throw new NotImplementedException();
        }
    }
}
