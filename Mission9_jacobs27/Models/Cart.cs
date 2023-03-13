using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_jacobs27.Models
{
    public class Cart
    {
        public List<CartLineItem> Items { get; set; } = new List<CartLineItem>();
        //Add new item
        public virtual void AddItem(Book book, int quantity)
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
        public virtual void RemoveItem(Book book)
        {
            Items.RemoveAll(x => x.Book.BookId == book.BookId);
        }
        public virtual void EmptyCart()
        {
            Items.Clear();
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
