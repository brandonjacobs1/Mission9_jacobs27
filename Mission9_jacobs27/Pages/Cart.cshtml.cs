using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission9_jacobs27.Models;
using Mission9_jacobs27.Sessions;

namespace Mission9_jacobs27.Pages
{
    
    // Attributes and methods for cart
   
    public class CartModel : PageModel
    {
        private IBookstoreRepository _repo { get; set; }

        public CartModel (IBookstoreRepository repo)
        {
            _repo = repo;
        }
        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        public IActionResult OnPost(int BookId, string returnUrl)
        {
            Book book = _repo.Books.FirstOrDefault(x => x.BookId == BookId);
            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            cart.AddItem(book, 1);

            HttpContext.Session.SetJson("cart", cart);

            return RedirectToPage(new { ReturnUrl = returnUrl });


        }
    }
}
