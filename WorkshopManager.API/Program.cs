using WorkshopManager.API.Middleware;
using WorkshopManager.Application;
using WorkshopManager.Domain.Common;
using WorkshopManager.Infrastructure;
using WorkshopManager.Infrastructure.Tenancy;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Usando global:: garantimos que ele pegue a biblioteca externa do NuGet
    c.SwaggerDoc("v1", new global::Microsoft.OpenApi.Models.OpenApiInfo { Title = "Workshop Manager API", Version = "v1" });

    c.AddSecurityDefinition("TenantId", new global::Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "X-Tenant-Id",
        Type = global::Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        In = global::Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "ID da Oficina (Guid)"
    });

    c.AddSecurityRequirement(new global::Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new global::Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new global::Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = global::Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "TenantId"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ITenantProvider, TenantProvider>();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Workshop Manager API v1");
    });
}

app.UseExceptionHandler();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
