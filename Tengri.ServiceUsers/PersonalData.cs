﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengri.ServiceUsers
{
    public class PersonalData
    {
        public int Iin { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public bool Gender { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
