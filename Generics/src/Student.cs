using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.src
{
    public class Student : IHasId
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
