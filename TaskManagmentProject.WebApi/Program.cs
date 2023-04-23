using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaskManagmentProject.Abstraction.IRepositories;
using TaskManagmentProject.Abstraction.IServices;
using TaskManagmentProject.Data.DBContext;
using TaskManagmentProject.Repository.Repositories;
using TaskManagmentProject.Service.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TaskDBContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("TaskDBContext")));

AddAuth(builder.Services);
AddRepositoriesAndServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

UpdateDatabase(app);

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

static void UpdateDatabase(IApplicationBuilder app)
{
    using (var serviceScope = app.ApplicationServices
        .GetRequiredService<IServiceScopeFactory>()
        .CreateScope())
    {
        var context = serviceScope.ServiceProvider.GetService<TaskDBContext>();
        context.Database.Migrate();
    }
}

static void AddAuth(IServiceCollection services)
{
    services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
    options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
    });

    // authentication 
    services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    });

    services.AddTransient(
        m => new UserManager());

}

static void AddRepositoriesAndServices(IServiceCollection services)
{
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    services.AddScoped<IUnitOfWork, TaskDBContext>();

    services.AddScoped<ITaskRepository, TaskRepository>();
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IUserRoleRepository, UserRoleRepository>();

    services.AddScoped<ITaskService, TaskService>();
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IUserRoleService, UserRoleService>();
}