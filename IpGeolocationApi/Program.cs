using IpGeolocationApi.Services;
using IpGeolocationApi.Settings;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<IpstackSettings>(builder.Configuration.GetSection("IpstackSettings"));
builder.Services.AddHttpClient<IIpGeolocationService, IpGeolocationService>();
builder.Services.AddScoped<IIpGeolocationService, IpGeolocationService>();

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
app.Run();