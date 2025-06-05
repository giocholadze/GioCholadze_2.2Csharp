using MediatR;
using Practice_8.DTOs;

namespace Practice_8.CQRS.Genre.Commands
{
    public record UpdateMusicCommand(MusicDto Music) : IRequest;
}
