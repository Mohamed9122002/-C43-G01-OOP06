using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Third_Project
{
    #region Part 1: Abstract Discount Class
//    Create an abstract class Discount with:
// An abstract method CalculateDiscount(decimal price, int quantity) that returns the
//discount amount based on the original price and quantity.
//A Name property to store the type of discount.
    internal abstract class Discount
    {
        public string? Name { get; set; }
        public abstract decimal CalculateDiscount(decimal price, int quantity);
    }
    #endregion
    #region Part 2: Specific Discounts
    //Implement the following concrete discount classes:
    #region PercentageDiscount
            //▪ Accepts a percentage(e.g., 10%).
            //▪ Formula: Discount Amount = Price×Quantity×(Percentage/100)
    class PercentageDiscount : Discount
    {

        public decimal Percentage { get; set; }

        public PercentageDiscount(decimal percentage)
        {
            Name = "Percentage Discount";
            Percentage = percentage;
        }

        public override decimal CalculateDiscount(decimal price, int quantity)
        {
            return price * quantity * (Percentage / 100) ;
        }

    }
    #endregion
    #region FlatDiscount:
    //▪ Accepts a fixed amount to be deducted(e.g., $50).
    //▪ Formula: Discount Amount = Flat Amount×min(Quantity, 1)
    class FlatDiscount : Discount
    {
        public decimal FlatAmount { get; set; }
        public FlatDiscount(decimal flatAmount)
        {
            this.Name = "Flat Discount";
            this.FlatAmount = flatAmount;
        }
        public override decimal CalculateDiscount(decimal price, int quantity)
        {
           return FlatAmount * Math.Min(quantity, 1);
        }
    }

    #endregion
    #region BuyOneGetOneDiscount
    //Applies a 50% discount if the quantity is greater than 1.
    //Formula: Discount Amount = (Price / 2)×(Quantity÷2)
    class BuyOneGetOneDiscount : Discount
    {
        public BuyOneGetOneDiscount()
        {
            Name = "Buy One Get One Discount";
        }
        public override decimal CalculateDiscount(decimal price, int quantity)
        {
            if (quantity > 1)
            {
                return (price / 2) * (quantity /2 );
            }
            return 0;
        }
    }
    #endregion
    #region Part 3: Discount Applicability
    //Create an abstract class User with
    //    A Name property to store the user name
    //    An abstract method GetDiscount() that returns a Discount object

     abstract class  User
    {
        public string? Name { get; set; }
        public abstract Discount GetDiscount();
    }

    #region Implement the following specific user types:

    #region RegularUser: Applies a PercentageDiscount of 5%.

    class RegularUser : User
    {
        public RegularUser(string name)
        {
            Name = name;
        }
        public override Discount GetDiscount()
        {
            return new PercentageDiscount(5);
        }
    }
    #endregion
    #region PremiumUser: Applies a FlatDiscount of $100.

    class PremiumUser : User
    {
        public PremiumUser(string name)
        {
            Name = name;
        }
        public override Discount GetDiscount()
        {
            return new FlatDiscount(100);
        }
    }

    #endregion


    #region GuestUser: No discount is applied

    class GuestUser : User
    {
        public GuestUser(string name)
        {
            Name = name;
        }
        public override Discount GetDiscount()
        {
            return new PercentageDiscount(0);
        }
    }
    #endregion

    #endregion
  
    
    
    #endregion

    #endregion



}
