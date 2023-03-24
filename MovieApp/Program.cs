var builder = WebApplication.CreateBuilder(args);

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
app.UseEndpoints(endpoints =>
{
    //localhost:7033
    endpoints.MapControllerRoute(
        name: "home", pattern: "", defaults: new { controller = "Home", action = "Index" });
    //localhost:7033/about
    endpoints.MapControllerRoute(
        name: "about", pattern: "/about", defaults: new { controller = "Home", action = "About" });
    //localhost:7033/movies/list
    endpoints.MapControllerRoute(
        name: "movieList", pattern: "movies/list", defaults: new { controller = "Movies", action = "List" });
    //localhost:7033/movies/details
    endpoints.MapControllerRoute(
        name: "movieDetails", pattern: "movies/details", defaults: new { controller = "Movies", action = "Details" });
});

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
