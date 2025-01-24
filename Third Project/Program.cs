namespace Third_Project
{
    internal class Program
    {
        #region Third Project
        public abstract class Discount
        {
            public string? Name { get; set; }
            public abstract decimal CalculateDiscount(decimal price, int quantity);
        }


        public class PercentageDiscount : Discount
        {
            public decimal Percentage { get; set; }

            public PercentageDiscount(decimal percentage)
            {
                Name = "Percentage Discount";
                Percentage = percentage;
            }

            public override decimal CalculateDiscount(decimal price, int quantity)
            {
                return price * quantity * (Percentage / 100);
            }
        }

        public class FlatDiscount : Discount
        {
            public decimal FlatAmount { get; set; }

            public FlatDiscount(decimal flatAmount)
            {
                Name = "Flat Discount";
                FlatAmount = flatAmount;
            }

            public override decimal CalculateDiscount(decimal price, int quantity)
            {
                return FlatAmount * Math.Min(quantity, 1);
            }
        }

        public class BuyOneGetOneDiscount : Discount
        {
            public BuyOneGetOneDiscount()
            {
                Name = "Buy One Get One Discount";
            }

            public override decimal CalculateDiscount(decimal price, int quantity)
            {
                return (price / 2) * (quantity / 2);
            }
        }


        public abstract class User
        {
            public string? Name { get; set; }
            public abstract Discount GetDiscount();
        }

        public class RegularUser : User
        {
            public override Discount GetDiscount()
            {
                return new PercentageDiscount(5);
            }
        }

        public class PremiumUser : User
        {
            public override Discount GetDiscount()
            {
                return new FlatDiscount(100);
            }
        }

        public class GuestUser : User
        {
            public override Discount GetDiscount()
            {
                return null; // No discount for guest users
            }
        }

        #endregion
        static void Main(string[] args)
        {
            #region Third Project
            Console.WriteLine("Enter user type (Regular, Premium, Guest):");
            string userType = Console.ReadLine();

            User user;
            switch (userType?.ToLower())
            {
                case "regular":
                    user = new RegularUser { Name = "Regular User" };
                    break;
                case "premium":
                    user = new PremiumUser { Name = "Premium User" };
                    break;
                case "guest":
                    user = new GuestUser { Name = "Guest User" };
                    break;
                default:
                    Console.WriteLine("Invalid user type.");
                    return;
            }

            Console.WriteLine("Enter product price:");
            decimal price;
            while (!decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Invalid input. Please enter a valid price.");
            }

            Console.WriteLine("Enter product quantity:");
            int quantity;
            while (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Invalid input. Please enter a valid quantity.");
            }

            Discount discount = user.GetDiscount();
            decimal discountAmount = discount?.CalculateDiscount(price, quantity) ?? 0;
            decimal finalPrice = (price * quantity) - discountAmount;

            Console.WriteLine($"Total Discount: {discountAmount:C}");
            Console.WriteLine($"Final Price: {finalPrice:C}");



            #endregion
        }
    }
}
