﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Mission9_jacobs27.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mission9_jacobs27.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("cart") ?? new SessionCart();
            cart.Session = session;

            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }
        
        public override void AddItem(Book book, int quantity)
        {
            base.AddItem(book, quantity);
            Session.SetJson("cart", this);
        }
        public override void RemoveItem(Book book)
        {
            base.RemoveItem(book);
            Session.SetJson("cart", this);
        }
        public override void EmptyCart()
        {
            base.EmptyCart();
            Session.Remove("cart");
        }
    }
}
