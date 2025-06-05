using MediatR;

namespace Practice_8.CQRS.Genre.Commands
{
    public record DeleteMusicCommand(int Id) : IRequest;
}
