using Microsoft.Extensions.DependencyInjection;
using Options_Pattern;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adding Options Patter
builder.Services.AddOptions<CompanyOptions>(CompanyOptions.Individual)
    .BindConfiguration($"Company:{nameof(CompanyOptions.Individual)}")
    .ValidateDataAnnotations()
    .ValidateOnStart();

// Adding Options Patter
builder.Services.AddOptions<CompanyOptions>(CompanyOptions.Individual)
    .BindConfiguration($"Company:{nameof(CompanyOptions.Individual)}")
    .ValidateDataAnnotations()
    .ValidateOnStart();



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
