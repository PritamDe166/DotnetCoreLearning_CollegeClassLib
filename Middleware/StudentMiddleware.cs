namespace CollegeClassLib.Middleware;
public class StudentMiddleware(IStudentProvider studentProvider) : IStudentMiddleware
{
    public string GetStudentsList()
    {
        return studentProvider.GetStudentList();
    }
}
