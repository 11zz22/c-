using BookManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManagement.Infrastructure.Data.Configurations;

/// <summary>
/// 图书分类实体配置
/// </summary>
public class BookCategoryConfiguration : IEntityTypeConfiguration<BookCategory>
{
    /// <summary>
    /// 配置图书分类实体
    /// </summary>
    public void Configure(EntityTypeBuilder<BookCategory> builder)
    {
        // 配置表名
        builder.ToTable("book_categories");

        // 配置主键
        builder.HasKey(x => x.Id);

        // 配置主键自增
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        // 配置分类名称
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        // 配置分类描述
        builder.Property(x => x.Description)
            .HasMaxLength(500);
    }
}