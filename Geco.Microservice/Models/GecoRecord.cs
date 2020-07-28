using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geco.Microservice.Models
{
    public class GecoRecordAll
    {
        public DateTime Date { get; set; }
        public string Month { get; set; }
        public int CompanyId { get; set; }
        public double Value { get; set; }
    }
}
