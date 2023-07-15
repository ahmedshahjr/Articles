using GrpcServer.Protos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//This line of code registers the Grpc service in the ASP.NET Core application. The Grpc service provides the infrastructure for hosting gRPC services in ASP.NET Core applications.
builder.Services.AddGrpc();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
//This line of code enables gRPC-Web support in the ASP.NET Core application. gRPC-Web is a protocol that allows gRPC services to be accessed over HTTP.
app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });
//This line of code maps the HelloWorldService class to a gRPC endpoint.
app.MapGrpcService<HelloWorldService>();
app.MapControllers();

app.Run();
