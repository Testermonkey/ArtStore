using ArtStore.Data;
using ArtStore.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtStore.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly IArtistsService _service;

        public ArtistsController(IArtistsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllArtists();
            return View(data);
        }
    }
}
