using FluentValidation;
using Meetup.API.Mappers;
using Meetup.API.Middlewares;
using Meetup.API.Validator;
using Meetup.BLL.Mappers;
using Meetup.DI;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBusinessLogic();
builder.Services.AddDataAccess();
builder.Services.AddAutoMapper(typeof(MappingProfileBLL), typeof(MappingProfileAPI));

builder.Services.AddValidatorsFromAssemblyContaining<EventValidator>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerConfiguration();

builder.Services.AddOpenIddictConfiguration(builder.Configuration);

builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
