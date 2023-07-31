using MetaData.WebAPI.GraphQL.Models;

namespace MetaData.WebAPI.GraphQL
{
  /// <summary>
  /// Query for GraphQL. This provide data. this can be integrated with data layer
  /// </summary>
  public sealed class RootQuery
  {
    readonly List<Property> _propertyValues = new()
        {
            new()
            {
                IncludeInCalculation = true,
                PropertyState = "CA",
                IncludeInSearch = false,
                AlwaysRequired = true,
                Features = new()
                {
                    new()
                    {
                        IdentificationKey = Guid.NewGuid(),
                        PointFeature = PointFeature.Always,
                        Relationship = Relationship.Known
                    },
                    new()
                    {
                        IdentificationKey = Guid.NewGuid(),
                        PointFeature = PointFeature.FeatureOnly,
                        Relationship = Relationship.UnKnown
                    },
                    new()
                    {
                        IdentificationKey = Guid.NewGuid(),
                        PointFeature = PointFeature.PointsOnly,
                        Relationship = Relationship.SecondDegree
                    }
                }
            },
            new()
            {
                IncludeInCalculation = true,
                PropertyState = "NY",
                IncludeInSearch = false,
                AlwaysRequired = true,
                Features = new()
                {
                    new()
                    {
                        IdentificationKey = Guid.NewGuid(),
                        PointFeature = PointFeature.Always,
                        Relationship = Relationship.Known
                    },
                    new()
                    {
                        IdentificationKey = Guid.NewGuid(),
                        PointFeature = PointFeature.FeatureOnly,
                        Relationship = Relationship.ThirdDegree
                    },
                    new()
                    {
                        IdentificationKey = Guid.NewGuid(),
                        PointFeature = PointFeature.PointsOnly,
                        Relationship = Relationship.SecondDegree
                    }
                    ,
                    new()
                    {
                        IdentificationKey = Guid.NewGuid(),
                        PointFeature = PointFeature.PointsOnly,
                        Relationship = Relationship.SecondDegree
                    }
                }
            }
        };
    public IEnumerable<Property> GetProperty(string propertyState)
    {
      return _propertyValues.Where(propertyValue =>
          propertyValue.PropertyState.Equals(propertyState, StringComparison.InvariantCultureIgnoreCase));
    }
  }
}
