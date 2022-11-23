using Microsoft.Extensions.Configuration;
using MySongs.DependencyInjection;
using MySongs.DTO;
using NLog;
using NLog.Web;
using System.Reflection;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);
    var services = builder.Services;
    var configuration = builder.Configuration;

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(StudentDTO)));


    //Dependencies injection
    IoC.Register(configuration, services);


    //Enforce lowercase routes
    services.Configure<RouteOptions>(options => options.LowercaseUrls = true);


    var app = builder.Build();

    //Initialize DB
    using (var scope = app.Services.CreateScope())
    {
        var serviceProvicer = scope.ServiceProvider;
        await Initializer.CreateStudentsDb(serviceProvicer);
    }

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

}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}


