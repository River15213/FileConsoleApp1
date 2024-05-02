using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConsoleApp1
{
    internal class Employees
    {
        private static int i = 1;
        public int EmployeeId { get; private set; }
        public DateTime DateTimeAdd { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public DateTime DateBirth { get; set; }
        public string PlaceBirth {  get; set; }

        public Employees(string firstName, string name, string lastName, int age, double height, DateTime dateBirth, string placeBitth)
        {
            EmployeeId = i++;
            DateTimeAdd = DateTime.Now;
            Name = name;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Height = height;
            DateBirth = dateBirth;
            PlaceBirth = placeBitth;
        }
    }
}
