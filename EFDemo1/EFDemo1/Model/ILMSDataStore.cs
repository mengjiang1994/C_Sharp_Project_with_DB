using System;
using System.Collections.Generic;

namespace EFDemo1.Model
{
    public interface ILMSDataStore
    {   
        //Course
        IEnumerable<Course> GetAllCourses();  //IEnumerable is the Iterator
        Course GetCourse(int courseID);
        void AddCourse(Course course);
        void EditCourse(int courseID, Course course);
        void DeleteCourse(int courseID);

        //Student
        IEnumerable<Student> GetAllStudent();  //IEnumerable is the Iterator
        void AddStudent(Student Student);
        Student GetStudent(int studentID);
    }
}
