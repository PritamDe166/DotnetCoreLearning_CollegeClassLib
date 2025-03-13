namespace CollegeClassLib.Models;

public class Student
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("enrollment_id")]
    public string? EnrollmentId { get; set; }

    [BsonElement("student_id")]
    public string? StudentId { get; set; }

    [BsonElement("course_id")]
    public string? CourseId { get; set; }

    [BsonElement("enrollment_date")]
    [BsonRepresentation(BsonType.String)]
    public string? EnrollmentDate { get; set; }

    [BsonElement("status")]
    public string? Status { get; set; }
}
