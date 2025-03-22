namespace CollegeClassLib.Service.Interfaces;

public interface IStudentService
{
    Task<IEnumerable<Student>> GetStudentsListAsync();
}
