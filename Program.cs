using EmptyTemplateWebApiJwtAuthPsql;
using EmptyTemplateWebApiJwtAuthPsql.Interfaces;
using EmptyTemplateWebApiJwtAuthPsql.Repository;
using Microsoft.EntityFrameworkCore;
using NLog.Web;

Console.WriteLine("Starting...");
var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
try
{
    
    var builder = WebApplication.CreateBuilder(args);
    builder.Configuration.AddJsonFile("dbsettings.json", optional: true).AddEnvironmentVariables();
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(LogLevel.Trace);
    builder.Host.UseNLog();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<AppDbContent>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConfiguration")).UseSnakeCaseNamingConvention());
    builder.Services.AddTransient<ITestRepository, TestRepository>();

    var app = builder.Build();
    
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseStatusCodePages();
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    Console.WriteLine("Api started http://0.0.0.0:36363");
    app.Run();
}
catch (Exception exception)
{
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}