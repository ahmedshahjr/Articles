using Hangfire;
using HangFIre.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHangfire(hangfire =>
{
    hangfire.UseColouredConsoleLogProvider();
    hangfire.UseSqlServerStorage(
                 builder.Configuration.GetConnectionString("DBConnection"));
});
builder.Services.AddHangfireServer();
// Add HangFire service to the container.
builder.Services.AddSingleton<HangFireJobManager>();

var app = builder.Build();
var backGroundJobSerivice = app.Services.GetService<IRecurringJobManager>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
backGroundJobSerivice.AddOrUpdate("MyGrpcJob",
                          () => app.Services.GetService<HangFireJobManager>().ExecuteFireAndForgetJob(),
                          Cron.Daily);
app.UseHangfireDashboard();
app.UseAuthorization();
app.MapControllers();
app.Run();
