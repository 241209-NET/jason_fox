using Microsoft.EntityFrameworkCore;
using RoutineTracker.API.Data;
using RoutineTracker.API.Model;
using RoutineTracker.API.Repository;
using RoutineTracker.API.Service;

var builder = WebApplication.CreateBuilder(args);

// Add dbcontext and connect it to connection string
builder.Services.AddDbContext<RoutineTrackerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RoutineTracker")));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency inject the proper services
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IUserService, UserService>();

// Dependency inject the proper repositories
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Add automapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add controllers
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });


var app = builder.Build();

// Redirect base url to swagger
app.MapGet("", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();