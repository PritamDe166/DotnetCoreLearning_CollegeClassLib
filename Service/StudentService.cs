namespace CollegeClassLib.Service;

public class StudentService(IStudentMiddleware studentMiddleware, ILogger<StudentService> _logger) : IStudentService
{
    public async Task<IEnumerable<Student>> GetStudentsListAsync()
    {
        _logger.LogInformation("GetStudentsListAsync in StudentService called");
        return await studentMiddleware.GetAllStudentsAsync();
    }
}
