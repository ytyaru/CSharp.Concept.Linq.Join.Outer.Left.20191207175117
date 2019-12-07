using System;
using System.Collections.Generic;
using System.Linq;

namespace Concept.Linq.Lesson0 {
    class Person
    {
        public string Name { get; set; }
    }
    class Pet
    {
        public string Name { get; set; }
        public Person Owner { get; set; }
    }
    class Main {
        private List<Person> persons;
        private List<Pet> pets;
        public void Run() {
            persons = CreatePersons();
            pets = CreatePets();
            Show(Query());
        }
        private List<Person> CreatePersons() {
            return new List<Person>() {
                new Person { Name="A" },
                new Person { Name="B" },
                new Person { Name="C" },
            };
        }
        private List<Pet> CreatePets() {
            return new List<Pet>() {
                new Pet { Name="a", Owner=persons[0] },
                new Pet { Name="b", Owner=persons[0] },
                new Pet { Name="c", Owner=persons[1] },
                new Pet { Name="z", Owner=null },
            };
        }
        private IEnumerable<dynamic> Query() {
            return  from person in persons
                    join pet in pets on person equals pet.Owner into gj
                    from subpet in gj.DefaultIfEmpty()
                    select new { person.Name, PetName=subpet?.Name ?? String.Empty };
        }
        private void Show(in IEnumerable<dynamic> query) {
            foreach (var item in query) {
                Console.WriteLine($"Name={item.Name}, PetName={item.PetName}");
            }
        }
    }
}
