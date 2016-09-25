﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernDataServices.App.Models.Data
{
    public class Person
    {
        [Key]
        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }


        public List<Address> Addresses { get; set; }
        public List<Phone> Phones { get; set; }
        public List<Email> EmailAddresses { get; set; }

    }
}
