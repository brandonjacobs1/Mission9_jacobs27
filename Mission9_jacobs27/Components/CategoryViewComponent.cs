using Microsoft.AspNetCore.Mvc;
using Mission9_jacobs27.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_jacobs27.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private IBookstoreRepository _repo { get; set; }

        public CategoryViewComponent(IBookstoreRepository repo)
        {
            _repo = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.CatChoice = RouteData?.Values["category"];

            var Categories = _repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(Categories);
        }
       
    }
}
