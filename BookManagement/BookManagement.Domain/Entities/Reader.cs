namespace BookManagement.Domain.Entities;

/// <summary>
/// 读者
/// </summary>
public class Reader
{
    /// <summary>
    /// 读者ID
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 读者姓名
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 联系电话
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// 读者证号
    /// </summary>
    public string CardNumber { get; set; } = string.Empty;

    /// <summary>
    /// 借阅记录
    /// </summary>
    public ICollection<BorrowRecord> BorrowRecords { get; set; }
        = new List<BorrowRecord>();
}