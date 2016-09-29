using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernDataServices.App.Models.Data
{
    public class LogTable
    {
        [Key]
        public long Id                { get; set; }
        public string ApplicationName { get; set; }
        public DateTime Time_Stamp    { get; set; }
        public string Level           { get; set; }
        public string Logger          { get; set; }
        public string Message         { get; set; }
        public string Verbose         { get; set; }
    }
}
