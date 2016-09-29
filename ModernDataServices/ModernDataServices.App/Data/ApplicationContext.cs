using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernDataServices.App.Models.Data;

namespace ModernDataServices.App.Data
{
    /// <summary>
    /// The EF Db Context
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationContext"/> class.
        /// </summary>
        public ApplicationContext() : base("DefaultConnection")
        {
            
        }

        /// <summary>
        /// Gets or sets the persons.
        /// </summary>
        /// <value>
        /// The persons.
        /// </value>
        public DbSet<Person> Persons { get; set; }

        /// <summary>
        /// Gets or sets the addresses.
        /// </summary>
        /// <value>
        /// The addresses.
        /// </value>
        public DbSet<Address> Addresses { get; set; }

        /// <summary>
        /// Gets or sets the phones.
        /// </summary>
        /// <value>
        /// The phones.
        /// </value>
        public DbSet<Phone> Phones { get; set; }

        /// <summary>
        /// Gets or sets the emails.
        /// </summary>
        /// <value>
        /// The emails.
        /// </value>
        public DbSet<Email> Emails { get; set; }

        /// <summary>
        /// Gets or sets the log table. - NLOG
        /// </summary>
        /// <value>
        /// The log table.
        /// </value>
        public DbSet<LogTable> LogTable { get; set; }
    }
}
