using Microsoft.EntityFrameworkCore;
using PetApp.Data.DataAccess.SqlServer;

var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder.Services);

var app = builder.Build();

Configure(app);

app.Run();

void RegisterServices(IServiceCollection services)
{
    services.AddDbContext<PetAppDb>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
    });
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