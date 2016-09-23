using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernDataServices.App.Models.Resources
{
    public class PersonResource
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public List<AddressResource> Addresses { get; set; }
        public List<PhoneResource> Phones { get; set; }
        public List<EmailResource> EmailAddresses { get; set; }

        public List<Link> Links { get; set; }
    }
}
