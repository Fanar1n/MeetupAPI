using FluentValidation;
using Meetup.API.Mappers;
using Meetup.API.Middlewares;
using Meetup.API.Validator;
using Meetup.BLL.DI;
using Meetup.BLL.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddBusinessLogic(configuration);
builder.Services.AddAutoMapper(typeof(MappingProfileBLL), typeof(MappingProfileAPI));

builder.Services.AddValidatorsFromAssemblyContaining<EventValidator>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
