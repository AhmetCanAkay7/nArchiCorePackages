namespace Core.Persistence.Dynamic;

// to sort the data
public class Sort
{
    public string Field { get; set; } //which field to sort. field = vites kolu, brand
    public string Dir { get; set; } //ascending or descending

    public Sort()
    {
        Field= string.Empty;
        Dir= string.Empty;
    }

    public Sort(string field, string dir)
    {
        Field= field;
        Dir= dir;
    }
}