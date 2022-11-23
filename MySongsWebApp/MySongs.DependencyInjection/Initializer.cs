using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MySongs.DAL.Students;

namespace MySongs.DependencyInjection;

public static class Initializer
{
    public static async Task CreateStudentsDb(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var context = serviceProvider.GetRequiredService<SchoolContext>();
        DbInitializer.Initialize(context);
        await DbInitializer.CreateRoles(roleManager);
    }
}