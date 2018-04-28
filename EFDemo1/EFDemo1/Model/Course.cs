using System;
namespace EFDemo1.Model
{
    public class Course
    {

        public static Course CreateCourseFrombody(Course course)
        {
            Course newCourse = new Course();
            newCourse.Name = course.Name;
            return newCourse;
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public Course()
        {
        }
    }
}
