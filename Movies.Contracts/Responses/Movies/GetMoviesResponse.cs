using Movies.Contracts.Dtos;

namespace Movies.Contracts.Responses.Movies
{
    public record GetMoviesResponse(List<MovieDto> MovieDtos);
}
