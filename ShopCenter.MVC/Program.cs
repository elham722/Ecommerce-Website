using ShopCenter.MVC.Contracts;
using ShopCenter.MVC.Services;
using ShopCenter.MVC.Services.Base;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<IClient, Client>
             (c => c.BaseAddress = new Uri(builder.Configuration.GetSection("ApiAddress").Value));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


builder.Services.AddSingleton<ILocalStorageService,LocalStorageService>();
builder.Services.AddScoped<IUserService, UserService>();
// Add services to the container.
builder.Services.AddControllersWithViews();

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
