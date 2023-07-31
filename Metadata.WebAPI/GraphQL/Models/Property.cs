namespace MetaData.WebAPI.GraphQL.Models;

public class Property
{
  [GraphQLIgnore]
  public string PropertyState { get; set; } = string.Empty;
  [GraphQLIgnore]
  public bool IncludeInCalculation { get; set; }
  [GraphQLIgnore]
  public bool AlwaysRequired { get; set; }
  [GraphQLIgnore]
  public bool IncludeInSearch { get; set; }
  public List<Feature> Features { get; set; } = new List<Feature>();
}
