namespace MetaData.WebAPI.GraphQL.Models;

public class Feature
{
    public Guid IdentificationKey { get; set; }=Guid.Empty;

    public PointFeature PointFeature { get; set; } = PointFeature.None;

    public Relationship Relationship { get; set; } = Relationship.UnKnown;

}
