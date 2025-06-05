using MediatR;
using Practice_8.CQRS.Genre.Commands;
using Practice_8.Interfaces;

namespace Practice_8.CQRS.Genre.Handlers
{
    public class UpdateGenreHandler : IRequestHandler<UpdateMusicCommand>
    {
        private readonly IGenreRepository _repository;

        public UpdateGenreHandler(IGenreRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateMusicCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateAsync(request.Genre);
        }
    }
}
