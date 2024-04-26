using Microsoft.EntityFrameworkCore;
using PetApp.Business.Mappers.Interfaces;
using PetApp.Business.Models.Implementations;
using PetApp.Business.Services.Interfaces;
using PetApp.Data.DataAccess.SqlServer;
using PetApp.Data.DataAccess.SqlServer.Repositorys.Interfaces;
using PetApp.Data.Entity.Implementations;

namespace PetApp.Business.Services.Implementations
{
    public class PetService : IPetService
    {
        private readonly IPetMapper _mapper;
        private readonly IPetPostRepository _repository;
        public PetService(IPetMapper mapper, IPetPostRepository repository) 
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<PetModel> GetAsync(int modelId) => _mapper.Map(await _repository.GetAsync(modelId));

        public async Task<List<PetModel>> GetAsync() => _mapper.Map(await _repository.GetAsync());

        public Task InsertAsync(PetModel model) => _repository.InsertAsync(_mapper.Map(model));

        public Task UpdateAsync(PetModel model) => _repository.UpdateAsync(_mapper.Map(model));
        public Task DeleteAsync(int modelId) => _repository.DeleteAsync(modelId);
    }
}
