using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SocialTechContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")));
});

builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(opt => { opt.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3001"); });
// app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<SocialTechContext>();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

// try
// {

//     context.Database.Migrate();

//     DbInitalizer.Initialize(context);
//     Console.WriteLine("Database seeded succesfully.");
// }
// catch (Exception exception)
// {
//     logger.LogError(exception, "An error occured with the database migration.");

// }

app.Run();
