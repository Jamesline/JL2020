﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Microservice.Entities
{
    public class Company: BaseEntity
    {
        public string Name { get; set; }
        public string Contact { get; set; }
    }
}
