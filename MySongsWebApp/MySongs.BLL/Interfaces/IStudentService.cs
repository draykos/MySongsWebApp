using MySongs.DTO;

namespace MySongs.BLL.Interfaces;

public interface IStudentService
{
    List<StudentDTO> GetStudents();
    StudentDTO Create(StudentCreateDTO student);
    StudentDTO Read(int id);
    void Update(StudentDTO student);
    void Delete(int id);

}
