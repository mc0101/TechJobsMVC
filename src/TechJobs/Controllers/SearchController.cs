using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }
        
       
        public IActionResult Results(string searchType, string searchTerm)
        {
            var value = Request.Form["searchTerm"];
            var column = Request.Form["searchType"];
            if (!searchType.Equals("all"))
            {
                
                List<Dictionary<string, string>> results = JobData.FindByColumnAndValue(column, value);
                ViewBag.jobs = results;
                ViewBag.columns = ListController.columnChoices;
                ViewBag.title = "Search Results";
                return View("Index");
            }
            else
            {
                List<Dictionary<string, string>> jobs = JobData.FindByValue(searchTerm);
                ViewBag.jobs = jobs;
                ViewBag.title = "Search Results";
                ViewBag.columns = ListController.columnChoices;
                return View("Index");

            }
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        
    }
}
