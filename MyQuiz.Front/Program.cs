using System.Globalization;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    // options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
builder.Services.AddSession();



builder.Services.Configure<RequestLocalizationOptions>(options => {

    var Supportedlangugaes = new[] {

       new CultureInfo("en"),
       new CultureInfo("ar"),

    };

    options.SupportedCultures = Supportedlangugaes;
    options.SupportedUICultures = Supportedlangugaes;

});


var app = builder.Build();

app.UseStaticFiles();
app.UseRequestLocalization();
app.UseSession();
app.MapControllerRoute("mydefault", "{controller=Home}/{action=Index}/{id?}");

app.Run();