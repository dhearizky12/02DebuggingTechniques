class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

class Payment
{
    public decimal Amount { get; set; }
    public string Method { get; set; }
}

class Invoice
{
    private List<Product> _products;
    private Payment _payment;

    public Invoice(List<Product> products, Payment payment)
    {
        _products = products;
        _payment = payment;
    }

    public void PrintInvoice()
    {
        decimal totalPrice = 0;
        Console.WriteLine("=== INVOICE ===");
        foreach (var product in _products)
        {
            Console.WriteLine($"nama produk : {product.Name} seharga : {product.Price}");
            totalPrice += product.Price;
        }
        Console.WriteLine($"Total Price: {totalPrice}");

        Console.WriteLine("Payment Details:");
        Console.WriteLine($"Amount: {_payment.Amount}");
        Console.WriteLine($"Method: {_payment.Method}");
    }
}

class Order
{
    private List<Product> _products;
    private Payment _payment;
    private Invoice _invoice;

    public Order()
    {
        _products = new List<Product>();
    }

    public void AddProduct(string name, decimal price)
    {
        _products.Add(new Product { Name = name, Price = price });
    }

    public void SetPayment(decimal amount, string method)
    {
        _payment = new Payment { Amount = amount, Method = method };
    }

    public void CreateInvoice()
    {
        _invoice = new Invoice(_products, _payment);
    }

    public void PrintInvoice()
    {
        if (_invoice == null)
        {
            throw new Exception("Invoice not yet created");
        }

        _invoice.PrintInvoice();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Order order = new Order();

        // Ask user for product names and prices
        while (true)
        {
            Console.WriteLine("Enter product name (or type 'done' to finish):");
            string name = Console.ReadLine();
            // if (name.ToLower() == "done") // sebelum make it  fail
            // {          // sebelum make it  fail
            //     break; // sebelum make it  fail
            // }          //sebelum make it fail
            // Console.WriteLine("Enter product name (or type 'done' to finish):"); //sebelum make it fail
            // string name; //sebelum make it fail
            
            while (true)
            {
                name = Console.ReadLine();

                // Check if the input is a valid string
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Invalid input. Please enter a valid product name.");
                    continue;
                }

                // Check if the input contains any digits
                if (name.Any(char.IsDigit))
                {
                    Console.WriteLine("Invalid input. Product name cannot contain digits.");
                    continue;
                }

                break;
            }

            if (name.ToLower() == "done")
            {
                break;
            }


            Console.WriteLine("Enter product price:");
            decimal price;
            while (!decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Invalid input. Please enter a valid decimal value:");
            }

            order.AddProduct(name, price);
        }

        // Ask user for payment amount and method
        Console.WriteLine("Enter payment amount:");
        decimal amount;
        while (!decimal.TryParse(Console.ReadLine(), out amount))
        {
            Console.WriteLine("Invalid input. Please enter a valid decimal value:");
        }

        Console.WriteLine("Enter payment method:");
        string method = Console.ReadLine();

        // Set payment information and create invoice
        order.SetPayment(amount, method);
        order.CreateInvoice();

        // Print the invoice
        order.PrintInvoice();
    }
}
