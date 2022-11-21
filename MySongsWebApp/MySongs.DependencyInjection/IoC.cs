using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySongs.DAL.Models;
using MySongs.DAL.Students;
using MySongs.BLL.Services;
using MySongs.BLL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace MySongs.DependencyInjection;

public static class IoC
{
    public static void Register(IConfiguration configuration, IServiceCollection services)
    {

        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? String.Empty;
        var connectionString2 = configuration.GetConnectionString("AnotherConnection") ?? String.Empty;

        services.AddDbContext<SongsDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddDbContext<SchoolContext>(options =>
               options.UseSqlServer(connectionString2));

        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<SchoolContext>();

        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddScoped<ISongService, SongService>();
        services.AddScoped<IStudentService, StudentService>();

    }
}