namespace CollegeClassLib.Service;

public class StudentService(IStudentMiddleware studentMiddleware) : IStudentService
{
    public string GetStudentsList()
    {
        return studentMiddleware.GetStudentsList();
    }
}
