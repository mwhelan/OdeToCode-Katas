using System;

namespace Algorithm
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public bool IsOlderThan(Person person)
        {
            return BirthDate < person.BirthDate;
        }
    }
}