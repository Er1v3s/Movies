namespace Movies.Contracts.Dtos
{
    public record MovieDto(int Id, string Title, string description, DateTime CreateDate, string category);
}
