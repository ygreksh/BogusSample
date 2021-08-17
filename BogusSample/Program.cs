using System;
using Bogus;

namespace BogusSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var faker = new Faker("en");
            var person = new Person()
            {
                Name = faker.Name.FullName(),
                Age = faker.Random.Number(18,120),
                //PassportNumber = faker.Random.String(10,10,'\0','\uffff')
                PassportNumber = faker.Random.String2(8, "qwertyuiopasdfghjklzxcvbnm")
            };
            Console.WriteLine($"{person.PassportNumber}, {person.Name}, {person.Age}");
        }
    }
}