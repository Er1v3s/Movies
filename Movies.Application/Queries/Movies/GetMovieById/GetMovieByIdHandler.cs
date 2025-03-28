using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.Contracts.Errors;
using Movies.Contracts.Responses.Movies;
using Movies.Domain.Entities;
using Movies.Infrastructure;

namespace Movies.Application.Queries.Movies.GetMovieById
{
    public class GetMovieByIdHandler : IRequestHandler<GetMovieByIdQuery, GetMovieByIdResponse>
    {
        private readonly MoviesDbContext _moviesdbContext;

        public GetMovieByIdHandler(MoviesDbContext moviesDbContext)
        {
            _moviesdbContext = moviesDbContext;
        }

        public async Task<GetMovieByIdResponse> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            var movie = await _moviesdbContext.Movies
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (movie is null) 
                throw new NotFoundException($"{nameof(Movie)} with {nameof(Movie.Id)}: {request.Id} was not found in database");

            return movie.Adapt<GetMovieByIdResponse>();
        }
    }
}
