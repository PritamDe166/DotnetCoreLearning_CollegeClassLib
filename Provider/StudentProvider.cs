
namespace CollegeClassLib.Provider;

public class StudentProvider(SchoolDbContext _context, ILogger<StudentProvider> _logger) : IStudentProvider
{
    public async Task<List<Student>> GetAllStudentsAsync()
    {
        _logger.LogInformation("GetAllStudentsAsync in StudentProvider called");
        return await _context.Students.ToListAsync();
    }
}