using System.Diagnostics.CodeAnalysis;

List<Product> products = new List<Product>
{
    new Product { Id = 1, Name = "Product A", Price = 10.00M, CategoryId = 1 },
    new Product { Id = 2, Name = "Product B", Price = 20.00M, CategoryId = 1 },
    new Product { Id = 3, Name = "Product C", Price = 30.00M, CategoryId = 2 },
    new Product { Id = 4, Name = "Product D", Price = 40.00M, CategoryId = 2 },
};

List<Category> categories = new List<Category>
{
    new Category { Id = 1, Name = "Category A" },
    new Category { Id = 2, Name = "Category B" },
};

List<Sale> sales = new List<Sale>
{
    new Sale { ProductId = 1, Date = new DateTime(2022, 1, 1), Quantity = 2 },
    new Sale { ProductId = 2, Date = new DateTime(2022, 1, 1), Quantity = 1 },
    new Sale { ProductId = 2, Date = new DateTime(2022, 2, 1), Quantity = 3 },
    new Sale { ProductId = 3, Date = new DateTime(2022, 2, 15), Quantity = 1 },
    new Sale { ProductId = 3, Date = new DateTime(2022, 3, 1), Quantity = 2 },
    new Sale { ProductId = 4, Date = new DateTime(2022, 3, 1), Quantity = 3 },
};




var result = (
        from s in sales
        from p in products
        join c in categories on p.CategoryId equals c.Id
        where s.ProductId == p.Id
        select new { CategoryName = c.Name, Quantity = s.Quantity })
    .GroupBy(x => x.CategoryName)
    .Select(g => new { CategoryName = g.Key, TotalQuantity = g.Sum(x => x.Quantity) }).ToList();

foreach (var item in result)
{
    Console.WriteLine(item.CategoryName + " = " + item.TotalQuantity);
}

class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
}

class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Sale
{
    public int ProductId { get; set; }
    public DateTime Date { get; set; }
    public int Quantity { get; set; }
}