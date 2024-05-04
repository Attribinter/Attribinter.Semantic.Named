namespace Paraminter.Semantic.SemanticAttributeNamedArgumentDataParserCases;

using Moq;

using Paraminter.Parameters;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullParameterFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!, Mock.Of<ISemanticAttributeNamedArgumentDataFactory>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullArgumentDataFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(Mock.Of<INamedParameterFactory>(), null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsParser()
    {
        var result = Target(Mock.Of<INamedParameterFactory>(), Mock.Of<ISemanticAttributeNamedArgumentDataFactory>());

        Assert.NotNull(result);
    }

    private static SemanticAttributeNamedArgumentDataParser Target(INamedParameterFactory parameterFactory, ISemanticAttributeNamedArgumentDataFactory argumentDataFactory) => new(parameterFactory, argumentDataFactory);
}
