using Microsoft.EntityFrameworkCore;
using ProductApplication.Context;
using ProductApplication.Repository;
using ProductApplication.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Product Context service to the container
builder.Services.AddDbContextFactory<ProductContext>(options =>
    options.UseSqlServer(
        @"Server=(LocalDB)\MSSQLLocalDB;Database=URUKProducts;ConnectRetryCount=0"));

// Add ProductRepository DI
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
