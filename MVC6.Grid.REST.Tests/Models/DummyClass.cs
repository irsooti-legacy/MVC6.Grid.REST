using System;
using System.Collections.Generic;
using System.Text;

namespace MVC6.Grid.REST.Tests.Models
{
    public class DummyClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }


    public class DummyEnumerable
    {
        public List<DummyClass> Dummies = new List<DummyClass>
        {
            new DummyClass
            {
                Id = 1,
                DateOfBirth = DateTime.Parse("12/05/1990"),
                Name = "Daniele"
            },

            new DummyClass
            {
                Id = 2,
                DateOfBirth = DateTime.Parse("1/01/1998"),
                Name = "Martina"
            },

            new DummyClass
            {
                Id = 3,
                DateOfBirth = DateTime.Parse("19/03/1993"),
                Name = "Cristina"
            }
        };
    }

}
