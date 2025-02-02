using ArtStore.Data;
using ArtStore.Data.Services;
using ArtStore.Models;
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
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get:Artists/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("BioPictureURL, FirstName, LastName, ArtistName,Biography")]Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return View(artist);
            }

             await _service.AddAsync(artist);
            return RedirectToAction(nameof(Index));
        }
    }
}
