using MediatR;
using Practice_8.CQRS.Genre.Queries;
using Practice_8.DTOs;
using Practice_8.Interfaces;

namespace Practice_8.CQRS.Genre.Handlers
{
    public class GetAllGenresHandler : IRequestHandler<GetAllGenresQuery, IEnumerable<GenreDto>>
    {
        private readonly IGenreRepository _repository;

        public GetAllGenresHandler(IGenreRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GenreDto>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
