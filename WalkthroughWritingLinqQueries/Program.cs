string[] stringArray =
        {
            "apple", "avocado", "apricot",
            "banana", "blueberry",
            "cherry", "coconut", "cranberry",
            "date",
            "elderberry"
        };

// 查询：按首字母分组，再按首字母排序
var query = from str in stringArray
            group str by str[0] into stringGroup
            orderby stringGroup.Key
            select stringGroup;
foreach (var group in query)
{
    Console.WriteLine($"首字母 [{group.Key}]：");
    foreach (var word in group)      // ← 再遍历组内元素
    {
        Console.WriteLine($"    {word}");
    }
    Console.WriteLine();
}