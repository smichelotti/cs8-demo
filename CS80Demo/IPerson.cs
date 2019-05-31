using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS80Demo
{
    public interface IPerson
    {
        string? FirstName { get; set; }
        string? LastName { get; set; }

        // C# 8.0: Default Interface Members
        public string FullName => $"{this.FirstName} {this.LastName}";
    }

    public class Person : IPerson
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
