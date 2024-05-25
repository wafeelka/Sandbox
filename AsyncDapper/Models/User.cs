namespace AsyncDapper.Models
{
    public record User
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int Age { get; init; }

    }
}
