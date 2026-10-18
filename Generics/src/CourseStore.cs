using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.src
{
    public  class CourseStore
    {
        private List<Course> courses = new List<Course>();

        public void AddCourse(Course course) => courses.Add(course);

        public List<Course> GetAll() => courses;

        public Course? GetById(int id) => courses.Find(c => c.Id == id);
        public void RemoveCourse(int id)
        {
            var course = GetById(id);
            if (course != null)
            {
                courses.Remove(course);
            }
        }
    }
}
