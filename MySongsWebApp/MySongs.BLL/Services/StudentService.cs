using Microsoft.Extensions.Logging;
using AutoMapper;
using MySongs.DTO;
using MySongs.DAL.Students;
using MySongs.BLL.Interfaces;

namespace MySongs.BLL.Services;

public class StudentService : IStudentService
{
    private readonly ILogger<StudentService> logger;
    private readonly IMapper mapper;
    private readonly SchoolContext context;

    public StudentService(ILogger<StudentService> logger, IMapper mapper , SchoolContext context)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.context = context;
    }

    public List<StudentDTO> GetStudents()
    {
        logger.LogInformation("I'm getting top 10 students");
        var students = context.Students.Take(10).ToList();

        return mapper.Map<List<StudentDTO>>(students);

    }

    public StudentDTO Create(StudentCreateDTO student)
    {
        var entity = mapper.Map<Student>(student);
        context.Students.Add(entity);
        context.SaveChanges();
        return mapper.Map<StudentDTO>(entity);
    }


    public StudentDTO Read(int id)
    {
        var student = context.Students.FirstOrDefault(s => s.ID == id);
        return mapper.Map<StudentDTO>(student);
    }

    public void Update(StudentDTO student)
    {
        var entity = context.Students.Find(student.ID);
        if (entity == null)
        {
            throw new Exception($"Id {student.ID} not available");
        }


        mapper.Map(student, entity);
        context.SaveChanges();
    }
    public void Delete(int id)
    {
        var entity = new Student { ID = id };
        context.Students.Attach(entity);
        context.Students.Remove(entity);
        context.SaveChanges();
    }


}
