using LittleDelightShop;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleDelightShop
{
    public class Store : IStore
    {
        public Store()
        {      
        }
        //Could be added to the dictionary but ofc this is not real case scenario of product loading
        public virtual List<Product> StoreItems { get; set; }
              
    }

    public interface IStore
    {
        List<Product> StoreItems { get; set; }       
    }
}
