using ConsumirAPILibreria.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IServicioAPI, ServicioAPI>();
builder.Services.AddScoped<IServicioMarca, ServicioMarca>();
builder.Services.AddScoped<IServicioMaterial, ServicioMaterial>();
builder.Services.AddScoped<IServicioRol, ServicioRol>();
builder.Services.AddScoped<IServicioMedida, ServicioMedida>();
builder.Services.AddScoped<IServicioCliente, ServicioCliente>();
builder.Services.AddScoped<IServicioEmpleado, ServicioEmpleado>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
