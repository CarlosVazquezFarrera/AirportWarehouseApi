using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Core.Options;
using AirportWarehouse.Infrastructure.Configuration;
using AirportWarehouse.Infrastructure.Data;
using AirportWarehouse.Infrastructure.Helpers;
using AirportWarehouse.Infrastructure.Interfaces;
using AirportWarehouse.Infrastructure.Repositories;
using AirportWarehouse.Infrastructure.Service;
using AirportWarehouse.Infrastructure.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

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

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Authentication"));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Authentication:Issuer"],
        ValidAudience = builder.Configuration["Authentication:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.SecretKey))
    };
});

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

//Custom validations fluent
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<PaginationOptions>(builder.Configuration.GetSection("Pagination"));

builder.Services.AddScoped<IWeatherRepository, WeatherForecastRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepositoty<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IJwtBearer, JwtBearerHelper>();
builder.Services.AddScoped<IAgentRepository, AgentRepository>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IClaimService, ClaimService>();
builder.Services.AddScoped<IEgressService, EgressService>();
builder.Services.AddScoped(typeof(IPagedListService<>), typeof(PagedListService<>));

builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
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

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
