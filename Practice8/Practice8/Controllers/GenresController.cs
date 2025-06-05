using Microsoft.AspNetCore.Mvc;
using Practice_8.DTOs;
using Practice_8.Interfaces;
using Practice_8.Models;
using Practice_8.Repositories;
using System.Threading.Tasks;

namespace Practice_8.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GenresController : Controller
    {
        private readonly IGenreRepository _genreRepository;

        public GenresController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var genres = await _genreRepository.GetAllAsync();
            return View(genres);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            if (genre == null) return NotFound();
            return View(genre);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(GenreDto genre)
        {
            if (!ModelState.IsValid) return View(genre);
            await _genreRepository.AddAsync(genre);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            if (genre == null) return NotFound();
            return View(genre);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GenreDto genre)
        {
            if (!ModelState.IsValid) return View(genre);
            await _genreRepository.UpdateAsync(genre);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            if (genre == null) return NotFound();
            return View(genre);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _genreRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
