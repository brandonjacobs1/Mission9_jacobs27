using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_jacobs27.Models
{
    public class Cart
    {
        public List<CartLineItem> Items { get; set; } = new List<CartLineItem>();

        public void AddItem(Book book, int quantity)
        {
            CartLineItem line = Items
                .Where(x => x.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new CartLineItem
                {
                    Book = book,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public double CalculateTotal()
        {
            double total = Items.Sum(p => p.Quantity * p.Book.Price);

            return total;
        }
        

    }
    public class CartLineItem
    {
        public int LineItemID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
