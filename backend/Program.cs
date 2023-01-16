global using backend.data;
global using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var  policyName = "_myAllowSpecificOrigins";
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(o =>
{
    o.UseNpgsql(builder.Configuration.GetConnectionString("kk_db"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
                      builder =>
                      {
                          builder
                            .WithOrigins("http://localhost:5173")
                            .AllowAnyOrigin()
                            .WithMethods("GET")
                            .WithMethods("DELETE")
                            .WithMethods("POST")
                            .WithMethods("PUT")
                            .AllowAnyHeader();
                      });
});
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

app.UseCors(policyName);

app.Run();
