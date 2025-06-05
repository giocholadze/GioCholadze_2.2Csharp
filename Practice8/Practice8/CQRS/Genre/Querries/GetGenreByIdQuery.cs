using MediatR;
using Practice_8.DTOs;

namespace Practice_8.CQRS.Genre.Queries
{
    public record GetGenreByIdQuery(int Id) : IRequest<GenreDto>;
}
