using System.Linq;
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

        public CartModel (IBookstoreRepository repo, Cart c)
        {
            _repo = repo;
            cart = c;
        }
        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(int BookId, string returnUrl)
        {
            Book book = _repo.Books.FirstOrDefault(x => x.BookId == BookId);

            cart.AddItem(book, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });


        }
        public IActionResult OnPostRemove(int bookID, string returnURL)
        {
            cart.RemoveItem(cart.Items.First(x => x.Book.BookId == bookID).Book);

            return RedirectToPage(new { ReturnUrl = returnURL });
        }
    }
}
