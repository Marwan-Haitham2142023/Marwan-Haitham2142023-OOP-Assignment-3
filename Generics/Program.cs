

﻿using System;
using System.Collections.Generic;
using Generics.src;



// 1. 5 students in a Store<Student>, 3 courses in a Store<Course>.
var studentStore = new Store<Student>();
studentStore.Add(new Student { Id = 1, Name = "Alice" });
studentStore.Add(new Student { Id = 2, Name = "Bob" });
studentStore.Add(new Student { Id = 3, Name = "Carol" });
studentStore.Add(new Student { Id = 4, Name = "Dave" });
studentStore.Add(new Student { Id = 5, Name = "Eve" });

var courseStore = new Store<Course>();
courseStore.Add(new Course { Id = 10, Title = "C# Basics", Price = 99.99m });
courseStore.Add(new Course { Id = 20, Title = "LINQ Deep Dive", Price = 149.50m });
courseStore.Add(new Course { Id = 30, Title = "ASP.NET Core", Price = 199.00m });

// 2. Get one of each by id.
var aStudent = studentStore.GetById(2);
var aCourse = courseStore.GetById(20);
Console.WriteLine($"[GetById] Student 2 -> {aStudent?.Name}");
Console.WriteLine($"[GetById] Course 20 -> {aCourse?.Title} : ({aCourse?.Price})");

// 3. Add a student with an id that already exists — catch and print its message.
try
{
    studentStore.Add(new Student { Id = 1, Name = "Impostor" });
}
catch (Exception ex)          // ← matches the store
{
    Console.WriteLine($"[Duplicate] {ex.Message}");
}

// 4. Print page 2 (size 2) of the students.
Console.WriteLine("[Page 2, size 2]");
foreach (var s in studentStore.GetAll().Page(2, 2))
    Console.WriteLine($"  {s.Id} — {s.Name}");

// 5. Call FindById on a plain List<Course>.
var plainCourses = new List<Course>
{
    new Course { Id = 100, Title = "Git Fundamentals", Price = 49.00m },
    new Course { Id = 200, Title = "Unit Testing",     Price = 79.00m },
};
var found = plainCourses.FindById(200);
Console.WriteLine($"[FindById on List<Course>] → {found?.Title ?? "not found"}");


//new Store<string>();   // must NOT compile

