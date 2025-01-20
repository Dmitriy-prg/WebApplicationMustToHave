using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NLog.Web;

//using Microsoft.IdentityModel.Tokens;
using System.Reflection.Emit;
using WebApplicationMustToHave.DataModels;
using WebApplicationMustToHave.Repository;
using WebApplicationMustToHave.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder();
// Configure NLog as the logging provider
builder.Logging.ClearProviders();  // Remove other loggers (optional)
//builder.Logging.SetMinimumLevel(LogLevel.Trace); // Optional: Set the minimum level for logging
builder.Host.UseNLog();  // Integrates NLog

// Add services to the container.
builder.Services.AddControllersWithViews();
//требуетс€ только дл€ минимальных API
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// добавл€ем контекст AppDbContext в качестве сервиса в приложение
builder.Services.AddDbContext<IAppDbContext, AppDbContext>();
// добавл€ем DbCompositionManager в качестве сервиса в приложение
builder.Services.AddTransient<IDbCompositionManager, DbCompositionManager>();
// добавл€ем DbPersonManager в качестве сервиса в приложение
builder.Services.AddTransient<IDbPersonManager, DbPersonManager>();
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
    app.UseDeveloperExceptionPage();
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

app.UseAuthorization();

//app.MapDefaultControllerRoute();

//app.MapControllerRoute(
//    name: "items",
//    //pattern: "{controller=Home}/{action=Index}/{id?}");
//    pattern: "{controller=App}/{action=Items}");
//app.MapControllerRoute(
//    name: "film",
//    //pattern: "{controller=Home}/{action=Index}/{id?}");
//    pattern: "{controller=App}/{action=Film}/{id?}");
//app.MapControllerRoute(
//    name: "CreateFilm",
//    //pattern: "{controller=Home}/{action=Index}/{id?}");
//    pattern: "{controller=App}/{action=CreateFilm}");
//app.MapControllerRoute(
//    name: "persys",
//    pattern: "{controller=Person}/{action=Items}");
//app.MapControllerRoute(
//    name: "pers",
//    pattern: "{controller=Person}/{action=Create}/{id?}");

//app.MapGet("/app/Items", async (AppDbContext db) =>
//{
//    if (db.compositions.IsNullOrEmpty())
//    {
//        await db.compositions.AddAsync(new DbComposition { Id = 1, Name = "јватар", YearBirth = 2009, DbCompositionTypeId = 3 });
//        await db.compositions.AddAsync(new DbComposition { Id = 2, Name = "Ќачало", YearBirth = 2010, DbCompositionTypeId = 3 });
//        await db.compositions.AddAsync(new DbComposition { Id = 3, Name = "“айные виды на гору ‘удзи", YearBirth = 2018, DbCompositionTypeId = 1 });
//        await db.SaveChangesAsync();
//    }
//    var listCompositions = await db.compositions.ToListAsync();
//    Console.WriteLine($"MapGet(/api/items: {listCompositions.Count}");
//});

//app.MapGet("/app/Items/{id}", async (int id, AppDbContext db) =>
//{
//    Console.WriteLine($"MapGet(/app/Items/{{id}}: {id}");
//    // получаем произведение по id
//    IDbComposition? composition = await db.compositions.FirstOrDefaultAsync(u => u.Id == id);
//    // если произведение не найдено, отправл€ем статусный код и сообщение об ошибке
//    if (composition == null) return Results.NotFound(new { message = "ѕроизвекдение не найдено" });

//    // если произведение найдено, отправл€ем его
//    return Results.Json(composition);
//});

//app.Run(async (context) =>
//{
//    Console.WriteLine($"Run(async (context) Path = {context.Request.Path}");
//    if (context.Request.Path == "/")
//    {
//        context.Response.Redirect("/app/items");
//    }
//    else
//    {
//        //context.Response.Redirect("/index.html");
//        //await context.response.writeasync("main page");
//    }
//});

app.Run();
