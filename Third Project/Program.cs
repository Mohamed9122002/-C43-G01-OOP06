using Microsoft.VisualBasic;
using System.Diagnostics.Metrics;

namespace Third_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region    Part 4: Integration
            //Write a program that:
            //o Ask the user to input their type(Regular, Premium, or Guest).
            //o Allows the user to input product details(price and quantity).
            //o Calculates and displays the total discount and final price after applying the
            //appropriate discoun

            Console.WriteLine("Enter your type (Regular, Premium, or Guest): ");
            string? userType = Console.ReadLine();
            User user;
            switch (userType?.ToLower())
            {
                case "regular":
                    user = new RegularUser("Regular User");
                    break;
                case "premium":
                    user = new PremiumUser("Premium User");
                    break;
                case "guest":
                    user = new GuestUser("Guest User");
                    break;
                default:
                    throw new ArgumentException("Invalid user type");
            }

            decimal price;
            do
            {
                Console.WriteLine("Please Enter Product Price");
            }
            while (!decimal.TryParse(Console.ReadLine(), out price));
            int quantity;
            do
            {
                Console.WriteLine("Please Enter Product quantity");
            }
            while (!int.TryParse(Console.ReadLine(), out quantity));
            Discount discount = user.GetDiscount();
            decimal discountAmount = discount.CalculateDiscount(price, quantity);
            decimal finalPrice = (price*quantity) - discountAmount;
            Console.WriteLine(discountAmount);
            Console.WriteLine(finalPrice);


            #endregion
        }
    }
}

