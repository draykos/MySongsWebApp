
DB First Scaffolding:
dotnet ef dbcontext scaffold "Server=localhost\\SQLEXPRESS;Database=SongsDb;User Id=admin;Password=admin;"  Microsoft.EntityFrameworkCore.SqlServer -o Songs --project "C:\MyProjects\Corso C#\MySongsWebApp\MySongsWebApp\MySongs.DAL"

Initial Migrations:
dotnet ef migrations add InitialCreateSongs --context SongsDbContext
dotnet ef migrations add InitialCreateSchool --context SchoolContext

Create / Update DB:
dotnet ef database update --context SchoolContext

