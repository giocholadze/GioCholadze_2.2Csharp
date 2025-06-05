using MediatR;
using Practice_8.CQRS.Genre.Commands;
using Practice_8.Interfaces;

namespace Practice_8.CQRS.Genre.Handlers
{
    public class CreateGenreHandler : IRequestHandler<CreateGenreCommand>
    {
        private readonly IGenreRepository _repository;

        public CreateGenreHandler(IGenreRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(request.Genre);
        }
    }
}
