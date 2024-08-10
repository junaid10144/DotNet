using Microsoft.EntityFrameworkCore;
using WebApiCachingWithRedis.Data;
using WebApiCachingWithRedis.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<AppDbContext>(opt => 
    opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

// // Register ConnectionMultiplexer as a singleton
//using StackExchange.Redis;
// builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
// {
//     var configuration = sp.GetRequiredService<IConfiguration>();
//     var redisConnectionString = configuration.GetSection("Redis:ConnectionString").Value;
//     return ConnectionMultiplexer.Connect(redisConnectionString);
// });    

// public class CacheService : ICacheService
// {
//     private readonly IDatabase _cacheDb;

//     public CacheService(IConnectionMultiplexer connectionMultiplexer)
//     {
//         _cacheDb = connectionMultiplexer.GetDatabase();
//     }
// }

// {
//     "ConnectionStrings": {
//         "PostgresConnection": "Host=your_host;Database=your_db;Username=your_user;Password=your_password"
//     },
//     "Redis": {
//         "ConnectionString": "your_redis_connection_string"
//     },
//     "Logging": {
//         "LogLevel": {
//             "Default": "Information",
//             "Microsoft.AspNetCore": "Warning"
//         }
//     },
//     "AllowedHosts": "*"
// }

builder.Services.AddScoped<ICacheService, CacheService>();

// Add Logging
builder.Services.AddLogging();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();