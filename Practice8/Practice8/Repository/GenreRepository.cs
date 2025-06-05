using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Practice_8.Data;
using Practice_8.DTOs;
using Practice_8.Interfaces;
using Practice_8.Models;

namespace Practice_8.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GenreRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreDto>> GetAllAsync() =>
            _mapper.Map<List<GenreDto>>(await _context.Genres.ToListAsync());

        public async Task<GenreDto> GetByIdAsync(int id) =>
            _mapper.Map<GenreDto>(await _context.Genres.FindAsync(id));

        public async Task AddAsync(GenreDto genre)
        {
            _context.Genres.Add(_mapper.Map<Genre>(genre));
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(GenreDto genre)
        {
            _context.Genres.Update(_mapper.Map<Genre>(genre));
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
