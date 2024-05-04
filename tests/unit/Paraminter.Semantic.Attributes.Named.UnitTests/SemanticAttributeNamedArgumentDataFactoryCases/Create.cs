﻿namespace Paraminter.Semantic.SemanticAttributeNamedArgumentDataFactoryCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class Create
{
    [Fact]
    public void ReturnsArgumentData()
    {
        var value = TypedConstantStore.GetNext();

        var result = Target(value);

        Assert.NotNull(result);
    }

    private ISemanticAttributeNamedArgumentData Target(TypedConstant value) => Fixture.Sut.Create(value);

    private readonly IFactoryFixture Fixture = FactoryFixtureFactory.Create();
}
