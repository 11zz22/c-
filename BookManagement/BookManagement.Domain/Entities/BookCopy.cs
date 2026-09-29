namespace BookManagement.Domain.Entities;

/// <summary>
/// 图书实体副本
/// </summary>
public class BookCopy
{
    /// <summary>
    /// 图书副本ID
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 所属图书ID
    /// </summary>
    public long BookId { get; set; }

    /// <summary>
    /// 图书条码
    /// </summary>
    public string Barcode { get; set; } = string.Empty;

    /// <summary>
    /// 图书所在位置
    /// </summary>
    public string? ShelfLocation { get; set; }

    /// <summary>
    /// 所属图书
    /// </summary>
    public Book Book { get; set; } = null!;
}