﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookConslole
{
    [Serializable]
    public class Phone
    {
        public string Number { get; set; }
        public TypePhone TypePhone { get; set; }   
    }
}
