using Infrastructure;
using Infrastructure.RequestHandlers.ContextHelper;
using Persistance;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddHttpContextAccessor(); // need for HttpContextHelper
    #region Read Appsettings.json
    var connectionString = builder.Configuration.GetConnectionString("PGDB");
    #endregion

    builder.Services.AddPersistance(connectionString ?? string.Empty);

}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();


    if (app.Services.GetService<IHttpContextAccessor>() != null)
        HttpContextHelper.Accessor = app.Services.GetRequiredService<IHttpContextAccessor>();

    app.MapControllers();

    app.ConfigureCustomExceptionMiddleware();

    app.Run();
}
