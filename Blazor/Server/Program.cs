using Blazor.Models.Context;
using Blazor.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews()
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(op => op.UseMemberCasing());
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("ContextConnection"), options => options.MigrationsAssembly("Blazor.Models")));
builder.Services.AddScoped<DbContext, ApplicationDbContext>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IWindowsService, WindowsService>();
builder.Services.AddScoped<ISubElementService, SubElementService>();

var app = builder.Build();



UpdateDatabase(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();


static void UpdateDatabase(WebApplication app)
{
    // Migrate latest database changes during startup
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        if ((dbContext.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
            dbContext.Database.Migrate();
        else
            dbContext.Database.EnsureCreated();
    }
}