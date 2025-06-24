using AirportWarehouse.Config;
using AirportWarehouse.Infrastructure.Validations;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


builder.Services.AddConfigSettings(builder.Configuration);


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


builder.Services.AddJWTConfig(builder.Configuration);

builder.Services.AddDatabaseContext();


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
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}



app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
