var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Session configuration
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60); // Extend session timeout
    options.Cookie.HttpOnly = true; // Prevent client-side access
    options.Cookie.IsEssential = true; // Ensure session cookie is always sent
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Ensure the cookie is only sent over HTTPS
    options.Cookie.SameSite = SameSiteMode.Lax; // Allow session to work across subdomains or same-site contexts
});

// Optionally: Add Redis distributed session (uncomment if you want to use Redis)
// builder.Services.AddDistributedRedisCache(options =>
// {
//     options.Configuration = "localhost:6379"; // Redis server connection string
//     options.InstanceName = "GradeTrackerSession"; // Instance name for session
// });

// Make sure session is configured before UseAuthorization
var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Session should be used before authorization
app.UseSession();
app.UseAuthorization();

// Routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();