using ArtStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtStore.Controllers
{
    public class ArtworksController : Controller
    {
        private readonly AppDbContext _context;

        public ArtworksController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.Artworks.ToListAsync();
            return View(data);
        }
    }
}
