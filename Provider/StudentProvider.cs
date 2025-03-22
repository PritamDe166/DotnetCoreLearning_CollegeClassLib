
namespace CollegeClassLib.Provider;

public class StudentProvider(SchoolDbContext context) : IStudentProvider
{
    private readonly SchoolDbContext _context = context;

    public async Task<List<Student>> GetAllStudentsAsync()
    {
        return await _context.Students.ToListAsync();
    }
}