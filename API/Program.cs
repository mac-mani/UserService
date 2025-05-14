using System.Text.Json.Serialization;
using API.Middlewares.Extensions;
using Infra;
using Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfraService(builder.Configuration);
builder.Services.AddApplicationService();

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
    );




var app = builder.Build();

// Exception Handler
app.UseGlobalExceptionHandler();

// Routing
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

// Controller routes
app.MapControllers();

app.Run();


//app.MapGet("/", () => "Hello World!");