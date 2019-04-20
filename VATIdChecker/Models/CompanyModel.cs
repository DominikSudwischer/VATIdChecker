using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VATIdChecker.Data;

namespace VATIdChecker.Models
{
    /// <summary>
    /// Model class for a company. The properties starting with "VIES" are to be filled by calling the VIES API. All
    /// other non-timestamp properties should be provided by the ERP.
    /// </summary>
    public class CompanyModel
    {
        public CompanyModel() { }

        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string VatIdentNo { get; set; }

        public bool Valid { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }

        [MaxLength(2)]
        public string CountryCode { get; set; }

        [MaxLength(50)]
        public string ViesName { get; set; }

        [MaxLength(50)]
        public string ViesAddress { get; set; }

        public DateTime LastWebServiceCall { get; set; }

        public long Save(ApplicationDbContext context)
        {
            context.Companies.Add(this);
            context.SaveChanges();

            return this.Id;
        }

        
    }
}
