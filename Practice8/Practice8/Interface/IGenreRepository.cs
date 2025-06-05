using Practice_8.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practice_8.Interfaces
{
    public interface IGenreRepository
    {
        Task<IEnumerable<GenreDto>> GetAllAsync();
        Task<GenreDto> GetByIdAsync(int id);
        Task AddAsync(GenreDto genre);
        Task UpdateAsync(GenreDto genre);
        Task DeleteAsync(int id);
    }
}
