using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeZone.Core.Entities.Commons;

namespace TimeZone.Core.Entities
{
    public class Blog:BaseEntity
    {
        public string BlogImage { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
