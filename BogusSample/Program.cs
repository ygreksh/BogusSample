using System;
using Bogus;

namespace BogusSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var faker = new Faker("ru");
            var person = new Person()
            {
                Name = faker.Name.FullName(),
                Age = faker.Random.Number(18,100),
                PassportNumber = faker.Random.String2(2, "ABCDEFGHIJKLMNOPQRSTUVWXYZ") + "-" + faker.Random.String2(8, "0123456789")
            };
            Console.WriteLine($"{person.PassportNumber}, {person.Name}, {person.Age}");

            var testPersons = new Faker<Person>()
                .RuleFor(p => p.Name, f => f.Name.FullName())
                .RuleFor(p => p.Age, f => f.Random.Number(18, 100))
                .RuleFor(p => p.PassportNumber,
                    f => f.Random.String2(2, "ABCDEFGHIJKLMNOPQRSTUVWXYZ") + "-" +
                         faker.Random.String2(8, "0123456789"));
            var person2 = testPersons.Generate();
            Console.WriteLine($"{person2.PassportNumber}, {person2.Name}, {person2.Age}");
        }
    }
}