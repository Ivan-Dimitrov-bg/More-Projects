namespace PhoneLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;

    [Serializable]
    [DataContract]
    public class Person
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public int PhoneCount { get; set; }
        [DataMember]
        public List<Phone> Phones { get; set; }

        public override bool Equals(object obj)
        {
            Person person = obj as Person;

            if (person == null)
            {
                return false;
            }

            return this.Id == person.Id;
        }
    }
}
