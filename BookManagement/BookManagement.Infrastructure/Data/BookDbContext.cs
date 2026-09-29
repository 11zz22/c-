using BookManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Infrastructure.Data;

/// <summary>
/// 图书管理系统数据库上下文
/// </summary>
public class BookDbContext : DbContext
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public BookDbContext(DbContextOptions<BookDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// 图书分类
    /// </summary>
    public DbSet<BookCategory> BookCategories { get; set; }

    /// <summary>
    /// 图书
    /// </summary>
    public DbSet<Book> Books { get; set; }

    /// <summary>
    /// 图书实体副本
    /// </summary>
    public DbSet<BookCopy> BookCopies { get; set; }

    /// <summary>
    /// 读者
    /// </summary>
    public DbSet<Reader> Readers { get; set; }

    /// <summary>
    /// 借阅记录
    /// </summary>
    public DbSet<BorrowRecord> BorrowRecords { get; set; }

    /// <summary>
    /// 配置实体模型
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(BookDbContext).Assembly);
    }
}