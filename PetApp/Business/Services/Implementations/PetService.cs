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
        public List<PetModel> Get() => _mapper.Map(_repository.Get());
        public PetModel Get(int modelId) => _mapper.Map(_repository.Get(modelId));

        public int Insert(PetModel model) => _repository.Insert(_mapper.Map(model));
        public bool Update(PetModel model) => _repository.Update(_mapper.Map(model));
        public bool Delete(int modelId) => _repository.Delete(modelId);
    }
}
