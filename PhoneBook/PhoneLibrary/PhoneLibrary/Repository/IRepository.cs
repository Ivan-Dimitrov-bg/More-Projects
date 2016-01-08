using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneLibrary.Repository
{
    public interface IRepository
    {
        List<Person> GetAll();
        Person Get(int id);
        List<Person> GetByName(string Name);
        void Create(Person person);
        bool Update(Person person);
        bool Delete(Person person);
    }
}
