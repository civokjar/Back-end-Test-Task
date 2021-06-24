using System;
using System.Collections.Generic;
using System.Text;

namespace LittleDelightShop
{
    public interface ICheckout
    {
        decimal Total { get; set; }
        void CreateReceipt(ICart cart);
    }
    public class Checkout : ICheckout
    {
        public Checkout()
        {
            Total = 0;
        }
        public List<CartItem> CheckOutItems { get; set; }
        public decimal Total { get; set; }
        public void CreateReceipt(ICart cart)
        {
            if (cart.Items == null)            
                return;
           
            //We could use this property for printing purposes
            CheckOutItems = cart.Items;
           
            foreach (var cartItem in cart.Items) 
            {
                Total += cartItem.Product.GetFinalPrice() * cartItem.Quantity;
                //string consoleLine = $"{cartItem.Product.Name} Quantity : x{cartItem.Quantity}  Price:{priceOfTheCurrentItems}";
                //Console.WriteLine(consoleLine);
            }           
        }
    }
 
}
