
namespace CollegeClassLib.Middleware;
public class StudentMiddleware(IStudentProvider studentProvider, ILogger<StudentMiddleware> _logger) : IStudentMiddleware
{
    public Task<List<Student>> GetAllStudentsAsync()
    {
        _logger.LogInformation("GetAllStudentsAsync in StudentMiddleware called");
        return studentProvider.GetAllStudentsAsync();
    }
}
