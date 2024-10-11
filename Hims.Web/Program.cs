using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Hims.Arquitecture.Models;
using Hims.Data.ClienteRepository;
using TM.Data.ClienteRepository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Connection String
builder.Services.AddDbContext<HimsContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("Server=DESKTOP-PCB1OR7;Database=HIMS;Trusted_Connection=True;TrustServerCertificate=True;")));

//EmpleadoRepository
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
