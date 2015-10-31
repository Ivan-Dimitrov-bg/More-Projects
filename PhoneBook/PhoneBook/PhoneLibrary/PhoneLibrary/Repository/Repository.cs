namespace PhoneLibrary.Repository
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Threading.Tasks;

    public class Repository : IRepository
    {         
        private int nextId = 1;
        private string filePath;

        public Repository(string path)
        {
            this.filePath = path;
        }

        public List<Person> GetAll()
        {
            List<Person> allPersons = ReadFile(this.filePath);
            allPersons = allPersons.OrderBy(p => p.FirstName).ToList();
            return allPersons;
        }

        public List<Person> GetAll(string orderByField, string orderByCriteria)
        {
            List<Person> allPersons = ReadFile(this.filePath);
            switch (orderByField)
            {
                case "firstname":
                    switch (orderByCriteria)
                    {
                        case "a-z":
                            allPersons = allPersons.OrderBy(p => p.FirstName).ToList();
                            break;
                        case "z-a":
                            allPersons = allPersons.OrderByDescending(p => p.FirstName).ToList();
                            break;
                        default:
                            break;
                    }

                    break;
                case "lastname":
                    switch (orderByCriteria)
                    {
                        case "a-z":
                            allPersons = allPersons.OrderBy(p => p.LastName).ToList();
                            break;
                        case "z-a":
                            allPersons = allPersons.OrderByDescending(p => p.LastName).ToList();
                            break;
                        default:
                            break;
                    }

                    break;
                default:
                    break;
            }

            return allPersons;
        }

        public Person Get(int id)
        {

            List<Person> allPersons = ReadFile(this.filePath);
            Person person = allPersons.Find(p => p.Id == id);
            return person;
        }

        public List<Person> GetByName(string name)
        {
            List<Person> allPersons = ReadFile(this.filePath);
            List<Person> matchedPersons = allPersons.Where(p => p.FirstName == name || p.LastName == name).ToList();
            return matchedPersons;
        }

        public void Create(Person person)
        {
            List<Person> allPersons = ReadFile(this.filePath);
            if (allPersons.Any())
            {
                this.nextId = allPersons.Max(d => d.Id);
                this.nextId++;
            }
            
            person.Id = this.nextId;
            allPersons.Add(person);
            SaveReadToFile.Serialize(allPersons, this.filePath);
        }

        public bool Update(Person person)
        {
            List<Person> allPersons = ReadFile(this.filePath);
            allPersons = ReadFile(this.filePath);
            bool updateSuccess = false;

            Person selectedPerson = allPersons.Find(p => p.Id == person.Id);
            if (selectedPerson != null)
            {
                allPersons.Remove(selectedPerson);
                allPersons.Add(person);
                SaveReadToFile.Serialize(allPersons, this.filePath);
                updateSuccess = true;
            }
            
            return updateSuccess;
        }

        public bool Delete(Person person)
        {
            List<Person> allPersons = ReadFile(this.filePath);
            bool delateSuccess = false;
            Person selectedPerson = allPersons.Find(p => p.Id == person.Id);
            allPersons.Remove(selectedPerson);
            SaveReadToFile.Serialize(allPersons, this.filePath);
            delateSuccess = true;           
            return delateSuccess;
        }

        public void DeleteByID(int id)
        {
            List<Person> allPersons = ReadFile(this.filePath);
            allPersons = ReadFile(this.filePath);
            Person selectedPerson = allPersons.Find(p => p.Id == id);
            allPersons.Remove(selectedPerson);
            SaveReadToFile.Serialize(allPersons, this.filePath);
        }
        
        private List<Person> ReadFile(string path)
        {
            List<Person> personsDeserialize = new List<Person>();
            if (File.Exists(path))
            {
                personsDeserialize = (List<Person>)SaveReadToFile.Deserialize(path);
            }

            return personsDeserialize;
        }
    }
}
