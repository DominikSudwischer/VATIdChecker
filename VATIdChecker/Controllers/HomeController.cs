using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VATIdChecker.Data;
using VATIdChecker.Models;
using VATIdChecker.VIES;

namespace VATIdChecker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<ActionResult<CompanyModel>> GetFirstSupplier()
        {
            CompanyModel company = await _context.Companies.FindAsync(1612345L);
            var comps = _context.Companies.Where(x => x.LastWebServiceCall == null || x.LastWebServiceCall <= DateTime.Parse("2018-01-01"));
            var connector = new VIESConnector();
            await connector.UpdateCompaniesAsync(comps, 20.0);
            await _context.SaveChangesAsync();

            if(company != null)
            {
                ViewData["Message"] = company.Name;
                return View();
            }
            else
            {
                throw new Exception("Supplier not found!");
            }
        }
    }
}
