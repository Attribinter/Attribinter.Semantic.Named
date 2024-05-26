namespace Paraminter.Semantic.SemanticAttributeNamedArgumentDataParserCases;

using Moq;

using Paraminter.Parameters;

using System;

using Xunit;

public sealed class TryParse
{
    private readonly IParserFixture Fixture = ParserFixtureFactory.Create();

    [Fact]
    public void NullRecorder_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!, Mock.Of<ISemanticAttributeNamedInvocationData>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullInvocationData_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(Mock.Of<IArgumentDataRecorder<INamedParameter, ISemanticAttributeNamedArgumentData>>(), null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void DifferentNumberOfParametersAndArguments_ReturnsFalse()
    {
        var parameter = "Parameter";

        Mock<ISemanticAttributeNamedInvocationData> invocationDataMock = new();

        invocationDataMock.Setup(static (invocationData) => invocationData.Parameters).Returns([parameter]);
        invocationDataMock.Setup(static (invocationData) => invocationData.Arguments).Returns([]);

        Mock<IArgumentDataRecorder<INamedParameter, ISemanticAttributeNamedArgumentData>> recorderMock = new();

        var result = Target(recorderMock.Object, invocationDataMock.Object);

        Assert.False(result);

        recorderMock.VerifyNoOtherCalls();
    }

    [Fact]
    public void FalseReturningRecorder_ReturnsFalse()
    {
        var parameterName1 = "Foo1";
        var parameterName2 = "Foo2";
        var parameterName3 = "Foo3";

        var parameter1 = Mock.Of<INamedParameter>();
        var parameter2 = Mock.Of<INamedParameter>();

        var argumentValue1 = TypedConstantStore.GetNext();
        var argumentValue2 = TypedConstantStore.GetNext();
        var argumentValue3 = TypedConstantStore.GetNext();

        var argumentData1 = Mock.Of<ISemanticAttributeNamedArgumentData>();
        var argumentData2 = Mock.Of<ISemanticAttributeNamedArgumentData>();

        Fixture.ParameterFactoryMock.Setup((factory) => factory.Create(parameterName1)).Returns(parameter1);
        Fixture.ParameterFactoryMock.Setup((factory) => factory.Create(parameterName2)).Returns(parameter2);

        Fixture.ArgumentDataFactoryMock.Setup((factory) => factory.Create(argumentValue1)).Returns(argumentData1);
        Fixture.ArgumentDataFactoryMock.Setup((factory) => factory.Create(argumentValue2)).Returns(argumentData2);

        Mock<ISemanticAttributeNamedInvocationData> invocationDataMock = new();

        invocationDataMock.Setup(static (invocationData) => invocationData.Parameters).Returns([parameterName1, parameterName2, parameterName3]);
        invocationDataMock.Setup(static (invocationData) => invocationData.Arguments).Returns([argumentValue1, argumentValue2, argumentValue3]);

        Mock<IArgumentDataRecorder<INamedParameter, ISemanticAttributeNamedArgumentData>> recorderMock = new();

        recorderMock.Setup((recorder) => recorder.TryRecordData(parameter1, argumentData1)).Returns(true);
        recorderMock.Setup((recorder) => recorder.TryRecordData(parameter2, argumentData2)).Returns(false);

        var result = Target(recorderMock.Object, invocationDataMock.Object);

        Assert.False(result);

        recorderMock.Verify((recorder) => recorder.TryRecordData(parameter1, argumentData1), Times.Once());
        recorderMock.Verify((recorder) => recorder.TryRecordData(parameter2, argumentData2), Times.Once());

        recorderMock.VerifyNoOtherCalls();
    }

    [Fact]
    public void TrueReturningRecorder_RecordsAllArguments_ReturnsTrue()
    {
        var parameterName1 = "Foo1";
        var parameterName2 = "Foo2";

        var parameter1 = Mock.Of<INamedParameter>();
        var parameter2 = Mock.Of<INamedParameter>();

        var argumentValue1 = TypedConstantStore.GetNext();
        var argumentValue2 = TypedConstantStore.GetNext();

        var argumentData1 = Mock.Of<ISemanticAttributeNamedArgumentData>();
        var argumentData2 = Mock.Of<ISemanticAttributeNamedArgumentData>();

        Fixture.ParameterFactoryMock.Setup((factory) => factory.Create(parameterName1)).Returns(parameter1);
        Fixture.ParameterFactoryMock.Setup((factory) => factory.Create(parameterName2)).Returns(parameter2);

        Fixture.ArgumentDataFactoryMock.Setup((factory) => factory.Create(argumentValue1)).Returns(argumentData1);
        Fixture.ArgumentDataFactoryMock.Setup((factory) => factory.Create(argumentValue2)).Returns(argumentData2);

        Mock<ISemanticAttributeNamedInvocationData> invocationDataMock = new();

        invocationDataMock.Setup(static (invocationData) => invocationData.Parameters).Returns([parameterName1, parameterName2]);
        invocationDataMock.Setup(static (invocationData) => invocationData.Arguments).Returns([argumentValue1, argumentValue2]);

        Mock<IArgumentDataRecorder<INamedParameter, ISemanticAttributeNamedArgumentData>> recorderMock = new();

        recorderMock.Setup((recorder) => recorder.TryRecordData(parameter1, argumentData1)).Returns(true);
        recorderMock.Setup((recorder) => recorder.TryRecordData(parameter2, argumentData2)).Returns(true);

        var result = Target(recorderMock.Object, invocationDataMock.Object);

        Assert.True(result);

        recorderMock.Verify((recorder) => recorder.TryRecordData(parameter1, argumentData1), Times.Once());
        recorderMock.Verify((recorder) => recorder.TryRecordData(parameter2, argumentData2), Times.Once());

        recorderMock.VerifyNoOtherCalls();
    }

    private bool Target(IArgumentDataRecorder<INamedParameter, ISemanticAttributeNamedArgumentData> recorder, ISemanticAttributeNamedInvocationData invocationData) => Fixture.Sut.TryParse(recorder, invocationData);
}
