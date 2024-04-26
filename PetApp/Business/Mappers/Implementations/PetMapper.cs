using PetApp.Business.Mappers.Interfaces;
using PetApp.Business.Models.Implementations;
using PetApp.Data.Entity.Implementations;
using PetApp.Data.Entity.Interfaces;
using System.Collections.Generic;

namespace PetApp.Business.Mappers.Implementations
{
    public class PetMapper : IPetMapper
    {
        public PetModel Map(PetPost entity)
        {
            PetModel model = new PetModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                PetType = entity.PetType,
            };
            return model;
        }

        public PetPost Map(PetModel model)
        {
            PetPost pet = new PetPost()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                PetType = model.PetType,
            };
            return pet;
        }

        public List<PetModel> Map(List<PetPost> entities)
        {
            List<PetModel> models = new List<PetModel>();
            foreach (var entity in entities)
            {
                PetModel model = Map(entity);
                models.Add(model);
            }
            return models;
        }

        public List<PetPost> Map(List<PetModel> models)
        {
            List<PetPost> entities = new List<PetPost>();
            foreach (var model in models)
            {
                PetPost entity = Map(model);
                entities.Add(entity);
            }
            return entities;
        }
    }
}
