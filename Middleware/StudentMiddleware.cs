namespace CollegeClassLib.Middleware;
public class StudentMiddleware(IStudentProvider studentProvider) : IStudentMiddleware
{
    public Task<List<Student>> GetAllStudentsAsync()
    {
        return studentProvider.GetAllStudentsAsync();
    }
}
