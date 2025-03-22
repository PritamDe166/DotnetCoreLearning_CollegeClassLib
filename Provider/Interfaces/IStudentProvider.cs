using Microsoft.EntityFrameworkCore;

namespace CollegeClassLib.Provider.Interfaces;

public interface IStudentProvider
{
    Task<List<Student>> GetAllStudentsAsync();
}
