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

// 1. For Swagger
builder.Services.AddEndpointsApiExplorer();
// 2. Swagger
builder.Services.AddSwaggerGen();

/* builder.Services.AddCors(opt=>{
    opt.AddDefaultPolicy(builder=>builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
});
 */
var app = builder.Build();

// Exception Handler
app.UseGlobalExceptionHandler();

// Routing
app.UseRouting();

// 3. Swagger (Adds endpoint that can serve the swagger.json)
app.UseSwagger();
// 4. Swagger UI
app.UseSwaggerUI();

app.UseCors(cfg=> cfg.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());

//Auth
app.UseAuthentication();
app.UseAuthorization();

// Controller routes
app.MapControllers();

app.Run();


//app.MapGet("/", () => "Hello World!");