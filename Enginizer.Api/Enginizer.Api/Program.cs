using AutoMapper;
using Enginizer.Api.Core.Contracts;
using Enginizer.Api.Core.Services;
using Enginizer.Api.Infrastructure.Persistence.Repositories;
using Enginizer.Api.Ioc;
using Enginizer.Api.MappingProfile;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabase(builder.Configuration);
var mapperConfig = new MapperConfiguration(mapperConfig =>
{
    mapperConfig.AddProfile(new MappingProfile());
});
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

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
