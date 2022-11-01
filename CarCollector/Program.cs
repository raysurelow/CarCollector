using CarCollector.DataAccessors;
using CarCollector.DataAccessors.Interfaces;
using CarCollector.Services;
using CarCollector.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;
services.AddControllersWithViews();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddScoped<IUploadService, UploadService>();
services.AddScoped<IGarageDataAccessor, GarageDataAccessor>();
services.AddScoped<ICarDataAccessor, CarDataAccessor>();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
