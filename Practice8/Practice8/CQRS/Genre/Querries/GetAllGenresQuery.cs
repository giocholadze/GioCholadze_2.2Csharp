using MediatR;
using Practice_8.DTOs;
using System.Collections.Generic;

namespace Practice_8.CQRS.Genre.Queries
{
    public record CreateGenreHandler : IRequest<IEnumerable<GenreDto>>;
}
