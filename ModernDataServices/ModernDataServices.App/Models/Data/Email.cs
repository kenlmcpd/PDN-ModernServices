using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernDataServices.App.Models.Data
{
    public class Email
    {
        public int Id { get; set; }
        public string Address { get; set; }

        public virtual Person Person { get; set; }
    }
}
