internal class Program
{
    private static void Main(string[] args)
    {
        int selecetdOption = 0;
        // Initialize customer and add default customers.
        List<Customer> customers = new List<Customer>
        {
            new Customer(
                "8875646",
                "Priyanka Vithani",
                "647-822-8143",
                CustomerType.Regular,
                CarRental.standard,
                true
            ),
            new Customer(
                "987654",
                "Ruchit Vithani",
                "647-822-8144",
                CustomerType.VIP,
                CarRental.economy,
                true
            ),
            new Customer(
                "987987",
                "Jay Gabani",
                "647-822-8145",
                CustomerType.Premium,
                CarRental.luxury,
                true
            )
        };

        selectOption();
        // Print options and select one of them
        void selectOption()
        {
            do
            {
                Console.WriteLine("Choose an option below:");
                Console.WriteLine("\t1. Create a reservation");
                Console.WriteLine("\t2. List all reservations");
                Console.WriteLine("\t3. Clear all reservations");
                Console.WriteLine("\t4. Exit the program\n");
            } while (
                !int.TryParse(Console.ReadLine(), out selecetdOption)
                && selecetdOption > 0
                && selecetdOption < 5
            );
            switch (selecetdOption)
            {
                case 1:
                    GetCustomerInformation();
                    break;
                case 2:
                    listAllRecords();
                    break;
                case 3:
                    customers.Clear();
                    Console.WriteLine("Clear");
                    selectOption();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid input selected");
                    selectOption();
                    break;
            }
        }
        // Display all records added in list
        void listAllRecords()
        {
            var reservationNum = 1;
            foreach (var item in customers)
            {
                Console.WriteLine($"Reservation: {reservationNum}");
                Console.WriteLine($"Customer ID: {item.customerId}");
                Console.WriteLine($"Name: {item.name}");
                Console.WriteLine($"Phone Number: {item.phoneNumber}");
                Console.WriteLine($"Customer Type: {item.customerType}");
                Console.WriteLine($"Car Type: {item.carRental}");
                AdditionalService service = new AdditionalService(item.customerType);
                Console.WriteLine(
                    $"Additional Service: {(item.isWantAdditionalService ? service.SetService(item.customerType).Item1 : "None")}"
                );
                reservationNum++;
                Console.WriteLine("\n______________________________________________\n");
            }
            selectOption();
        }
        // Print customer types
        void printCustomerTypes()
        {
            Console.WriteLine("Customer Type: ");
            Console.WriteLine("\t1. Regular");
            Console.WriteLine("\t2. Premium");
            Console.WriteLine("\t3. VIP");
        }
        // Print rental types
        void printCarRentalTypes()
        {
            Console.WriteLine(
                "Choose the number corresponding to the car type the customer wants: "
            );
            Console.WriteLine("\t1. Economy - $29.99/day");
            Console.WriteLine("\t2. Standard - $49.99/day");
            Console.WriteLine("\t3. Luxury - $79.99/day");
        }
        // Display additional services
        void showAdditionalService(CustomerType type)
        {
            Console.WriteLine("Does the customer want this additional service? (yes/no)");
            switch (type)
            {
                case CustomerType.VIP:
                    Console.WriteLine("GPS Navigation - $9.99/day");
                    break;
                case CustomerType.Premium:
                    Console.WriteLine("Child Car Seat - $14.99/day");
                    break;
                case CustomerType.Regular:
                    Console.WriteLine("Chauffeur Service - $99.99/day");
                    break;
                default:
                    break;
            }
        }
        // Get customer details
        void GetCustomerInformation()
        {
            Console.WriteLine("\nEnter customer information: ");
            string? cid = "";
            do
            {
                if (cid!.Length != 6 && cid != "")
                {
                    Console.WriteLine("Please eneter 6 Digit Alpha-numeric id");
                }
                Console.Write("Customer ID: ");
                cid = Console.ReadLine();
            } while (cid!.Length != 6);
            Console.Write("Name: ");
            string? name = Console.ReadLine();
            int phnum = 0;
            do
            {
                Console.Write("Phone Number(valid 10 digit number): ");
            } while (!int.TryParse(Console.ReadLine(), out phnum) || $"{phnum}".Length != 10);

            printCustomerTypes();
            int custType;
            bool isValidCustType = true;
            // Check if customer type is valid or not
            while (isValidCustType)
            {
                if (
                    int.TryParse(Console.ReadLine(), out custType)
                    && Enum.IsDefined(typeof(CustomerType), custType)
                )
                {
                    CustomerType type = (CustomerType)custType;
                    printCarRentalTypes();
                    int carRental;
                    bool isneedAdditionalService;
                    string isrequired;
                    bool isValidCarRental = true;
                    // Check if car rental type is valid or not
                    while (isValidCarRental)
                    {
                        if (
                            int.TryParse(Console.ReadLine(), out carRental)
                            && Enum.IsDefined(typeof(CarRental), carRental)
                        )
                        {
                            CarRental rental = (CarRental)carRental;
                            do
                            {
                                showAdditionalService(type);
                                isrequired = Console.ReadLine()!;
                                isneedAdditionalService =
                                    isrequired.ToLower() == "yes" ? true : false;
                            } while (
                                !(isrequired.ToLower() == "yes" || isrequired.ToLower() == "no")
                            );
                            Customer cust = new Customer(
                                cid!,
                                name!,
                                $"{phnum}",
                                type,
                                rental,
                                isneedAdditionalService
                            );
                            Console.WriteLine("Thank you! The reservation was successful.");
                            customers.Add(cust);
                            selectOption();
                            isValidCarRental = false;
                        }
                        else
                        {
                            Console.WriteLine("Please enter valid car rental type");
                            printCarRentalTypes();
                        }
                    }
                    isValidCustType = false;
                }
                else
                {
                    Console.WriteLine("Please enter valid customer type");
                    printCustomerTypes();
                }
            }
        }
    }
}

// Customer class


class Customer
{
    // Customer properties
    public string? customerId;

    public string? name;
    public string? phoneNumber;
    public CustomerType customerType;
    public CarRental carRental;
    public bool isWantAdditionalService;

    // Methods
    public Customer(
        string cId,
        string nm,
        string phnum,
        CustomerType custType,
        CarRental carrental,
        bool additionalService
    )
    {
        customerId = cId;
        customerType = custType;
        name = nm;
        phoneNumber = phnum;
        carRental = carrental;
        isWantAdditionalService = additionalService;
    }
}

// Inherited customer class to get customer type
class AdditionalService : Customer
{
    // Properties
    string? serviceName;
    string? servicePrice;

    // Methods
    public AdditionalService(CustomerType custType)
        : base("", "", "", custType, CarRental.luxury, false)
    {
        (serviceName, servicePrice) = SetService(custType);
    }

    public (string, string) SetService(CustomerType custType)
    {
        switch (custType)
        {
            case CustomerType.Regular:
                serviceName = "GPS Navigation";
                servicePrice = "$9.99/day";
                break;
            case CustomerType.Premium:
                serviceName = "Child Car Seat";
                servicePrice = "$14.99/day";
                break;
            case CustomerType.VIP:
                serviceName = "Chauffeur Service";
                servicePrice = "$99.99/day";
                break;
            default:
                break;
        }
        return (serviceName ?? "", servicePrice ?? "");
    }
}

// Customer types
enum CustomerType
{
    Regular = 1,
    Premium = 2,
    VIP = 3
}

// Car rental types
enum CarRental
{
    economy = 1,
    standard = 2,
    luxury = 3
}
