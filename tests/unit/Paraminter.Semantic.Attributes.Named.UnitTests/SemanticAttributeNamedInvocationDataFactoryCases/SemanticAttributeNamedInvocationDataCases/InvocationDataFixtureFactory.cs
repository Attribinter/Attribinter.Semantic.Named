namespace Paraminter.Semantic.SemanticAttributeNamedInvocationDataFactoryCases.SemanticAttributeNamedInvocationDataCases;

using Microsoft.CodeAnalysis;

using Moq;

using System.Collections.Generic;

internal static class InvocationDataFixtureFactory
{
    public static IInvocationDataFixture Create()
    {
        Mock<IReadOnlyList<string>> parametersMock = new();
        Mock<IReadOnlyList<TypedConstant>> argumentsMock = new();

        ISemanticAttributeNamedInvocationDataFactory factory = new SemanticAttributeNamedInvocationDataFactory();

        var sut = factory.Create(parametersMock.Object, argumentsMock.Object);

        return new InvocationDataFixture(sut, parametersMock, argumentsMock);
    }

    private sealed class InvocationDataFixture : IInvocationDataFixture
    {
        private readonly ISemanticAttributeNamedInvocationData Sut;

        private readonly Mock<IReadOnlyList<string>> ParametersMock;
        private readonly Mock<IReadOnlyList<TypedConstant>> ArgumentsMock;

        public InvocationDataFixture(ISemanticAttributeNamedInvocationData sut, Mock<IReadOnlyList<string>> parametersMock, Mock<IReadOnlyList<TypedConstant>> argumentsMock)
        {
            Sut = sut;

            ParametersMock = parametersMock;
            ArgumentsMock = argumentsMock;
        }

        ISemanticAttributeNamedInvocationData IInvocationDataFixture.Sut => Sut;

        Mock<IReadOnlyList<string>> IInvocationDataFixture.ParametersMock => ParametersMock;
        Mock<IReadOnlyList<TypedConstant>> IInvocationDataFixture.ArgumentsMock => ArgumentsMock;
    }
}
