using System.Text;
static class Tool
{
  public static string Serialize(Object o)
  {
    var props = o.GetType().GetProperties();
    var sb = new StringBuilder();
    foreach(var p in props)
    {
      sb.AppendLine($"{p.Name}:{p.GetValue(o)}");
    }
    return sb.ToString();
  }
}