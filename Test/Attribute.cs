[AttributeUsage(AttributeTargets.Property|AttributeTargets.Class,AllowMultiple =true)]
class PersonArgs(int age,string name) : Attribute
{
  public int Age{get;set;}=age;
  public string Name{get;set;}=name;
}