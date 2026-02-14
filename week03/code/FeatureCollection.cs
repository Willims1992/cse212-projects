public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary

    public string Type { get; set; }
    public List<Feature> Features { get; set; }

}


/// <summary>
/// Represents each item in "features".
/// Only properties needed for the assignment are included.
/// </summary>
public class Feature
{
    public string Type { get; set; }
    public Properties Properties { get; set; }
    // geometry/id are present in the feed but not needed for this assignment
}
///summary
/// Properties we need to format the output://
/// - "mag": magnitude (nullable in the feed)
/// - "place": human-readable location
/// </summary>
public class Properties
{
    public double? Mag { get; set; }
    public string Place { get; set; }
}