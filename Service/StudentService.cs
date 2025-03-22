namespace CollegeClassLib.Service;

public class StudentService(IStudentMiddleware studentMiddleware) : IStudentService
{
    public async Task<IEnumerable<Student>> GetStudentsListAsync()
    {
        return await studentMiddleware.GetAllStudentsAsync();
    }
}
