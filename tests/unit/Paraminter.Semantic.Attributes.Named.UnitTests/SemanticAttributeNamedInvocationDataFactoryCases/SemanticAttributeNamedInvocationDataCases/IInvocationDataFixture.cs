namespace Paraminter.Semantic.SemanticAttributeNamedInvocationDataFactoryCases.SemanticAttributeNamedInvocationDataCases;

using Microsoft.CodeAnalysis;

using Moq;

using System.Collections.Generic;

internal interface IInvocationDataFixture
{
    public abstract ISemanticAttributeNamedInvocationData Sut { get; }

    public abstract Mock<IReadOnlyList<string>> ParametersMock { get; }
    public abstract Mock<IReadOnlyList<TypedConstant>> ArgumentsMock { get; }
}
