namespace PetAppBusiness.Services.Implementations
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
        public List<PetModel> Get()
        {
            List<PetModel> models = _mapper.Map(_repository.Get());

            int count = 0;
            foreach (PetModel model in models)
            {
                model.No = count;
                count++;
            }

            return models;
        }
        public PetModel Get(int modelId) => _mapper.Map(_repository.Get(modelId));
        public int Insert(PetModel model)
        {
            PetPost petPost = _mapper.Map(model);

            petPost.Creator.Id = 4;
            petPost.CreatedAt = DateTime.Now;
            petPost.UpdatedAt = DateTime.Now;

            return _repository.Insert(petPost);
        }
        public bool Update(PetModel model)
        {
            PetPost petPost = _mapper.Map(model);

            petPost.UpdatedAt = DateTime.Now;

            return _repository.Update(petPost);
        }

        public bool Delete(int modelId) => _repository.Delete(modelId);
    }
}
