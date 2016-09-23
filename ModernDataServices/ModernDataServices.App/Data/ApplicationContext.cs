using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernDataServices.App.Models.Data;

namespace ModernDataServices.App.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {
            
        }

        DbSet<Person> Persons { get; set; }
        DbSet<Address> Addresses { get; set; }
        DbSet<Phone> Phones { get; set; }
        DbSet<Email> Emails { get; set; }
    }
}
