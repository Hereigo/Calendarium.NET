public class CalEventCategory
{
    public int Id { get; set; }
    public string Name { get; set; }

    public CalEventCategory()
    {
        Name = "default";
    }

    public CalEventCategory(string categoryName)
    {
        Name = categoryName;
    }
}