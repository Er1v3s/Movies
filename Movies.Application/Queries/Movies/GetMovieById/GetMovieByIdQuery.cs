﻿using MediatR;
using Movies.Contracts.Responses.Movies;

namespace Movies.Application.Queries.Movies.GetMovieById
{
    public record GetMovieByIdQuery(int Id) : IRequest<GetMovieByIdResponse>;
}
