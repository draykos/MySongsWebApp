namespace MySongs.DTO;

public class StudentCreateDTO
{
    public string LastName { get; set; }
    public string FirstMidName { get; set; }
    public string Address { get; set; }
    public DateTime EnrollmentDate { get; set; }
}

public class StudentDTO : StudentCreateDTO
{
    public int ID { get; set; }
}
