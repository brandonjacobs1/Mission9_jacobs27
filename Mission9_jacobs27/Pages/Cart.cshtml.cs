using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission9_jacobs27.Models;

namespace Mission9_jacobs27.Pages
{
    public class CartModel : PageModel
    {
        private IBookstoreRepository _repo { get; set; }

        public CartModel (IBookstoreRepository repo)
        {
            _repo = repo;
        }
        public Cart cart { get; set; }
        public void OnGet(Cart c)
        {
            cart = c;
        }
        public IActionResult OnPost(int BookId)
        {
            Book book = _repo.Books.FirstOrDefault(x => x.BookId == BookId);
            cart = new Cart();
            cart.AddItem(book, 1);

            return RedirectToPage(cart);


        }
    }
}
