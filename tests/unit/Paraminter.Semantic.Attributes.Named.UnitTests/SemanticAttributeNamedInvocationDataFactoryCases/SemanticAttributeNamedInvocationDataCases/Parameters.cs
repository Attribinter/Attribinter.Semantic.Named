namespace Paraminter.Semantic.SemanticAttributeNamedInvocationDataFactoryCases.SemanticAttributeNamedInvocationDataCases;

using System.Collections.Generic;

using Xunit;

public sealed class Parameters
{
    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.ParametersMock.Object, result);
    }

    private IReadOnlyList<string> Target() => Fixture.Sut.Parameters;

    private readonly IInvocationDataFixture Fixture = InvocationDataFixtureFactory.Create();
}
