using _24HackBookLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using _24HackBookLibrary.API;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddNpgsql<_24HackBookLibraryDbContext>(builder.Configuration["_24HackBookLibraryDbConnectionString"]);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://localhost:5003")
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});
var app = builder.Build();
app.UseCors();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
UserAPI.Map(app);
GenreAPI.Map(app);
CommentAPI.Map(app);
BookAPI.Map(app);
AuthorAPI.Map(app);
app.Run();