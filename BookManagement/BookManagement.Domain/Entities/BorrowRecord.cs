namespace BookManagement.Domain.Entities;

/// <summary>
/// 图书借阅记录
/// </summary>
public class BorrowRecord
{
    /// <summary>
    /// 借阅记录ID
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 读者ID
    /// </summary>
    public long ReaderId { get; set; }

    /// <summary>
    /// 图书副本ID
    /// </summary>
    public long BookCopyId { get; set; }

    /// <summary>
    /// 借阅时间
    /// </summary>
    public DateTime BorrowTime { get; set; }

    /// <summary>
    /// 应还时间
    /// </summary>
    public DateTime DueTime { get; set; }

    /// <summary>
    /// 实际归还时间
    /// </summary>
    public DateTime? ReturnTime { get; set; }

    /// <summary>
    /// 读者
    /// </summary>
    public Reader Reader { get; set; } = null!;

    /// <summary>
    /// 图书副本
    /// </summary>
    public BookCopy BookCopy { get; set; } = null!;
}