using Microsoft.AspNetCore.Mvc;
using Mission9_jacobs27.Models;
using Mission9_jacobs27.Models.ViewModels;
using Mission9_jacobs27.TagHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace Mission9_jacobs27.Controllers
{// Using repository model
    public class HomeController : Controller
    {
        private IBookstoreRepository _repo;

        public HomeController(IBookstoreRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index(string category, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = _repo.Books
                .Where(c => c.Category == category || category == null)
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    Total = category == null ? _repo.Books.Count() : _repo.Books.Where(p => p.Category == category).Count(),
                    PageSize = pageSize,
                    CurrentPage = pageNum
                }

            };
            return View(x);
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
    }
}
