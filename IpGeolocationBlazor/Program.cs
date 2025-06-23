using IpGeolocationBlazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Serilog;
using Serilog.Events;
using Microsoft.AspNetCore.Routing;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("Logs/blazor-app-.log", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 7)
    .CreateLogger();

try
{
    Log.Information("Starting Blazor Server application");

    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog();

    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();
    builder.Services.AddHttpClient<IIpGeolocationClient, IpGeolocationClient>(client =>
        client.BaseAddress = new Uri("https://localhost:5001/"));

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();

    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

    var endpointDataSource = app.Services.GetRequiredService<EndpointDataSource>();
    foreach (var endpoint in endpointDataSource.Endpoints)
    {
        Log.Information("Registered endpoint: {DisplayName}, Route: {RoutePattern}",
            endpoint.DisplayName,
            (endpoint as RouteEndpoint)?.RoutePattern?.RawText ?? "N/A");
    }

    Log.Information("Starting application");
    await app.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application failed to start");
    throw;
}
finally
{
    Log.CloseAndFlush();
}