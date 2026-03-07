using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;

var builder = WebApplication.CreateBuilder(args);

//Add Contollers
builder.Services.AddControllers();

//Add databse Context
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer (builder.Configuration.GetConnectionString("DefaultConnections")));

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();   
}

//Middleware
app.UseHttpsRedirection();
app.UseAuthentication();
app.MapControllers();

app.Run();


