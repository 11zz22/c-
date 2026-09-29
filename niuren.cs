var categories = new List<Category>
            {
                new Category { Id = 1, Name = "水果" },
                new Category { Id = 2, Name = "蔬菜" },
                new Category { Id = 3, Name = "饮料" },
            };

// 准备产品数据
var products = new List<Product>
            {
                new Product { Name = "苹果", Category = "水果", Price = 5.5m },
                new Product { Name = "香蕉", Category = "水果", Price = 3.2m },
                new Product { Name = "白菜", Category = "蔬菜", Price = 2.0m },
                new Product { Name = "可乐", Category = "饮料", Price = 4.0m },
                new Product { Name = "雪碧", Category = "饮料", Price = 4.0m },
                new Product { Name = "橙子", Category = "水果", Price = 6.0m },
            };
var query = from cat in categories
            join p in products on cat.Name equals p.Category
            select new
            {
              p.Name,
              p.Category,
              p.Price
            };
var newquery = from nq in query
               group nq by nq.Category into g
               orderby g.Key
               select new
               {
                 Category = g.Key,
                 Products = g.OrderBy(x => x.Price).ToList()
               }; ;
foreach (var item in newquery)
{
  Console.WriteLine($"种类:{item.Category}");
  foreach (var it in item.Products)
  {
    Console.WriteLine($"名称:{it.Name},价格:{it.Price}");
  }
}
public class Category
{
  public string Name { get; set; } = "";
  public override string ToString() => Name;
  public int Id { get; set; }
}

public class Product
{
  public string Name { get; set; } = "";
  public string Category { get; set; } = "";
  public decimal Price { get; set; }
}