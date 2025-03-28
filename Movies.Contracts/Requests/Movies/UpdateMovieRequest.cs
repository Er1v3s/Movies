namespace Movies.Contracts.Requests.Movies
{
    public record UpdateMovieRequest(int Id, string Title, string Description, string Category);
}