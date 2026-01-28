using myapiP.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<GameService>();

// No database services required for game-only API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");
app.MapControllers();

// Configure the HTTP request pipeline.
// Enable Swagger in all environments for API documentation
app.UseSwagger();
app.UseSwaggerUI(c => 
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Game API v1");
    c.RoutePrefix = string.Empty; // Serve Swagger UI at root URL
});

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

// Add a root endpoint that redirects to Swagger
app.MapGet("/", context => 
{
    context.Response.Redirect("/index.html");
    return Task.CompletedTask;
});

app.Run();