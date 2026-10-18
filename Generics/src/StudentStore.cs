using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.src
{
    public class StudentStore
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student) => students.Add(student);
        
        public List<Student> GetAll() => students;
        
        public Student? GetById(int id) =>  students.Find(s => s.Id == id);
        

        public void RemoveStudent(int id)
        {
            var student = GetById(id);
            if (student != null)
            {
                students.Remove(student);
            }
        }
    }
}
