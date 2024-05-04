namespace Paraminter.Semantic.SemanticAttributeNamedArgumentDataFactoryCases;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void ReturnsFactory()
    {
        var result = Target();

        Assert.NotNull(result);
    }

    private static SemanticAttributeNamedArgumentDataFactory Target() => new();
}
