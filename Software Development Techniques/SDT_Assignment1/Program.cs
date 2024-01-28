// Student Details::

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("**************************************");
        Console.WriteLine(
            "Name: Priyanka Jerambhai Vithani \nStudent number:  8875646 \nEmail: Pvithani5646@conestogac.on.ca"
        );
        Console.WriteLine("**************************************\n");

        // Define grocery items price
        float applePrice = 1.00F;
        float bananaPrice = 0.50F;
        float milkPrice = 2.50F;
        float breadPrice = 2.00F;
        float eggsPrice = 1.75F;

        // Show available grovery items
        Console.WriteLine("Available Grocery Items:");
        Console.WriteLine($"Apple - ${applePrice}");
        Console.WriteLine($"Banana - ${bananaPrice}");
        Console.WriteLine($"Milk - ${milkPrice}");
        Console.WriteLine($"Bread - ${breadPrice}");
        Console.WriteLine($"Eggs - ${eggsPrice}\n");

        // initialise quantities
        int appleQty = 0;
        int bananaQty = 0;
        int milkQty = 0;
        int breadQty = 0;
        int eggQty = 0;

        // Get item quantities from the user

        do
        {
            Console.Write("Enter the quantity of Apple (0 for none): ");
        } while (!int.TryParse(Console.ReadLine(), out appleQty));

        do
        {
            Console.Write("Enter the quantity of Banana (0 for none): ");
        } while (!int.TryParse(Console.ReadLine(), out bananaQty));

        do
        {
            Console.Write("Enter the quantity of Milk (0 for none): ");
        } while (!int.TryParse(Console.ReadLine(), out milkQty));

        do
        {
            Console.Write("Enter the quantity of Bread (0 for none): ");
        } while (!int.TryParse(Console.ReadLine(), out breadQty));
        do
        {
            Console.Write("Enter the quantity of Eggs (0 for none): ");
        } while (!int.TryParse(Console.ReadLine(), out eggQty));

        // ask user if he/she has a loyalry card
        string loyaltyCard = "";
        do
        {
            Console.Write("\nDo you have a loyalty card? (yes/no): ");
            loyaltyCard = Console.ReadLine();
            if (loyaltyCard != null)
            {
                loyaltyCard = loyaltyCard.ToLower();
            }
        } while (!(loyaltyCard == "yes" || loyaltyCard == "no"));

        // initialize final price values
        double subtotal = 0.0;
        double discountedPrice = 0.0;
        double taxPrice = 0.0;

        /*  
            Show Receipt to User
            Show Items purchased by user
            Calculate Discount(if applicable), Tax, FinalTotal
        */
        Console.WriteLine("\n**************************************");
        Console.WriteLine("Receipt: \n");
        if (appleQty > 0)
        {
            Console.WriteLine($"Apple x {appleQty}");
        }
        if (bananaQty > 0)
        {
            Console.WriteLine($"Banana x {bananaQty}");
        }
        if (milkQty > 0)
        {
            Console.WriteLine($"Milk x {milkQty}");
        }
        if (breadQty > 0)
        {
            Console.WriteLine($"Bread x {breadQty}");
        }
        if (eggQty > 0)
        {
            Console.WriteLine($"Eggs x {eggQty}");
        }
        Console.WriteLine("\n");
        subtotal =
            applePrice * appleQty
            + bananaPrice * bananaQty
            + milkPrice * milkQty
            + breadPrice * breadQty
            + eggsPrice * eggQty; // calculate subtotal
        Console.WriteLine($"Subtotal: ${subtotal}"); // display subtotal
        if (loyaltyCard.ToLower() == "yes")
        {
            Console.WriteLine($"Discount: ${subtotal * 10 / 100}"); // display discount calculation
            discountedPrice = Math.Round(subtotal - subtotal * 10 / 100, 2); // calculate price after discount
            taxPrice = Math.Round(discountedPrice * 13 / 100, 2); // calculate tax price
            Console.WriteLine($"Tax(13%): ${taxPrice}");
            Console.WriteLine($"Total Cost: ${discountedPrice + taxPrice}"); // calculate final total
        }
        else
        {
            taxPrice = Math.Round(subtotal * 13 / 100, 2); // calculate tax price
            Console.WriteLine($"Tax(13%): ${taxPrice}");
            Console.WriteLine($"Total Cost: ${subtotal + taxPrice}"); // calculate final total

        }
        Console.WriteLine("**************************************\n\n\n");
    }
}