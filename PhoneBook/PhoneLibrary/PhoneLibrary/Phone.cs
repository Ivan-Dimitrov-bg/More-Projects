namespace PhoneLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;
    
    [Serializable]
    [DataContract(Name = "Phone")]
    public class Phone
    {
        [DataMember]
        public string Number { get; set; }
        [DataMember]
        public TypePhone TypePhone { get; set; }
    }
}
