using Microsoft.EntityFrameworkCore;
using SurvivorWebApi.Controllers;
using SurvivorWebApi.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


// ▼ Adding dbcontext services with connection string define in appsettings ▼
var connectionString = builder.Configuration.GetConnectionString("SqlServer");
builder.Services.AddDbContext<SurvivorDbContext>(options=>options.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
