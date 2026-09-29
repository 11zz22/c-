using System;

// ① 事件参数
public class OrderPlacedEventArgs : EventArgs
{
    public int OrderId { get; }
    public decimal Amount { get; }

    public OrderPlacedEventArgs(int orderId, decimal amount)
    {
        OrderId = orderId;
        Amount = amount;
    }
}

// ② 发布者
public class OrderService
{
    public event EventHandler<OrderPlacedEventArgs>? OrderPlaced;

    public void PlaceOrder(int orderId, decimal amount)
    {
        Console.WriteLine($"[发布者] 下单 #{orderId}");
        OrderPlaced?.Invoke(this, new OrderPlacedEventArgs(orderId, amount));
    }
}

// ③ 订阅者类
public class EmailNotifier
{
    public void OnOrderPlaced(object sender, OrderPlacedEventArgs e)
    {
        Console.WriteLine($"  [邮件] 订单 #{e.OrderId} 金额 {e.Amount} 已通知");
    }
}

// ④ 使用
record  Program(string Name, int Age)
{

}
class Hdd
{
        static void Main()
    {
        var orderService = new OrderService();
        var emailNotifier = new EmailNotifier();

        // 订阅事件
        orderService.OrderPlaced += emailNotifier.OnOrderPlaced;

        // 下单
        orderService.PlaceOrder(1, 99.99m);
        orderService.PlaceOrder(2, 149.49m);
        Program program = new Program("John Doe", 30);
        var (name, age) = program;
        Console.WriteLine($"Program Name: {name}, Age: {age}");
int? a = 10;
int? b = 20;
int? c = null;

int? sum     = a + b;   // both non-null: result is 30
int? product = a * c;   // one operand is null: result is null

Console.WriteLine(sum);               // 30
Console.WriteLine(product.HasValue);
if(c is not null)
        {
            Console.WriteLine(c);
        }  // False — null propagates through arithmetic
    }
}