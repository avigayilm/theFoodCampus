using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
var rules = new RewriteOptions()
    .AddRedirect(@"^.{0}$", "/home/index");
app.UseRewriter(rules);
//app.UseMvc(
//    routes =>
//    {
//        routes.MapRoute(
//            name: "default",
//            template: "{controller}/{ Action}/{ id?}");
//    }
//    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}");
    //pattern: "home/index");

app.Run();
