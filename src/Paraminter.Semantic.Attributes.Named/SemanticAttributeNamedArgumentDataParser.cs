namespace Paraminter.Semantic;

using Microsoft.CodeAnalysis;

using Paraminter.Parameters;

using System;

/// <summary>Parses attribute named arguments.</summary>
public sealed class SemanticAttributeNamedArgumentDataParser : IArgumentDataParser<INamedParameter, ISemanticAttributeNamedArgumentData, ISemanticAttributeNamedInvocationData>
{
    private readonly INamedParameterFactory ParameterFactory;
    private readonly ISemanticAttributeNamedArgumentDataFactory ArgumentDataFactory;

    /// <summary>Instantiates a <see cref="SemanticAttributeNamedArgumentDataParser"/>, parsing attribute named arguments.</summary>
    /// <param name="parameterFactory">Handles creation of <see cref="INamedParameter"/>.</param>
    /// <param name="argumentDataFactory">Handles creation of <see cref="ISemanticAttributeNamedArgumentData"/>.</param>
    public SemanticAttributeNamedArgumentDataParser(INamedParameterFactory parameterFactory, ISemanticAttributeNamedArgumentDataFactory argumentDataFactory)
    {
        ParameterFactory = parameterFactory ?? throw new ArgumentNullException(nameof(parameterFactory));
        ArgumentDataFactory = argumentDataFactory ?? throw new ArgumentNullException(nameof(argumentDataFactory));
    }

    bool IArgumentDataParser<INamedParameter, ISemanticAttributeNamedArgumentData, ISemanticAttributeNamedInvocationData>.TryParse(IArgumentDataRecorder<INamedParameter, ISemanticAttributeNamedArgumentData> recorder, ISemanticAttributeNamedInvocationData invocationData)
    {
        if (recorder is null)
        {
            throw new ArgumentNullException(nameof(recorder));
        }

        if (invocationData is null)
        {
            throw new ArgumentNullException(nameof(invocationData));
        }

        if (invocationData.Parameters.Count != invocationData.Arguments.Count)
        {
            return false;
        }

        for (var i = 0; i < invocationData.Parameters.Count; i++)
        {
            if (TryRecordArgument(recorder, invocationData.Parameters[i], invocationData.Arguments[i]) is false)
            {
                return false;
            }
        }

        return true;
    }

    private bool TryRecordArgument(IArgumentDataRecorder<INamedParameter, ISemanticAttributeNamedArgumentData> recorder, string parameterName, TypedConstant argumentValue)
    {
        var parameter = ParameterFactory.Create(parameterName);
        var argumentData = ArgumentDataFactory.Create(argumentValue);

        return recorder.TryRecordData(parameter, argumentData);
    }
}
