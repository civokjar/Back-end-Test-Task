using LittleDelightShop;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace UnitTests.LittleDelightShop
{
    [TestFixture]
    public class CartCalculatorTest
    {
        private Mock<Store> _store { get; set; }
        private static Guid freshMilkId = new Guid("6ed9b26e-3022-419a-8dc3-680363cbdb7c");
        private static Guid twoDaysOverBestBeforeDateMilkId = new Guid("3d2ffa10-a140-4070-a7fe-eb55de422a0b");
        private static Guid twoDaysOverBestBeforeDateFishId = new Guid("a65823f3-15dc-4df7-bca2-52657b298f88");
        private static Guid tenYearsOldRedWineId = new Guid("1df6cfbd-c96c-413a-9103-a38aa3467d24");
        private static Guid hundredAndTwelveDaysOldRedWineId = new Guid("2f3eaa1d-34f8-48f4-a2fb-b33454fcf46d");
        private static Guid ThirtyDaysOldSparklingWineId = new Guid("e185d077-39db-4e01-aceb-eb759beddd53");
        [OneTimeSetUp]
        public void Setup()
        {
            Mock<Store> store = new Mock<Store>();
            store.Setup(x => x.StoreItems).Returns(GetAvailableStoreItems());
            _store = store;


        }
        private List<Product> GetAvailableStoreItems()
        {
            return new List<Product>
            {
                new Milk(freshMilkId, "Happy Cow Milk", DateTime.Now.AddDays(10), 0.85M, 3.7M),
                new Milk(twoDaysOverBestBeforeDateMilkId, "Happy Cow Milk", DateTime.Now.AddDays(-2), 0.85M, 3.7M),
                new Fish(twoDaysOverBestBeforeDateFishId, "Happy Fish", DateTime.Now.AddDays(-2), 0.9M, 5M),
                new RedWine(tenYearsOldRedWineId, "Old grandma red wine", null, DateTime.Now.AddYears(-10), 1, 5, 200),
                new RedWine(hundredAndTwelveDaysOldRedWineId, "Old grandma red wine", null, DateTime.Now.AddDays(-112), 1, 5, 200),
                new SparklingWine(ThirtyDaysOldSparklingWineId, "Old grandma sparkling wine",null, DateTime.Now.AddDays(-30), 1, 7, 200)
            };
        }
        [TestCase]
        public void CalculateCart()
        {
            var _cartClassInstance = new Cart(_store.Object);

            _cartClassInstance.AddItem(freshMilkId, 1);
            _cartClassInstance.AddItem(twoDaysOverBestBeforeDateMilkId, 1);
            _cartClassInstance.AddItem(twoDaysOverBestBeforeDateFishId, 2);
            _cartClassInstance.AddItem(tenYearsOldRedWineId, 1);
            _cartClassInstance.AddItem(hundredAndTwelveDaysOldRedWineId, 2);
            _cartClassInstance.AddItem(ThirtyDaysOldSparklingWineId, 1);

            var _checkoutClassInstance = new Checkout();
            _checkoutClassInstance.CreateReceipt(_cartClassInstance);
            Assert.AreEqual(_checkoutClassInstance.Total, 484.37250);


        }

    }
}
