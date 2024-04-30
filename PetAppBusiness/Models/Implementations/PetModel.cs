namespace PetAppBusiness.Models.Implementations
{
    public class PetModel : IApiModel
    {
        public int No { get; set; }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public PetType PetType { get; set; }
    }
}
