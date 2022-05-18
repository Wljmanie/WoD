using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WoD.Data;
using WoD.Models;
using WoD.Services;
using WoD.Services.Interfaces;
using WoD.ViewModels;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(ConnectionService.GetConnectionString(builder.Configuration)));


builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddIdentity<WoDUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<DataService>();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddScoped<IWoDEmailSender, EmailService>();

var app = builder.Build();

DataService dataservice = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataService>();
if (dataservice != null) await dataservice.ManageDataAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
