
DB First Scaffolding:
dotnet ef dbcontext scaffold "Server=localhost\\SQLEXPRESS;Database=SongsDb;User Id=admin;Password=admin;"  Microsoft.EntityFrameworkCore.SqlServer -o Songs --project "C:\MyProjects\Corso C#\MySongsWebApp\MySongsWebApp\MySongs.DAL"

Initial Migrations:
dotnet ef migrations add InitialCreateSongs --context SongsDbContext
dotnet ef migrations add InitialCreateSchool --context SchoolContext

Create / Update DB:
dotnet ef database update --context SchoolContext

First Migrations
dotnet ef migrations add AddStudentAddress --context SchoolContext
dotnet ef migrations add AddPhoneNumber --context SongsDbContext

Create Migrations Scripts
dotnet ef migrations script --context SongsDbContext --output C:\temp\all.sql
dotnet ef migrations script InitialCreateSongs --context SongsDbContext --output C:\temp\migration1.sql
