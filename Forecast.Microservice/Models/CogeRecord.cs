using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forecast.Microservice.Models
{
    public class CogeRecordAll
    {
        public DateTime Date { get; set; }
        public string Month { get; set; }
        public int CompanyId { get; set; }
        public double Value { get; set; }
    }
    public class CogeRecordBU1
    {
        public DateTime Date { get; set; }
        public string Month { get; set; }
        public int CompanyId { get; set; }
        public double Value { get; set; }
    }
    public class CogeRecordBU2
    {
        public DateTime Date { get; set; }
        public string Month { get; set; }
        public int CompanyId { get; set; }
        public double Value { get; set; }
    }
}