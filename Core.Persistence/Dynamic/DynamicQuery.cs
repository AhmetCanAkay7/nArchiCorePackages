using System.Collections.Generic;

namespace Core.Persistence.Dynamic;

public class DynamicQuery // dynamic structure has filters and sorts
{
    public Filter? Filter { get; set; } // filter object
    public IEnumerable<Sort>? Sort { get; set; } // iterable collection of sorts
    
    public DynamicQuery()
    {
        Filter= null;
        Sort= null;
    }

    public DynamicQuery(IEnumerable<Sort>? sorts, Filter? filter)
    {
        Filter= filter;
        Sort= sorts;
    }
}