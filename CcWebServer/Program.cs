WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

app.MapGet(
    "/",
    (IWebHostEnvironment env) =>
    {
        string path = Path.Combine(env.ContentRootPath, "public", "index.html");
        return Results.File(path, "text/html");
    }
);
app.MapGet(
    "/index.html",
    (IWebHostEnvironment env) =>
    {
        string path = Path.Combine(env.ContentRootPath, "public", "index.html");
        return Results.File(path, "text/html");
    }
);

app.MapFallback(() => Results.NotFound(new { Message = "Not Found", Timestamp = DateTime.UtcNow }));

app.Run();

public partial class Program;
