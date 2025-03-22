﻿namespace CollegeClassLib.Models;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Credits { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; } = null!;
    public List<Student> Students { get; set; } = [];
}
