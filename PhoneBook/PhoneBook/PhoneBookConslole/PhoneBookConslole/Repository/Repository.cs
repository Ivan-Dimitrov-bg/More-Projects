using System;

namespace PhoneBookConslole
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Repository : IRepository
    {
        private List<Person> persons = new List<Person>();
        private int nextId = 1;
        private static bool fileExist = false;
        public Repository()
        {

        }
        public List<Person> GetAll()
        {
            persons = ReadFile("MyFile1.dat");
            return persons;
        }

        public Person Get(int id)
        {
            persons = ReadFile("MyFile1.dat");
            var person = persons.Find(p => p.Id == id);
            if (person == null)
            {
                throw new EntryPointNotFoundException();
            }
            return person;
        }

        public List<Person> GetByName(string Name)
        {
            var ReturnPersonListByName = new List<Person>();

            persons = ReadFile("MyFile1.dat");
            for (int i = 0; i < persons.Count; i++)
            {
                if (Name == persons[i].FirstName)
                {
                    ReturnPersonListByName.Add(persons[i]);
                 
                }
                else if (Name == persons[i].LastName)
                {
                    ReturnPersonListByName.Add(persons[i]);
                }
            }
            if (ReturnPersonListByName.Count == 0)
            {
                throw new EntryPointNotFoundException();
            }

            return ReturnPersonListByName;
        }

        public void Create(Person person)
        {
            persons = ReadFile("MyFile1.dat");
            if (person == null)
            {
                throw new ArgumentNullException("No Data");
           }
            if (persons.Count > 0)
            {
                nextId = persons.Max(d => d.Id);
                nextId++;
            }
            
            person.Id = nextId;
            persons.Add(person);
            SaveReadToFile.Serialize(persons, "MyFile1.dat");
        }

        public bool Update(Person person)
        {
            persons = ReadFile("MyFile1.dat");
            bool updateSuccess = false;
            if (person == null)
            {
                throw new ArgumentNullException("No data");
            }
            int index = persons.FindIndex(p => p.Id == person.Id);
            if (index == -1)
            {
                updateSuccess =  false;
            }
            else
            {
                persons.RemoveAt(index);
                persons.Add(person);
                SaveReadToFile.Serialize(persons, "MyFile1.dat");
            }
            
            return updateSuccess;
        }

        public bool Delete(Person person)
        {
            bool delateSuccess = false;
            persons = ReadFile("MyFile1.dat");

            try
            {
                persons.RemoveAll(p => p.Id == person.Id);
                SaveReadToFile.Serialize(persons, "MyFile1.dat");
                delateSuccess = true;
            }
            catch
            { 
                throw new EntryPointNotFoundException();
            }
   
            return delateSuccess;
        }

        private static List<Person> ReadFile(string path)
        {
            List<Person> personsDeserialize = new List<Person>();

            if (fileExist || null != (List<Person>)SaveReadToFile.Deserialize(path))
            {
               fileExist = true;
               personsDeserialize = (List<Person>)SaveReadToFile.Deserialize(path);
            }
            
            //if (null != (List<Person>)SaveReadToFile.Deserialize(path))
            //{
            //    personsDeserialize = (List<Person>)SaveReadToFile.Deserialize(path);

            //}
            return personsDeserialize;
        }

    }
}
