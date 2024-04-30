namespace Attribinter.Semantic.SemanticNamedArgumentParserCases;

using Attribinter.Parameters;

using Microsoft.CodeAnalysis;

using Moq;

using System;
using System.Collections.Generic;

using Xunit;

public sealed class TryParse
{
    [Fact]
    public void NullRecorder_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!, Mock.Of<AttributeData>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullAttributeData_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(Mock.Of<IArgumentRecorder<INamedParameter, TypedConstant>>(), null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void FalseReturningRecorder_ReturnsFalse()
    {
        var parameterName1 = "Foo1";
        var parameterName2 = "Foo2";
        var parameterName3 = "Foo3";

        var parameter1 = Mock.Of<INamedParameter>();
        var parameter2 = Mock.Of<INamedParameter>();
        var parameter3 = Mock.Of<INamedParameter>();

        var argument1 = new KeyValuePair<string, TypedConstant>(parameterName1, TypedConstantStore.GetNext());
        var argument2 = new KeyValuePair<string, TypedConstant>(parameterName2, TypedConstantStore.GetNext());
        var argument3 = new KeyValuePair<string, TypedConstant>(parameterName3, TypedConstantStore.GetNext());

        Fixture.ParameterFactoryMock.Setup((factory) => factory.Create(parameterName1)).Returns(parameter1);
        Fixture.ParameterFactoryMock.Setup((factory) => factory.Create(parameterName2)).Returns(parameter2);
        Fixture.ParameterFactoryMock.Setup((factory) => factory.Create(parameterName3)).Returns(parameter3);

        CustomAttributeData attributeData = new() { NamedArguments = [argument1, argument2, argument3] };

        Mock<IArgumentRecorder<INamedParameter, TypedConstant>> recorderMock = new();

        recorderMock.Setup((recorder) => recorder.TryRecordData(parameter1, argument1.Value)).Returns(true);
        recorderMock.Setup((recorder) => recorder.TryRecordData(parameter2, argument2.Value)).Returns(true);
        recorderMock.Setup((recorder) => recorder.TryRecordData(parameter3, argument3.Value)).Returns(true);

        recorderMock.Setup((recorder) => recorder.TryRecordData(parameter2, argument2.Value)).Returns(false);

        var result = Target(recorderMock.Object, attributeData);

        Assert.False(result);

        recorderMock.Verify((recorder) => recorder.TryRecordData(parameter1, argument1.Value), Times.Once());
        recorderMock.Verify((recorder) => recorder.TryRecordData(parameter2, argument2.Value), Times.Once());

        recorderMock.VerifyNoOtherCalls();
    }

    [Fact]
    public void TrueReturningRecorder_RecordsAllArguments_ReturnsTrue()
    {
        var parameterName1 = "Foo1";
        var parameterName2 = "Foo2";

        var parameter1 = Mock.Of<INamedParameter>();
        var parameter2 = Mock.Of<INamedParameter>();

        var argument1 = new KeyValuePair<string, TypedConstant>(parameterName1, TypedConstantStore.GetNext());
        var argument2 = new KeyValuePair<string, TypedConstant>(parameterName2, TypedConstantStore.GetNext());

        Fixture.ParameterFactoryMock.Setup((factory) => factory.Create(parameterName1)).Returns(parameter1);
        Fixture.ParameterFactoryMock.Setup((factory) => factory.Create(parameterName2)).Returns(parameter2);

        CustomAttributeData attributeData = new() { NamedArguments = [argument1, argument2] };

        Mock<IArgumentRecorder<INamedParameter, TypedConstant>> recorderMock = new();

        recorderMock.Setup((recorder) => recorder.TryRecordData(parameter1, argument1.Value)).Returns(true);
        recorderMock.Setup((recorder) => recorder.TryRecordData(parameter2, argument2.Value)).Returns(true);

        var result = Target(recorderMock.Object, attributeData);

        Assert.True(result);

        recorderMock.Verify((recorder) => recorder.TryRecordData(parameter1, argument1.Value), Times.Once());
        recorderMock.Verify((recorder) => recorder.TryRecordData(parameter2, argument2.Value), Times.Once());

        recorderMock.VerifyNoOtherCalls();
    }

    private bool Target(IArgumentRecorder<INamedParameter, TypedConstant> recorder, AttributeData attributeData) => Fixture.Sut.TryParse(recorder, attributeData);

    private readonly IParserFixture Fixture = ParserFixtureFactory.Create();
}
