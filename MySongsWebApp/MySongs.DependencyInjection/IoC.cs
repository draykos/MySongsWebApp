using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySongs.BLL.Services;
using MySongs.DAL;
using MySongsWebApp.Interfaces;

namespace MySongs.DependencyInjection;

public static class IoC
{
    public static void Register(IConfiguration configuration, IServiceCollection services)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? String.Empty;
        services.AddDbContext<MySongsContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<ISongService, SongService>();

    }
}