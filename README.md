# Backend Challenge

# Problem
Welcome to the Little Delights shop. In our general store, people can buy selected goods
with the finest quality for reasonable prices. We want to modernize our internal IT-system to
be up to date with the latest standards.
Unfortunately, because we had a blackout on our main server, all source-code of the existing
system is gone (we had no version control). The only thing left are some interfaces that
describe the design of the two main classes involved. We need your help now to implement
the system against the existing interfaces to be able to sell goods again.
Here is a description of the most important use-cases:
- Customers should be able to add items to a cart
- For a given cart we need to give the customers a receipt that includes
- The name of each item in the cart
- The price of the each item in the cart
- The total price of the whole cart

# Interfaces
The following interfaces must be used for implementation, the existing methods cannot be
modified but it is possible to add additional methods or properties if needed.


public interface ICart
{

    /// <summary>
    /// Adds a new item into the shopping cart
    /// </summary>
    /// <param name="itemId">the item identifier</param>
    /// <param name="quantity">how many of this item should be added</param>
    void AddItem(Guid itemId, int quantity);

}

public interface ICheckout
{

    /// <summary>
    /// Creates a receipt for all items of the shopping cart
    /// </summary>
    /// <param name="cart">the shopping cart</param>
    void CreateReceipt(ICart cart);
    
}


Pricing
All of our items have a price (listed below) but there are a few different rules about how the
pricing is calculated.
We sell the following items in our store:
- Milk
- Price starts with 3.70
- 1 day after best-before date the price will drop immediately to 50%
- Every additional day the price will be decreased by another 15%
- Fish
- Price starts with 5
- Price decreases every day by 10%
- Wine
- Price of red wine starts from 5
- Price of sparkling wine starts from 7
- Price increases every day by 1
- Maximum price is 200

# Tests
We expect that the solution is thoroughly covered with unit tests to make sure the
requirements above are fulfilled and the system is working.

Testing Use-Case
To test that the system is working properly we will create a test which will do the following:
- Put the following items in the shopping cart:
- 1x Milk that is fresh
- 1x Milk that is 2 days over best-before date
- 2x Fish that are 2 days over best-before date
- 1x a 10 year old red wine
- 2x a 112 days old red wine
- 1x a 30 days old sparkling wine
- Create a receipt for the whole shopping cart and make sure nothing is forgotten and
the total price is correct
Prices for the given test-case:
Item Price
1x Milk (fresh) 3.7
1x Milk (2 days) 1.57
2x Fish (2 days) 8.1
1x Red Wine (10 years) 200
2x Red Wine (112 days) 234
1x Sparkling Wine (30 days) 37
Total Sum 484.37