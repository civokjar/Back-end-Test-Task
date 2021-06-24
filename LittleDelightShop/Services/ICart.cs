using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleDelightShop
{
    public interface ICart
    {
        /// <summary>
        /// Adds a new item into the shopping cart
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="quantity"></param>
        void AddItem(Guid itemId, int quantity);
        List<CartItem> Items { get; set; }

    }
    public class Cart : ICart
    {
        IStore _store;
        public Cart(IStore store) 
        {
            _store = store;
            Items = new List<CartItem>();
        }
        public List<CartItem> Items { get; set; }
        public void AddItem(Guid itemId, int quantity)
        {
            Items.Add(new CartItem { Product = _store.StoreItems.Where(t => t.ItemId == itemId).First(), Quantity = quantity });
        }
    }
}
