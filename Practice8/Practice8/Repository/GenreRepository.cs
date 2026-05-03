using Microsoft.EntityFrameworkCore;
using Practice_8.Data;
using Practice_8.Interfaces;
using Practice_8.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practice_8.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly AppDbContext _context;

        public GenreRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genre>> GetAllAsync() => await _context.Genres.ToListAsync();
        public async Task<Genre> GetByIdAsync(int id) => await _context.Genres.FindAsync(id);
        public async Task AddAsync(Genre genre)
        {
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Genre genre)
        {
            _context.Genres.Update(genre);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre != null)
            {
                _context.Genres.Remove(genre);
                await _context.SaveChangesAsync();
            }
        }
    }
}
