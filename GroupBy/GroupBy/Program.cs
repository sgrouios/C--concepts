using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupBy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            people.Add(new Person("Stephen", new DateTime(1992, 04, 27)));
            people.Add(new Person("Jeffrey", new DateTime(1980, 10, 02)));
            people.Add(new Person("Greg", new DateTime(2000, 03, 03)));
            people.Add(new Person("Vic", new DateTime(1971, 01, 10)));
            people.Add(new Person("Arthur", new DateTime(1971, 01, 10)));

            IEnumerable<IGrouping<DateTime, Person>> grouping = people.OrderBy(x => x.Dob).GroupBy(p => p.Dob);

            Console.WriteLine("Iterate by Group\n");

            //Each List in grouping is an IGrouping<DateTime, Person> -- Key and object
            foreach(IGrouping<DateTime, Person> group in grouping)
            {
                Console.WriteLine($"Key: {group.Key}    Count: {group.Count()}\n");
           
                //Iterate through the objects in each IGrouping
                //group.Add(<DateTime, Person>) to each single Grouping
                foreach(Person pers in group)
                {
                    Console.WriteLine($"    {pers.ToString()}");
                }

                Console.WriteLine();
            }

            //Return grouped IEnumerable back to List<Person>
            IEnumerable<Person> people1 = grouping.SelectMany(group => group);
            List<Person> groupedPeople = people1.ToList();

            foreach(Person pers in groupedPeople)
            {
                Console.WriteLine(pers.ToString());
            }

            Console.Read();
        }

        public class Person
        {
            public string FirstName { get; set; }
            public DateTime Dob { get; set; }

            public Person(string first, DateTime dob)
            {
                FirstName = first;
                Dob = dob;
            }

            public override string ToString()
            {
                return $"{FirstName}    {Dob.ToString("yyyy/MM/dd")}";
            }
        }
    }
}
