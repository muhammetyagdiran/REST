using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using REST.Business.Implement;
using REST.Business.Interface;
using REST.Business.Mapper;
using REST.Business.Validation;
using REST.Core;
using REST.DataAccess.EntityFramework.Context;
using REST.DataAccess.EntityFramework.Implement;
using REST.DataAccess.EntityFramework.Interface;
using REST.DataAccess.EntityFramework.Repositories.Implement;
using REST.DataAccess.EntityFramework.Repositories.Interface;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Connection-MY

builder.Services.AddDbContext<PatikaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConStr"));
    options.LogTo(Console.WriteLine);
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});


builder.Services.AddControllers().AddFluentValidation(x =>
{
    x.RegisterValidatorsFromAssemblyContaining<BaseValidator>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging( x=>
{
    x.ClearProviders();
    x.SetMinimumLevel(LogLevel.Information);
    x.AddDebug();
});

builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);


builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUserService, UserManagement>();
builder.Services.AddScoped<IEfUserDal, EfUserDal>();
builder.Services.AddScoped<IEfBookDal, EfBookDal>();
builder.Services.AddScoped<IBookService, BookManagement>();
builder.Services.AddScoped<IGenreService, GenreManagement>();
builder.Services.AddScoped<IEfGenreDal, EfGenreDal>();
builder.Services.AddScoped<IEfAuthorDal, EfAuthorDal>();
builder.Services.AddScoped<IAuthorService, AuthorManagement>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
