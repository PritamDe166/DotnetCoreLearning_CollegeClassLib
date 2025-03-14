namespace CollegeClassLib;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddStudentServices(this IServiceCollection services)
    {
        services.AddTransient<IStudentService, StudentService>();
        services.AddTransient<IStudentMiddleware, StudentMiddleware>();
        services.AddTransient<IStudentProvider, StudentProvider>();
        return services;
    }
    public static IServiceCollection AddMongoDbContext(this IServiceCollection services, string connectionString, string databaseName)
    {
        services.AddSingleton(new MongoDbContext(connectionString, databaseName));
        return services;
    }
}
