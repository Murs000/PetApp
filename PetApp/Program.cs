using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using PetApp.Business.Mappers.Implementations;
using PetApp.Business.Mappers.Interfaces;
using PetApp.Business.Services.Implementations;
using PetApp.Business.Services.Interfaces;
using PetApp.Data.DataAccess.SqlServer;
using PetApp.Data.DataAccess.SqlServer.Repositorys.Implementations;
using PetApp.Data.DataAccess.SqlServer.Repositorys.Interfaces;
using PetApp.Presentation.APIs.Implementations;
using PetApp.Presentation.APIs.Interfaces;

var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder.Services);

var app = builder.Build();

Configure(app);

var apis = app.Services.GetServices<IApi>();
foreach (var api in apis)
{
    if (api is null) throw new InvalidProgramException("Api not found");
    api.Register(app);
}

app.Run();

void RegisterServices(IServiceCollection services)
{
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddDbContext<PetAppDb>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
    });
    services.AddScoped<IPetPostRepository, PetPostRepository>();
    services.AddScoped<IPetMapper, PetMapper>();
    services.AddScoped<IPetService, PetService>();

    services.AddTransient<IApi, PetApi>();
}

void Configure(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<PetAppDb>();
        db.Database.EnsureCreated();
    }

    app.UseHttpsRedirection();
}