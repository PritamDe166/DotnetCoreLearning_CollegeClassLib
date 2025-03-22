namespace CollegeClassLib.Middleware.Interfaces;

public interface IStudentMiddleware
{
    Task<List<Student>> GetAllStudentsAsync();
}
