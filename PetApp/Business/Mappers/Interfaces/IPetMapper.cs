using PetApp.Business.Models.Implementations;
using PetApp.Data.Entity.Implementations;

namespace PetApp.Business.Mappers.Interfaces
{
    public interface IPetMapper : IMapper<PetPost, PetModel>
    {
    }
}
