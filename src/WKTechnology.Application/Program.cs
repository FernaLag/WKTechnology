using WKTechnology.Application.Contracts;
using WKTechnology.Application.Services;
using WKTechnology.Application.Services.Base;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options => options.EnableEndpointRouting = false);

builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7056"));
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseMvc(routes =>
{
    routes.MapRoute(
        name: "default",
        template: "{controller=Home}/{action=Index}/{id?}");

});

app.Run();