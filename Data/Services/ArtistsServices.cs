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

        public async Task AddAsync(Artist artist)
        {
            await _context.Artists.AddAsync(artist);
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Artist>> GetAllAsync()
        {
            var result = await _context.Artists.ToListAsync();
            return result;
        }

        public Artist GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Artist UpdateAsync(int id, Artist newArtist)
        {
            throw new NotImplementedException();
        }
    }
}
