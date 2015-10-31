namespace PhoneBookConslole
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Threading.Tasks;
    class Program
    {
        static void Main(string[] args)
        {

            List<Person> persons = new List<Person>();
            List<Person> personsEnd = new List<Person>();
            List<Person> getPursonByName = new List<Person>();
            var PersonById = new Person();


            Person ivan = new Person
            {
                FirstName = "Ivan",
                LastName = "Dimitrov",
                PhoneCount = 2,
                Phones = new List<Phone>{new Phone(){Number = "2222", TypePhone = TypePhone.Home },
                new Phone(){Number = "4444", TypePhone = TypePhone.Cellphone }}
            };
            Person stefan = new Person
            {
                FirstName = "Stefan",
                LastName = "Dimitrov",
                PhoneCount = 2,
                Phones = new List<Phone>{new Phone(){Number = "2222", TypePhone = TypePhone.Home },
                new Phone(){Number = "222", TypePhone = TypePhone.Cellphone }}
            };

            Console.WriteLine(ivan.Phones[0].Number);

            Repository rb = new Repository();

            rb.Create(ivan);
            rb.Create(stefan);
            personsEnd = rb.GetAll();
            PersonById = rb.Get(1);
            getPursonByName = rb.GetByName("Ivan");
            rb.Create(stefan);

            stefan.LastName = "Georgiev";
            bool isUpdate = rb.Update(stefan);

            bool isDell = rb.Delete(ivan);
         
            personsEnd = rb.GetAll();

            foreach (var item in personsEnd)
            {
                Console.WriteLine(item.FirstName);
            }
            Console.WriteLine("--getPursonByName--");
            foreach (var item in getPursonByName)
            {
               
                Console.WriteLine(item.FirstName);
            }
            Console.WriteLine("--PersonById--");
            Console.WriteLine(PersonById.FirstName, PersonById.Id);

            Console.WriteLine("----");
            foreach (var item in personsEnd)
            {

                Console.WriteLine(item.Id);
            }
        }
    }
}

