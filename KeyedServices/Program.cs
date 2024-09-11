using KeyedServices;
using KeyedServices.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddKeyedSingleton<IEmailService, GmailService>(nameof(EmailServiceEnum.Gmail));
builder.Services.AddKeyedSingleton<IEmailService, OutlookService>(nameof(EmailServiceEnum.Outlook));
builder.Services.AddSingleton<GmailService>();
builder.Services.AddSingleton<OutlookService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
