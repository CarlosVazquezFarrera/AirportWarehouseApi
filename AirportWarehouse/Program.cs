using AirportWarehouse.Config;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy
                          .WithOrigins(
                              "http://localhost:4200",
                              "http://localhost:80",
                              "http://localhost",
                              "http://137.184.230.117",
                              "http://airportwarehouse.com.mx",
                              "https://airportwarehouse.com.mx",
                              "https://airportwarehouse.vercel.app"
                           )
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

builder.Services.AddHealthChecks();
//builder.Services.AddCorsConfig(MyAllowSpecificOrigins);
builder.Services.AddControllerConfig();
builder.Services.AddHttpContextAccessor();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddAppSettingsSection(builder.Configuration);
builder.Services.AddDatabaseContext();
builder.Services.AddMappingProfiles();
builder.Services.AddJWTConfig(builder.Configuration);
builder.Services.AddSwaggerConfig();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}


app.MapHealthChecks("/health");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
