namespace Classes;

public class BankAccount
{
    /// <summary>
    /// Gets the unique account number for this bank account.
    /// </summary>
    /// <value>A string representation of the account number, generated sequentially.</value>
    private static int s_accountNumberSeed = 1234567890;
    public string Number { get; }
    public string Owner { get; set; } 
    private readonly decimal _minimumBalance;
    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (var item in _allTransactions)
            {
                balance += item.Amount;
            }

            return balance;
        }
    }
public BankAccount(string name, decimal initialBalance) : this(name, initialBalance,0) { }

    public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
{
    Number = s_accountNumberSeed.ToString();
    s_accountNumberSeed++;

    Owner = name;
    _minimumBalance = minimumBalance;
    if (initialBalance > 0)
        MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
}
    private List<Transaction> _allTransactions = new List<Transaction>();
public void MakeDeposit(decimal amount, DateTime date, string note)
{
    if (amount <= 0)
    {
        throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
    }
    var deposit = new Transaction(amount, date, note);
    _allTransactions.Add(deposit);
}

public void MakeWithdrawal(decimal amount, DateTime date, string note)
{
    if (amount <= 0)
    {
        throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
    }
    // 把"余额不足怎么办"委托给虚方法
    Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance);

    var withdrawal = new Transaction(-amount, date, note);
    _allTransactions.Add(withdrawal);

    if (overdraftTransaction != null)
        _allTransactions.Add(overdraftTransaction);
}

protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
{
    if (isOverdrawn)
        throw new InvalidOperationException("Not sufficient funds for this withdrawal");
    return default;
}
public string GetAccountHistory() 
{
    var report = new System.Text.StringBuilder();

    decimal balance = 0;
    report.AppendLine("Date\t\tAmount\tBalance\tNote");
    foreach (var item in _allTransactions)
    {
        balance += item.Amount;
        report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
    }

    return report.ToString();
}
public virtual void PerformMonthEndTransactions() { }
}