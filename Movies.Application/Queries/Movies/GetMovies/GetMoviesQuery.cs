using MediatR;
using Movies.Contracts.Dtos;
using Movies.Contracts.Requests;
using Movies.Contracts.Responses;

namespace Movies.Application.Queries.Movies.GetMovies
{
    public record GetMoviesQuery(PaginationParams PaginationParams) : IRequest<PaginatedList<MovieDto>>;
}
