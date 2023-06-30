List<Customer> customers = new List<Customer> {
    new Customer {
        Name = "Alice",
        Email = "alice@example.com",
        Age = 25,
        PurchaseHistory = new List<Purchase> {
            new Purchase { Date = new DateTime(2022, 1, 1), Amount = 100.00M },
            new Purchase { Date = new DateTime(2022, 2, 1), Amount = 50.00M },
            new Purchase { Date = new DateTime(2022, 3, 1), Amount = 75.00M }
        }
    },
    new Customer {
        Name = "Bob",
        Email = "bob@example.com",
        Age = 35,
        PurchaseHistory = new List<Purchase> {
            new Purchase { Date = new DateTime(2022, 1, 1), Amount = 150.00M },
            new Purchase { Date = new DateTime(2022, 2, 1), Amount = 75.00M },
            new Purchase { Date = new DateTime(2022, 3, 1), Amount = 125.00M }
        }
    },
    new Customer {
        Name = "Charlie",
        Email = "charlie@example.com",
        Age = 30,
        PurchaseHistory = new List<Purchase> {
            new Purchase { Date = new DateTime(2022, 1, 1), Amount = 75.00M },
            new Purchase { Date = new DateTime(2022, 2, 1), Amount = 125.00M },
            new Purchase { Date = new DateTime(2022, 3, 1), Amount = 150.00M }
        }
    },
    new Customer {
        Name = "Charlie",
        Email = "charlie@example.com",
        Age = 30,
        PurchaseHistory = new List<Purchase> {
            new Purchase { Date = new DateTime(2022, 1, 1), Amount = 75.00M },
            new Purchase { Date = new DateTime(2022, 2, 1), Amount = 125.00M },
            new Purchase { Date = new DateTime(2022, 3, 1), Amount = 150.00M }
        }
    },
    new Customer {
        Name = "Charlie",
        Email = "charlie@example.com",
        Age = 30,
        PurchaseHistory = new List<Purchase> {
            new Purchase { Date = new DateTime(2022, 1, 1), Amount = 75.00M },
            new Purchase { Date = new DateTime(2022, 2, 1), Amount = 125.00M },
            new Purchase { Date = new DateTime(2022, 3, 1), Amount = 150.00M }
        }
    },
    new Customer {
        Name = "Charlie",
        Email = "charlie@example.com",
        Age = 30,
        PurchaseHistory = new List<Purchase> {
            new Purchase { Date = new DateTime(2022, 1, 1), Amount = 75.00M },
            new Purchase { Date = new DateTime(2022, 2, 1), Amount = 125.00M },
            new Purchase { Date = new DateTime(2022, 3, 1), Amount = 150.00M }
        }
    }
};

List<Customer> customers2 =
    customers.Where(c => c.PurchaseHistory
        .Any(p => p.Date.Year == (DateTime.Now.Year - 1)))
        .OrderByDescending(c => c.PurchaseHistory.Select(p => p.Amount).Sum())
        .Take(5)
        .ToList();

customers2.ForEach(c => Console.WriteLine(
    string
        .Join(", ",
            c.Name,
            c.Email,
            c.Age,
            (int)c.PurchaseHistory.Select(c => c.Amount).Sum())));

class Customer
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public List<Purchase> PurchaseHistory { get; set; }
}

class Purchase
{
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
}
