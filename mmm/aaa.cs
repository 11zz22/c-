using System.Runtime.CompilerServices;
HashSet<string> set = [with(StringComparer.OrdinalIgnoreCase), "Hello", "HELLO", "hello"];
foreach (var item in set)
{
    Console.WriteLine(item);
}
