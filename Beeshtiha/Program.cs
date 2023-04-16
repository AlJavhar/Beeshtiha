using beeshtiha.DAL.DbContexts;
using Beeshtiha.Extensions;
using Beeshtiha.Service.Mappers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BeeshtihaDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCustomServices();
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
