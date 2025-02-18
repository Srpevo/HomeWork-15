﻿namespace UniversityProgram.BLL.Models.CourseModels.ViewModels
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public decimal Fee { get; set; }

        public string? Paid { get; set; }
    }
}
