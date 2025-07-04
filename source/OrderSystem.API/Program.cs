using OrderSystem.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.ConfigureDatabase();

builder.ConfigureDependencyInjection();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll"); 

app.UseAuthorization();

app.MapControllers(); 

app.Run();
