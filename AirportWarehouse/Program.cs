using AirportWarehouse.Config;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";



builder.Services.AddHealthChecks();
builder.Services.AddCorsConfig(MyAllowSpecificOrigins);
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
