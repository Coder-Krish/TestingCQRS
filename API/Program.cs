using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TestingLibrary;
using TestingLibrary.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1",new OpenApiInfo()
    {
        Title = "Made for testing purposes",
        Version = "v1",
        Contact = new OpenApiContact()
        {
            Name = "Krishna Bogti", 
            Email = "invincible.impervious@gmail.com",
            Url =new Uri("https://www.instagram.com/invincible_system/")
        },
        Description = "This is just to test anything that comes up in my mind..."
    });
});
builder.Services.AddMediatR(typeof(MediatREntryPoint).Assembly);

/*Start Adding Connection String here*/
var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddDbContext<PersonDbContext>(x => x.UseSqlServer(connectionString));
/*End of Adding Connection string section*/

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<PersonDbContext>();

        if (context.Database.IsSqlServer())
        {
            context.Database.Migrate();
        }

    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

        logger.LogError(ex, "An error occurred while migrating or seeding the database.");

        throw;
    }
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(a =>
    {
        a.SwaggerEndpoint("v1/swagger.json", "Testing API V1.0.0");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();