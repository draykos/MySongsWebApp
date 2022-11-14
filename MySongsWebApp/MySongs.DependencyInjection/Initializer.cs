using Microsoft.Extensions.DependencyInjection;
using MySongs.DAL.Students;

namespace MySongs.DependencyInjection;

public static class Initializer
{
    public static void CreateStudentsDb(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<SchoolContext>();
        DbInitializer.Initialize(context);
    }
}