namespace API.Models;

public class SearchByNameFilter
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Page { get; set; }
    public int ElementsInPageCount { get; set; }
}