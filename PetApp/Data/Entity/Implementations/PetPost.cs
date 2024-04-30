namespace PetApp.Data.Entity.Implementations
{
    public class PetPost : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public PetType PetType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CreatorId => Creator.Id;
        public User Creator { get; set; } = new User();

    }
}
