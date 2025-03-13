namespace CollegeClassLib.Service;

public interface IStudentService 
{
    string GetStudentsList();
}

public class StudentService : IStudentService
{
    public string GetStudentsList()
    {
        return "I am here";
    }
}
