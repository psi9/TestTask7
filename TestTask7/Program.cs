using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using TestTask7;

var builder = WebApplication.CreateBuilder();

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddSpaStaticFiles(options => options.RootPath = "my-app/build");

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<InputCommandContext>(options => options.UseSqlServer(connection));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}
app.UseCors(corsBuilder => corsBuilder
    .AllowAnyOrigin()
    .AllowAnyHeader());

// app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(routeBuilder => routeBuilder.MapControllers());
app.UseSpaStaticFiles();
app.UseSpa(options =>
{
    options.Options.SourcePath = "my-app";
    
    if (app.Environment.IsDevelopment())
        options.UseReactDevelopmentServer("start");
});

app.Run();