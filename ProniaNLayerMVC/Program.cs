using Microsoft.EntityFrameworkCore;
using Pronia.Bussiness.Services.Abstracts;
using Pronia.Bussiness.Services.Concretes;
using Pronia.Core.RepositoryAbstracts;
using Pronia.Data.DAL;
using Pronia.Data.RepositoryConcretes;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt =>
opt.UseSqlServer("Server=WIN-0F0TGHD6FSA\\SQLEXPRESS;Database=ProniaNlayer;Trusted_Connection=true;Integrated Security=true;TrustServerCertificate=true;Encrypt=false"));
builder.Services.AddScoped<ICategoryServices,CategoryServices>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
var app = builder.Build();

app.MapControllerRoute(
     name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
    );
app.MapControllerRoute(

    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); 
app.UseStaticFiles();

app.Run();
