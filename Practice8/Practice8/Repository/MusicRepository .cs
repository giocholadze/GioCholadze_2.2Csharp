using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Practice_8.Data;
using Practice_8.DTOs;
using Practice_8.Interfaces;
using Practice_8.Models;

namespace Practice_8.Repositories
{
    public class MusicRepository : IMusicRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public MusicRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MusicDto>> GetAllAsync() =>
            _mapper.Map<List<MusicDto>>(await _context.Musics.ToListAsync());

        public async Task<MusicDto> GetByIdAsync(int id) =>
            _mapper.Map<MusicDto>(await _context.Musics.FindAsync(id));

        public async Task AddAsync(MusicDto music)
        {
            _context.Musics.Add(_mapper.Map<Music>(music));
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MusicDto music)
        {
            _context.Musics.Update(_mapper.Map<Music>(music));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var music = await _context.Musics.FindAsync(id);
            if (music != null)
            {
                _context.Musics.Remove(music);
                await _context.SaveChangesAsync();
            }
        }
    }
}
