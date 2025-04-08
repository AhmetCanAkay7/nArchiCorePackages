using System.Collections.Generic;

namespace Core.Persistence.Dynamic;

//represent a filter in a dynamic query
public class Filter
{
    public string Field { get; set; }
    public string? Value { get; set; } 
    public string Operator { get; set; }
    public string Logic { get; set; }
    public IEnumerable<Filter> Filters { get; set; } // iterable collection of filters

    public Filter()
    {
        Field = string.Empty;
        Operator = string.Empty;
    }

    public Filter(string field, string? value, string @operator, string logic, IEnumerable<Filter> filters)
    { 
        Field = field;
        Value = value;
        Operator = @operator;
        Logic = logic;
        Filters = filters;
    }

    public Filter(string field, string @operator)
    {
        Field = field;
        Operator = @operator;
    }
}