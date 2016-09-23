using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernDataServices.App.Models.Data
{
    public class Phone
    {
        public int Id { get; set; }
        public string AreaCode { get; set; }
        public string Number { get; set; }
        public string Extension { get; set; }

        public virtual Person Person { get; set; }
    }
}
