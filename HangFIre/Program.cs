using Hangfire;
using HangFIre.Services;

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
builder.Services.AddScoped<IJobTestService, JobTestService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseHangfireDashboard();

app.UseAuthorization();

app.MapControllers();
app.Run();
