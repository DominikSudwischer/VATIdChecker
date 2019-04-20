using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATIdChecker.Models;
using VIESSOAPAPI;

namespace VATIdChecker.VIES
{
    /// <summary>
    /// Connect to the VIES SOAP API using the official WSDL file.
    /// </summary>
    public class VIESConnector : IVIESConnector
    {
        checkVatPortTypeClient _client;

        public VIESConnector()
        {
            _client = new checkVatPortTypeClient();
        }

        /// <summary>
        /// Update a CompanyModel instance using the data from the webservice. This updates the "Vies" fields, the "valid" field
        /// and the LastWebServiceCall field.
        /// </summary>
        /// <param name="company">A CompanyModel instance that should be updated.</param>
        /// <returns></returns>
        public async Task<CompanyModel> UpdateCompanyAsync(CompanyModel company)
        {
            var request = new checkVatRequest(company.VatIdentNo.Substring(0, 2), company.VatIdentNo.Substring(2));
            var response = await _client.checkVatAsync(request);

            company.ViesName = response.name;
            company.ViesAddress = response.address;
            company.Valid = response.valid;
            company.LastWebServiceCall = response.requestDate;
            return company;
        }

        /// <summary>
        /// Updates multiple companies sequentially with a given delay between requests.
        /// </summary>
        /// <param name="companies">An IEnumerable implementation instance of CompanyModels to update.</param>
        /// <param name="secondsBetweenRequests">The delay between consecutive requests.</param>
        /// <returns></returns>
        public async Task<IEnumerable<CompanyModel>> UpdateCompaniesAsync(IEnumerable<CompanyModel> companies,
            double secondsBetweenRequests)
        {
            var list = new List<CompanyModel>();
            var lastRequest = DateTime.Now.AddSeconds(-secondsBetweenRequests);

            foreach(var company in companies)
            {
                // We wait until the specified waiting time is over before proceeding with the next request.
                // If the waiting time is less than what the actual API call takes, we will not wait at all.
                var waitSeconds = secondsBetweenRequests - (DateTime.Now - lastRequest).TotalSeconds;
                await Task.Delay((int)(1000 * Math.Max(waitSeconds, 0.0)));
                lastRequest = DateTime.Now;
                list.Add(await UpdateCompanyAsync(company));
            }
            return list;
        }
    }
}
