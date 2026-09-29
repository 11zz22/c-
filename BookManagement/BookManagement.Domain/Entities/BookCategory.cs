namespace BookManagement.Domain.Entities;

/// <summary>
/// 图书分类
/// </summary>
public class BookCategory
{
    /// <summary>
    /// 分类ID
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 分类名称
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 分类描述
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// 当前分类下的图书
    /// </summary>
    public ICollection<Book> Books { get; set; } = new List<Book>();
}