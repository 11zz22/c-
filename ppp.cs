public class MyException : Exception
{
  public MyException(string message):base(message)
  {
    
  }
}
public class MyException1 : Exception
{
    public decimal Balance { get; }
    public decimal Required { get; }
    public decimal Shortfall => Required - Balance;
  public MyException1(string message,decimal balance, decimal required) : base(message)
  {
        Balance = balance;
        Required = required;
  }
}
public class BankAccount
{
    public decimal Balance { get;private set;}
    public string Owner { get; }

    // 事件声明
    public event EventHandler<BalanceChangedEventArgs>? BalanceChanged;

    public BankAccount(string owner, decimal initialBalance = 0)
    {
        Owner = owner;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new MyException("存款金额必须大于 0");

        decimal old = Balance;
        Balance += amount;

        OnBalanceChanged(old, Balance, "存款");
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new MyException("取款金额必须大于 0");

        if (amount > Balance)
            throw new MyException1("余额不足", Balance, amount);

        decimal old = Balance;
        Balance -= amount;

        OnBalanceChanged(old, Balance, "取款");
    }

    // 统一触发事件
    private void OnBalanceChanged(decimal oldBalance, decimal newBalance, string reason)
    {
        BalanceChanged?.Invoke(
            this,
            new BalanceChangedEventArgs(oldBalance, newBalance, reason));
    }
}
class Program
{
    static void Main()
    {
        var account = new BankAccount("Alice", 1000);

        // 订阅者 1：短信通知
        account.BalanceChanged += (sender,e)=>{
        if(!(sender is null))
        Console.WriteLine($"📱 短信：尊敬的 {((BankAccount)sender).Owner}，您{e.Reason} {Math.Abs(e.Delta)} 元，余额 {e.NewBalance} 元");
        };

        // 订阅者 2：记账（用 lambda）
        account.BalanceChanged += (sender, e) =>
        {
            Console.WriteLine($"[记账] {e.Reason}：{e.OldBalance} → {e.NewBalance}（变动 {e.Delta:+0;-0;0}）");
        };

        // 订阅者 3：风控（余额过低警告）
        account.BalanceChanged += (sender, e) =>
        {
            if (e.NewBalance < 500)
                Console.WriteLine($"⚠️ 风控：余额仅剩 {e.NewBalance}，请注意");
        };
        
        TryRun(() => account.Deposit(-500));
        TryRun(() => account.Withdraw(1200));
        TryRun(() => account.Withdraw(900));
    }

// 定义一个用于抛出异常的方法
    static void TryRun(Action action)
        {
        try
        {
            action();
        }
        catch (MyException1 ex)
        {
            Console.WriteLine($"⚠️ {ex.Message}，当前 {ex.Balance}，还差 {ex.Shortfall}");
            Console.WriteLine();
        }
        catch (MyException ex)
        {
            Console.WriteLine($"⚠️ {ex.Message}");
            Console.WriteLine();
        }
    }
    

}
public class BalanceChangedEventArgs : EventArgs
{
    public decimal OldBalance { get; }
    public decimal NewBalance { get; }
    public string Reason { get; }

    public decimal Delta => NewBalance - OldBalance;
    public bool IsIncrease => NewBalance > OldBalance;

    public BalanceChangedEventArgs(decimal oldBalance, decimal newBalance, string reason)
    {
        OldBalance = oldBalance;
        NewBalance = newBalance;
        Reason = reason;
    }
}