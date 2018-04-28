using System;
namespace EFDemo1.Model
{
    public class Student
    {   
        
        public static Student CreateStudentFrombody(Student student) 
        {
            Student newStudent = new Student();
            newStudent.Name = student.Name;
            return newStudent;
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public Student()
        {
        }
    }
}
