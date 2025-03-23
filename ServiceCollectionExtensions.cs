
namespace CollegeClassLib;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddStudentServices(this IServiceCollection services)
    {
        
        // Register Logger
        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddConsole();
            loggingBuilder.AddDebug();
        });

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

    private static void SeedData(SchoolDbContext? context)
    {
        ArgumentNullException.ThrowIfNull(context);

        if (context != null)
        {
            SeedDepartments(context);
            SeedCourses(context);
            SeedStudents(context);
            SeedInstructors(context);
            SeedEnrollments(context);
        }

    }

    private static void SeedDepartments(SchoolDbContext context)
    {
        if (!context.Departments.Any())
        {
            context.Departments.AddRange(
                new Department { Id = 1, Name = "Computer Science" },
                new Department { Id = 2, Name = "Mathematics" },
                new Department { Id = 3, Name = "Physics" },
                new Department { Id = 4, Name = "Chemistry" },
                new Department { Id = 5, Name = "Biology" },
                new Department { Id = 6, Name = "History" }
            );
            context.SaveChanges();
        }
    }

    private static void SeedCourses(SchoolDbContext context)
    {
        if (!context.Courses.Any())
        {
            context.Courses.AddRange(
                new Course { Id = 1, Title = "Algorithms", Credits = 3, DepartmentId = 1 },
                new Course { Id = 2, Title = "Calculus", Credits = 4, DepartmentId = 2 },
                new Course { Id = 3, Title = "Organic Chemistry", Credits = 3, DepartmentId = 4 },
                new Course { Id = 4, Title = "World History", Credits = 3, DepartmentId = 6 },
                new Course { Id = 5, Title = "Physics I", Credits = 4, DepartmentId = 3 },
                new Course { Id = 6, Title = "Biology I", Credits = 4, DepartmentId = 5 }
            );
            context.SaveChanges();
        }
    }

    private static void SeedStudents(SchoolDbContext context)
    {
        if (!context.Students.Any())
        {
            context.Students.AddRange(
                new Student { Id = 1, Name = "John Doe", Age = 20, Email = "john.doe@example.com", EnrollmentDate = DateTime.Now, CourseId = 1 },
                new Student { Id = 2, Name = "Jane Smith", Age = 22, Email = "jane.smith@example.com", EnrollmentDate = DateTime.Now, CourseId = 2 }
            );
            context.SaveChanges();
        }
    }

    private static void SeedInstructors(SchoolDbContext context)
    {
        if (!context.Instructors.Any())
        {
            context.Instructors.AddRange(
                new Instructor { Id = 1, Name = "Dr. Brown", Email = "brown@example.com" },
                new Instructor { Id = 2, Name = "Prof. Green", Email = "green@example.com" }

            );
            context.SaveChanges();
        }
    }

    private static void SeedEnrollments(SchoolDbContext context)
    {
        if (!context.Enrollments.Any())
        {
            context.Enrollments.AddRange(
                new Enrollment { Id = 1, StudentId = 1, CourseId = 1, Grade = "A" },
                new Enrollment { Id = 2, StudentId = 2, CourseId = 2, Grade = "B" },
                new Enrollment { Id = 3, StudentId = 1, CourseId = 2, Grade = "B" },
                new Enrollment { Id = 4, StudentId = 2, CourseId = 1, Grade = "A" },
                new Enrollment { Id = 5, StudentId = 1, CourseId = 3, Grade = "B" },
                new Enrollment { Id = 6, StudentId = 2, CourseId = 3, Grade = "A" },
                new Enrollment { Id = 7, StudentId = 1, CourseId = 4, Grade = "A" }
            );
            context.SaveChanges();
        }
    }
}
