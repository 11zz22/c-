string[] groupingQuery = ["carrots", "cabbage", "broccoli", "beans", "barley"];
IEnumerable<IGrouping<char, string>> queryFoodGroups =
    from item in groupingQuery
    group item by item[0];
foreach (var item in queryFoodGroups)
{
  //按组进行排列
  Console.WriteLine($"首字母是{item.Key}");
  //打印每个组的每个成员具体内容
  foreach(var ia in item)
  {
    Console.WriteLine(ia);
  }
}