using System;
using System.Collections.Generic;
using System.Text;

namespace LittleDelightShop
{
    public abstract class Product
    {
        public Product(Guid itemId, string name, DateTime? bestBefore, decimal offsetCofficient, decimal originalPrice)
        {

            ItemId = itemId;
            Name = name;
            BestBefore = bestBefore;
            OffsetCofficient = offsetCofficient;
            OriginalPrice = originalPrice;

        }
        public virtual Guid ItemId { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal OriginalPrice { get; set; }
        public virtual DateTime? BestBefore { get; set; } //Guess that wine could have unlimited
        public virtual DateTime DateOfProduction { get; set; }
        public virtual int OffsetInDays => (int)Math.Floor((DateTime.Now.Date - (DateTime)BestBefore?.Date).TotalDays);
        public virtual decimal OffsetCofficient { get; set; }

        public virtual decimal GetFinalPrice()
        {
        
            return OriginalPrice;

        }

    }
    public class Milk : Product
    {
        public Milk(Guid itemId, string name, DateTime? bestBefore, decimal offsetCofficient, decimal originalPrice) : base(itemId, name, bestBefore, offsetCofficient, originalPrice)
        {
        }       
        public override decimal OriginalPrice => 3.70M;
        public override decimal GetFinalPrice()
        {          
        
            if (OffsetInDays <= 1)
                return base.GetFinalPrice();

            var finalPrice = OriginalPrice;
            for (var i = 1; i <= OffsetInDays; i++)
            {
                if (i == 1)
                    finalPrice *= 0.5M;
                else
                    finalPrice *= OffsetCofficient;//0.85M;
            }
            return finalPrice;


        }
    }
    public class Fish : Product
    {
      
        public Fish(Guid itemId, string name, DateTime bestBefore, decimal offsetCofficient, decimal originalPrice) : base(itemId, name, bestBefore, offsetCofficient, originalPrice)
        {
        }

        public override decimal OriginalPrice => 5M;
        public override decimal GetFinalPrice()
        {
       
            if (OffsetInDays <= 1)
                return OriginalPrice;

            var finalPrice = OriginalPrice;
            for (var i = 1; i <= OffsetInDays; i++)
            {
                finalPrice *= OffsetCofficient;// 0.9M;
            }
            return finalPrice;


        }
    }
    public class Wine : Product
    {
        public decimal MaximumPrice { get; set; }
        public override int OffsetInDays => (int)Math.Floor((DateTime.Now.Date - (DateTime)DateOfProduction.Date).TotalDays);
        public Wine(Guid itemId, string name, DateTime? bestBefore, DateTime dateOfProduction, decimal offsetCofficient, decimal originalPrice, decimal maximumPrice) : base(itemId, name, bestBefore, offsetCofficient, originalPrice)
        {
            DateOfProduction = dateOfProduction;
            MaximumPrice = maximumPrice;
        }

        public override decimal GetFinalPrice()
        {

            if (OffsetInDays <= 1)
                return OriginalPrice;

            var finalPrice = OriginalPrice;
            for (var i = 1; i <= OffsetInDays; i++)
            {
                finalPrice += OffsetCofficient;
                if (finalPrice >= MaximumPrice)
                {
                    finalPrice = MaximumPrice;
                    break;
                }
            }
            return finalPrice;


        }
    }
    public class RedWine : Wine
    {
        public RedWine(Guid itemId, string name, DateTime? bestBefore, DateTime dateOfProduction, decimal offsetCofficient, decimal originalPrice, decimal maximumPrice) : base(itemId, name, bestBefore, dateOfProduction, offsetCofficient, originalPrice, maximumPrice)
        {
        }
    }
    public class SparklingWine : Wine
    {
        public SparklingWine(Guid itemId, string name, DateTime? bestBefore, DateTime dateOfProduction, decimal offsetCofficient, decimal originalPrice, decimal maximumPrice) : base(itemId, name, bestBefore, dateOfProduction, offsetCofficient, originalPrice, maximumPrice)
        {
        }
    }
}