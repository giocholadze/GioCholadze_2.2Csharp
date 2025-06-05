using MediatR;

namespace Practice_8.CQRS.Genre.Commands
{
    public record GetGenreByIdQuery(int Id) : IRequest;
}
