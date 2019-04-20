using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VATIdChecker.Models
{
    /// <summary>
    /// A model to represent settings in the application.
    /// </summary>
    public class SettingsModel
    {
        [Key]
        public long Id { get; set; }

        public double SecondsBetweenRequests { get; set; }
    }
}
