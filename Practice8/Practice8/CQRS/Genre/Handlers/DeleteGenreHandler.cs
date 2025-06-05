using MediatR;
using Practice_8.CQRS.Genre.Commands;
using Practice_8.Interfaces;

namespace Practice_8.CQRS.Genre.Handlers
{
    public class DeleteGenreHandler : IRequestHandler<DeletemusicCommand>
    {
        private readonly IGenreRepository _repository;

        public DeleteGenreHandler(IGenreRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeletemusicCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
        }
    }
}
