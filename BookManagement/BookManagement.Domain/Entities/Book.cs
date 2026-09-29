namespace BookManagement.Domain.Entities;

/// <summary>
/// 图书
/// </summary>
public class Book
{
    /// <summary>
    /// 图书ID
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 书名
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// ISBN
    /// </summary>
    public string ISBN { get; set; } = string.Empty;

    /// <summary>
    /// 作者
    /// </summary>
    public string Author { get; set; } = string.Empty;

    /// <summary>
    /// 出版社
    /// </summary>
    public string? Publisher { get; set; }

    /// <summary>
    /// 分类ID
    /// </summary>
    public long CategoryId { get; set; }

    /// <summary>
    /// 所属分类
    /// </summary>
    public BookCategory Category { get; set; } = null!;
}