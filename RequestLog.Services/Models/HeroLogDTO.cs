using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestLog.Services.Models
{
    public class HeroLogDTO
    {
        public int Id { get;  set; }
        public string RequestBody { get;  set; }
        public string Operation { get;  set; }
        public DateTime DateInsert { get; set; }
        public DateTime DateUpdate { get;  set; }
    }
}
