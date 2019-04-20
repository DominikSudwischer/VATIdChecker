using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATIdChecker.Models;

namespace VATIdChecker.VIES
{
    interface IVIESConnector
    {
        Task<CompanyModel> UpdateCompanyAsync(CompanyModel company);
    }
}
