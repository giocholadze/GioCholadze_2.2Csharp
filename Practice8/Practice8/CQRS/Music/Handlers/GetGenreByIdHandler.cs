using MediatR;
using Practice_8.CQRS.Genre.Queries;
using Practice_8.DTOs;
using Practice_8.Interfaces;

namespace Practice_8.CQRS.Genre.Handlers
{
    public class GetGenreByIdHandler : IRequestHandler<GetGenreByIdQuery, GenreDto>
    {
        private readonly IGenreRepository _repository;

        public GetGenreByIdHandler(IGenreRepository repository)
        {
            _repository = repository;
        }

        public async Task<GenreDto> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
