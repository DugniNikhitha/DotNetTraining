using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Training.BDD.PracticeTests
{
    public class LinqTest
    {
        [Test]
        public void LINQQuery()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee() { Name = "Nikhitha", Location = "Hyderabad", Role = "QA"},
                new Employee() { Name = "Pooja", Location = "Bangalore", Role = "HR"},
                new Employee() { Name = "Addy", Location = "Hyderabad", Role = "Dev"},
                new Employee() { Name = "Sudhan", Location = "Chennai", Role = "Manager"},
            };

            var locations = from emp in employees
                            select emp.Location;

            var altLocation = employees.Select(emp => emp.Location);

            var hyderabadEmp = from emp in employees
                             where emp.Location == "Hyderabad"
                             select emp.Name;

            var altHyderabadEmp = employees.Where(emp => emp.Location == "Hyderabad").Select(emp => emp.Name);

            Assert.AreEqual(locations, altLocation);
            Assert.AreEqual(hyderabadEmp, altHyderabadEmp);
        }
    }
}
