using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichApp.Models.Models
{
    public class Timesheet
    {
        [Key]
        public int Id { get; set; } 
        public DateTime? Checkin { get; set; }
        public DateTime? Checkout { get; set; }
        public TimeSpan? TimeSpent { get; set; }
    }
}
