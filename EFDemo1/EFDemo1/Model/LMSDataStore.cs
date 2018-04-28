using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFDemo1.Model
{
    public class LMSDataStore:ILMSDataStore
    {
        private LMSDbContext _ctx;

        public LMSDataStore(LMSDbContext ctx)
        {
            _ctx = ctx;
        }

        private void Save() {
            _ctx.SaveChanges();
        }

        //For Course Controller
        public void AddCourse(Course course)
        {
            _ctx.Courses.Add(course);
            Save();
        }

        // For Student Controller
        public void AddStudent(Student student)
        {
            _ctx.Students.Add(student);
        }

        public void EditCourse(int courseID, Course course)
        {
            Course courseToEdit = _ctx.Courses.Find(courseID);
            courseToEdit.Name = course.Name;
            Save();
        }

        public IEnumerable<Course> GetAllCourses()
        {   
            //只有这里才算真正拿出来的操作
            return _ctx.Courses.OrderBy(a => a.Id).ToList();
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return _ctx.Students.OrderBy(a => a.Id).ToList();
        }

        public Course GetCourse(int courseID)
        {
            return _ctx.Courses.Find(courseID);
        }

        public Student GetStudent(int studentID)
        {
            return _ctx.Students.Find(studentID);
        }

        public void DeleteCourse(int courseID){
            var course = _ctx.Courses.Find(courseID);
            _ctx.Courses.Remove(course);
            Save();
        }
    }
}
