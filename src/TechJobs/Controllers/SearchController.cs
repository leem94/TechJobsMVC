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
            ViewBag.searchTerm = ""; //if they enter nothing
            ViewBag.check = "All";
            return View();
        }

        // TODO #1 - Create a Results action method to process search request and display results
        // should take in two parameters, specifying the type of search and the search term
        [Route("/Search")]
        [HttpPost]

        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Dictionary<string, string>> jobs;
            ViewBag.columns = ListController.columnChoices;
            ViewBag.searchTerm = searchTerm;
            ViewBag.check = searchType;

            if (searchType.Equals("all"))
            {
                jobs = JobData.FindByValue(searchTerm);
                ViewBag.title = string.Format("Results for '{0}' in all categories", searchTerm);
            }

            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.title = string.Format("Results for '{0}' within {1} category", searchTerm, ListController.columnChoices[searchType]);
            }

            ViewBag.jobs = jobs;
            return View("Index");

        //public IActionResult Results(string searchType , string searchTerm)
        //{
            //if ( searchType == "" && searchTerm == "")
            //    { ViewBag.results = JobData.FindAll();
            //    return View();
            //}

            //else if (column == "")
            //    { ViewBag.results = JobData.FindByValue(value);
            //    return View();
            //}

            //else
            //    { ViewBag.results = JobData.FindByColumnAndValue(column,value);
            //    return View();
            //}

        }
    }
}
