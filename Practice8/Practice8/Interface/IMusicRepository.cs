using Practice_8.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practice_8.Interfaces
{
    public interface IMusicRepository
    {
        Task<IEnumerable<MusicDto>> GetAllAsync();
        Task<MusicDto> GetByIdAsync(int id);
        Task AddAsync(MusicDto music);
        Task UpdateAsync(MusicDto music);
        Task DeleteAsync(int id);
    }
}
