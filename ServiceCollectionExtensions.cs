

namespace CollegeClassLib;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddStudentServices(this IServiceCollection services)
    {
        //register services
        services.AddTransient<IStudentService, StudentService>();
        services.AddTransient<IStudentMiddleware, StudentMiddleware>();
        services.AddTransient<IStudentProvider, StudentProvider>();

        //register db context
        services.AddDbContext<SchoolDbContext>(options =>
                options.UseInMemoryDatabase("InMemoryDb"));

        // Build the service provider to resolve the ApplicationDbContext
        var serviceProvider = services.BuildServiceProvider() ?? throw new InvalidOperationException("serviceProvider is null");
        SeedData(serviceProvider.GetService<SchoolDbContext>());

        return services;
    }

    private static void SeedData(SchoolDbContext context)
    {
        if (context != null)
        {
            if (!context.Departments.Any())
            {
                context.Departments.AddRange(
                    new Department { Id = 1, Name = "Computer Science" },
                    new Department { Id = 2, Name = "Mathematics" }
                );
                context.SaveChanges();
            }

            if (!context.Courses.Any())
            {
                context.Courses.AddRange(
                    new Course { Id = 1, Title = "Algorithms", Credits = 3, DepartmentId = 1 },
                    new Course { Id = 2, Title = "Calculus", Credits = 4, DepartmentId = 2 }
                );
                context.SaveChanges();
            }

            if (!context.Students.Any())
            {
                context.Students.AddRange(
                    new Student { Id = 1, Name = "John Doe", Age = 20, Email = "john.doe@example.com", EnrollmentDate = DateTime.Now, CourseId = 1 },
                    new Student { Id = 2, Name = "Jane Smith", Age = 22, Email = "jane.smith@example.com", EnrollmentDate = DateTime.Now, CourseId = 2 }
                );
                context.SaveChanges();
            }

            if (!context.Instructors.Any())
            {
                context.Instructors.AddRange(
                    new Instructor { Id = 1, Name = "Dr. Brown", Email = "brown@example.com" },
                    new Instructor { Id = 2, Name = "Prof. Green", Email = "green@example.com" }
                );
                context.SaveChanges();
            }

            if (!context.Enrollments.Any())
            {
                context.Enrollments.AddRange(
                    new Enrollment { Id = 1, StudentId = 1, CourseId = 1, Grade = "A" },
                    new Enrollment { Id = 2, StudentId = 2, CourseId = 2, Grade = "B" }
                );
                context.SaveChanges();
            }
        }
    }
}
