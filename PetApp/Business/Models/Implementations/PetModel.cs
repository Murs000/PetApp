namespace PetApp.Business.Models.Implementations
{
    public class PetModel : IApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public PetType PetType { get; set; }
    }
}
