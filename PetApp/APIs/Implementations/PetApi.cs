namespace PetAppPresentation.APIs.Implementations
{
    public class PetApi : IApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/pets", Get)
                .Produces<List<PetModel>>(StatusCodes.Status200OK)
                .WithName("GetAllPets")
                .WithTags("Getters");

            app.MapGet("/pets/{id}", GetById)
                .Produces<PetModel>(StatusCodes.Status200OK)
                .WithName("GetPet")
                .WithTags("Getters");

            app.MapPost("/pets", Post)
                .Accepts<PetModel>("application/json")
                .Produces<PetModel>(StatusCodes.Status201Created)
                .WithName("CreatePet")
                .WithTags("Creators");

            app.MapPut("/pets", Put)
                .Accepts<PetModel>("application/json")
                .WithName("UpdatePet")
                .WithTags("Updaters");

            app.MapDelete("pets/{id}", Delete)
                .WithName("DeletePet")
                .WithTags("Deleters");

        }

        private async Task<IResult> Get(IPetService service) =>
            service.Get() is List<PetModel> pets
            ? Results.Ok(pets)
            : Results.NotFound();

        private async Task<IResult> GetById(int id, IPetService service) =>
            service.Get(id) is PetModel pet
            ? Results.Ok(pet)
            : Results.NotFound();

        private async Task<IResult> Post([FromBody] PetModel pet, IPetService service)
        {
            service.Insert(pet);
            return Results.Created($"/pets/{pet.Id}", pet);
        }

        private async Task<IResult> Put([FromBody] PetModel pet, IPetService service)
        {
            service.Update(pet);
            return Results.NoContent();
        }

        private async Task<IResult> Delete(int id, IPetService service)
        {
            service.Delete(id);
            return Results.NoContent();
        }
    }
}
