using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogLib
{
    public class EmpInfo
    {
        public int Id { get; set; }
        public string? EmailId { get; set; }
        public string? Name { get; set; }

        public DateTime DOJ { get; set; }

        public int PassCode { get; set; }
    }
}
