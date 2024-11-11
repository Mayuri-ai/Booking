using Booking.Entities;
using Booking.Repositories;
using Booking.Repositories.Implementations;
using Booking.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Booking.WebHost")));

//builder.Services.AddIdentity<ApplicationUser, IdentityRole>(/*options => options.SignIn.RequireConfirmedAccount = true*/)
//    .AddDefaultTokenProviders()
//    .AddEntityFrameworkStores<ApplicationDbContext>();


// services
// services 

builder.Services.AddScoped<IVenueRepo, VenueRepo>();
builder.Services.AddScoped<IArtistRepo, ArtistRepo>();
builder.Services.AddScoped<IConcertRepo, ConcertRepo>();
builder.Services.AddScoped<IUtilityRepo, UtilityRepo>();

builder.Services.AddScoped<ITicketRepo, TicketRepo>();
builder.Services.AddScoped<IBookingRepo,BookingRepo>();
builder.Services.AddScoped<IUserRepo,UserRepo>();
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
});


// when u add razor pages
builder.Services.AddRazorPages();


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
app.UseSession();   
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
