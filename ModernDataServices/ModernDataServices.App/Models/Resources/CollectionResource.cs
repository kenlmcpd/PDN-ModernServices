using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernDataServices.App.Models.Resources
{
    public class CollectionResource<T>  where T : class
    {
        public List<T> Collection { get; set; } 
        public List<Link> Links { get; set; } 
    }
}
