using AirportWarehouse.Config;
using AirportWarehouse.Infrastructure.Data;
using AirportWarehouse.Infrastructure.Interfaces;
using AirportWarehouse.Infrastructure.Service;
using AirportWarehouse.Infrastructure.Validations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var SecretKey = Environment.GetEnvironmentVariable("SecretKey");
var ConnectionString = Environment.GetEnvironmentVariable("ConnectionString");

var config = new Config(ConnectionString, SecretKey);


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy
                          .WithOrigins("http://localhost:4200",
                          "https://airportwarehouse.vercel.app")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSingleton<IConfig>(provider => {
    var accesor = provider.GetRequiredService<IHttpContextAccessor>();
    var request = accesor.HttpContext!.Request;
    var absoluteUri = $"{request.Scheme}://{request.Host.ToUriComponent()}";
    config.ApiUrl = absoluteUri;
    return config;
});

builder.Services.AddJWTConfig(builder.Configuration, config.SecretKey);

builder.Services.AddDbContext<AirportwarehouseContext>(options =>
{
    options.UseSqlServer(connectionString: @config.ConnectionString);
});

//Add services to the container.
builder.Services
    .AddControllers(options => options.Filters.Add<GlobalExceptionFilter>())
    .AddNewtonsoftJson(options => {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
    });

//Add services
builder.Services.AddApplicationServices(builder.Configuration);


//Add validations
builder.Services.AddValidationConfig();

builder.Services.AddEndpointsApiExplorer();

//Add Swagger
builder.Services.AddSwaggerConfig();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
