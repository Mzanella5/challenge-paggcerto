using challengePaggcerto.src.api.Models.EntityModel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using challengePaggcerto.src.api.Models.ServiceModel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options => {
    String connectionString = builder.Configuration.GetConnectionString("DefaultConn");
    options.UseSqlServer(connectionString);
});

builder.Services.AddControllers().AddNewtonsoftJson(options =>{
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
builder.Services.AddSingleton<TransactionService>();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
