namespace Paraminter.Semantic.SemanticAttributeNamedInvocationDataFactoryCases;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void ReturnsFactory()
    {
        var result = Target();

        Assert.NotNull(result);
    }

    private static SemanticAttributeNamedInvocationDataFactory Target() => new();
}
