namespace Movies.Contracts.Errors
{
    public class NotFoundException(string message) : Exception(message);
}
