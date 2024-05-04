namespace Paraminter.Semantic.SemanticAttributeNamedInvocationDataFactoryCases.SemanticAttributeNamedInvocationDataCases;

using Microsoft.CodeAnalysis;

using System.Collections.Generic;

using Xunit;

public sealed class Arguments
{
    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.ArgumentsMock.Object, result);
    }

    private IReadOnlyList<TypedConstant> Target() => Fixture.Sut.Arguments;

    private readonly IInvocationDataFixture Fixture = InvocationDataFixtureFactory.Create();
}
