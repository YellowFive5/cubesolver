#region Usings

using Core;
using FluentAssertions;

#endregion

namespace Tests.Figure;

public class WhenRotatingFigure : FigureTestBase
{
    protected Core.Figure Figure_2 { get; set; }
    protected Core.Figure Figure_6 { get; set; }
    protected Core.Figure Figure_13 { get; set; }

    public override void Setup()
    {
        base.Setup();
        var figuresGenerator = new Core.FiguresGenerator();
        Figure_2 = figuresGenerator.GenerateFigureById(2);
        Figure_6 = figuresGenerator.GenerateFigureById(6);
        Figure_13 = figuresGenerator.GenerateFigureById(13);
    }

    [TestCase(Axis.X, Angle._90cvp)]
    [TestCase(Axis.X, Angle._180cvp)]
    [TestCase(Axis.X, Angle._270cvp)]
    [TestCase(Axis.X, Angle._90ccvn)]
    [TestCase(Axis.X, Angle._180ccvn)]
    [TestCase(Axis.X, Angle._270ccvn)]
    [TestCase(Axis.Y, Angle._90cvp)]
    [TestCase(Axis.Y, Angle._180cvp)]
    [TestCase(Axis.Y, Angle._270cvp)]
    [TestCase(Axis.Y, Angle._90ccvn)]
    [TestCase(Axis.Y, Angle._180ccvn)]
    [TestCase(Axis.Y, Angle._270ccvn)]
    [TestCase(Axis.Z, Angle._90cvp)]
    [TestCase(Axis.Z, Angle._180cvp)]
    [TestCase(Axis.Z, Angle._270cvp)]
    [TestCase(Axis.Z, Angle._90ccvn)]
    [TestCase(Axis.Z, Angle._180ccvn)]
    [TestCase(Axis.Z, Angle._270ccvn)]
    public void Figure2RotatesCorrectly(Axis rotationAxis, Angle rotationAngle)
    {
        Figure_2.ActualMap3x3.Should().BeEquivalentTo(new[,,]
                                                      {
                                                          { { 1, 1, 1 }, { 0, 0, 1 }, { 0, 0, 0 } },
                                                          { { 0, 0, 1 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                                          { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                                      });

        Figure_2.Rotate(rotationAxis, rotationAngle);

        switch (rotationAxis)
        {
            case Axis.X:
                switch (rotationAngle)
                {
                    case Angle._90cvp:
                        Figure_2.ActualMap3x3.Should().BeEquivalentTo(new[,,]
                                                                      {
                                                                          { { 0, 0, 0 }, { 0, 0, 1 }, { 1, 1, 1 } },
                                                                          { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 1 } },
                                                                          { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                                                      });
                        break;
                    case Angle._180cvp:
                        Assert.Fail(); // todo
                        break;
                    case Angle._270cvp:
                        Assert.Fail(); // todo
                        break;
                    case Angle._90ccvn:
                        Figure_2.ActualMap3x3.Should().BeEquivalentTo(new[,,]
                                                                      {
                                                                          { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                                                          { { 0, 0, 1 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                                                          { { 1, 1, 1 }, { 0, 0, 1 }, { 0, 0, 0 } },
                                                                      });
                        break;
                    case Angle._180ccvn:
                        Assert.Fail(); // todo
                        break;
                    case Angle._270ccvn:
                        Assert.Fail(); // todo
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(rotationAngle), rotationAngle, null);
                }

                break;
            case Axis.Y:
                switch (rotationAngle)
                {
                    case Angle._90cvp:
                        Figure_2.ActualMap3x3.Should().BeEquivalentTo(new[,,]
                                                                      {
                                                                          { { 0, 0, 1 }, { 0, 0, 1 }, { 0, 1, 1 } },
                                                                          { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 1 } },
                                                                          { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                                                      });
                        break;
                    case Angle._180cvp:
                        Assert.Fail(); // todo
                        break;
                    case Angle._270cvp:
                        Assert.Fail(); // todo
                        break;
                    case Angle._90ccvn:
                        Figure_2.ActualMap3x3.Should().BeEquivalentTo(new[,,]
                                                                      {
                                                                          { { 1, 1, 0 }, { 1, 0, 0 }, { 1, 0, 0 } },
                                                                          { { 1, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                                                          { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                                                      });
                        break;
                    case Angle._180ccvn:
                        Assert.Fail(); // todo
                        break;
                    case Angle._270ccvn:
                        Assert.Fail(); // todo
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(rotationAngle), rotationAngle, null);
                }

                break;
            case Axis.Z:
                switch (rotationAngle)
                {
                    case Angle._90cvp:
                        Figure_2.ActualMap3x3.Should().BeEquivalentTo(new[,,]
                                                                      {
                                                                          { { 1, 1, 0 }, { 1, 0, 0 }, { 0, 0, 0 } },
                                                                          { { 1, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                                                          { { 1, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                                                      });
                        break;
                    case Angle._180cvp:
                        Assert.Fail(); // todo
                        break;
                    case Angle._270cvp:
                        Assert.Fail(); // todo
                        break;
                    case Angle._90ccvn:
                        Assert.Fail(); // todo
                        break;
                    case Angle._180ccvn:
                        Assert.Fail(); // todo
                        break;
                    case Angle._270ccvn:
                        Assert.Fail(); // todo
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(rotationAngle), rotationAngle, null);
                }

                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(rotationAxis), rotationAxis, null);
        }
    }

    [TestCase(Axis.X, Angle._90cvp)]
    [TestCase(Axis.X, Angle._180cvp)]
    [TestCase(Axis.X, Angle._270cvp)]
    [TestCase(Axis.X, Angle._90ccvn)]
    [TestCase(Axis.X, Angle._180ccvn)]
    [TestCase(Axis.X, Angle._270ccvn)]
    [TestCase(Axis.Y, Angle._90cvp)]
    [TestCase(Axis.Y, Angle._180cvp)]
    [TestCase(Axis.Y, Angle._270cvp)]
    [TestCase(Axis.Y, Angle._90ccvn)]
    [TestCase(Axis.Y, Angle._180ccvn)]
    [TestCase(Axis.Y, Angle._270ccvn)]
    [TestCase(Axis.Z, Angle._90cvp)]
    [TestCase(Axis.Z, Angle._180cvp)]
    [TestCase(Axis.Z, Angle._270cvp)]
    [TestCase(Axis.Z, Angle._90ccvn)]
    [TestCase(Axis.Z, Angle._180ccvn)]
    [TestCase(Axis.Z, Angle._270ccvn)]
    public void Figure6RotatesCorrectly(Axis rotationAxis, Angle rotationAngle)
    {
        Figure_6.ActualMap3x3.Should().BeEquivalentTo(new[,,]
                                                      {
                                                          { { 1, 1, 0 }, { 1, 0, 0 }, { 0, 0, 0 } },
                                                          { { 0, 0, 0 }, { 1, 0, 0 }, { 0, 0, 0 } },
                                                          { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                                      });

        Figure_6.Rotate(rotationAxis, rotationAngle);

        switch (rotationAxis)
        {
            case Axis.X:
                switch (rotationAngle)
                {
                    case Angle._90cvp:
                        Assert.Fail(); // todo
                        break;
                    case Angle._180cvp:
                        Assert.Fail(); // todo
                        break;
                    case Angle._270cvp:
                        Assert.Fail(); // todo
                        break;
                    case Angle._90ccvn:
                        Assert.Fail(); // todo
                        break;
                    case Angle._180ccvn:
                        Assert.Fail(); // todo
                        break;
                    case Angle._270ccvn:
                        Assert.Fail(); // todo
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(rotationAngle), rotationAngle, null);
                }

                break;
            case Axis.Y:
                switch (rotationAngle)
                {
                    case Angle._90cvp:
                        Assert.Fail(); // todo
                        break;
                    case Angle._180cvp:
                        Assert.Fail(); // todo
                        break;
                    case Angle._270cvp:
                        Assert.Fail(); // todo
                        break;
                    case Angle._90ccvn:
                        Assert.Fail(); // todo
                        break;
                    case Angle._180ccvn:
                        Assert.Fail(); // todo
                        break;
                    case Angle._270ccvn:
                        Assert.Fail(); // todo
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(rotationAngle), rotationAngle, null);
                }

                break;
            case Axis.Z:
                switch (rotationAngle)
                {
                    case Angle._90cvp:
                        Assert.Fail(); // todo
                        break;
                    case Angle._180cvp:
                        Assert.Fail(); // todo
                        break;
                    case Angle._270cvp:
                        Assert.Fail(); // todo
                        break;
                    case Angle._90ccvn:
                        Assert.Fail(); // todo
                        break;
                    case Angle._180ccvn:
                        Assert.Fail(); // todo
                        break;
                    case Angle._270ccvn:
                        Assert.Fail(); // todo
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(rotationAngle), rotationAngle, null);
                }

                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(rotationAxis), rotationAxis, null);
        }
    }

    [TestCase(Axis.X, Angle._90cvp)]
    [TestCase(Axis.X, Angle._180cvp)]
    [TestCase(Axis.X, Angle._270cvp)]
    [TestCase(Axis.X, Angle._90ccvn)]
    [TestCase(Axis.X, Angle._180ccvn)]
    [TestCase(Axis.X, Angle._270ccvn)]
    [TestCase(Axis.Y, Angle._90cvp)]
    [TestCase(Axis.Y, Angle._180cvp)]
    [TestCase(Axis.Y, Angle._270cvp)]
    [TestCase(Axis.Y, Angle._90ccvn)]
    [TestCase(Axis.Y, Angle._180ccvn)]
    [TestCase(Axis.Y, Angle._270ccvn)]
    [TestCase(Axis.Z, Angle._90cvp)]
    [TestCase(Axis.Z, Angle._180cvp)]
    [TestCase(Axis.Z, Angle._270cvp)]
    [TestCase(Axis.Z, Angle._90ccvn)]
    [TestCase(Axis.Z, Angle._180ccvn)]
    [TestCase(Axis.Z, Angle._270ccvn)]
    public void Figure13RotatesCorrectly(Axis rotationAxis, Angle rotationAngle)
    {
        Figure_13.ActualMap3x3.Should().BeEquivalentTo(new[,,]
                                                       {
                                                           { { 0, 0, 1 }, { 1, 1, 1 }, { 0, 1, 0 } },
                                                           { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                                           { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                                       });

        Figure_13.Rotate(rotationAxis, rotationAngle);

        switch (rotationAxis)
        {
            case Axis.X:
                switch (rotationAngle)
                {
                    case Angle._90cvp:
                        Assert.Fail(); // todo
                        break;
                    case Angle._180cvp:
                        Assert.Fail(); // todo
                        break;
                    case Angle._270cvp:
                        Assert.Fail(); // todo
                        break;
                    case Angle._90ccvn:
                        Assert.Fail(); // todo
                        break;
                    case Angle._180ccvn:
                        Assert.Fail(); // todo
                        break;
                    case Angle._270ccvn:
                        Assert.Fail(); // todo
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(rotationAngle), rotationAngle, null);
                }

                break;
            case Axis.Y:
                switch (rotationAngle)
                {
                    case Angle._90cvp:
                        Assert.Fail(); // todo
                        break;
                    case Angle._180cvp:
                        Assert.Fail(); // todo
                        break;
                    case Angle._270cvp:
                        Assert.Fail(); // todo
                        break;
                    case Angle._90ccvn:
                        Assert.Fail(); // todo
                        break;
                    case Angle._180ccvn:
                        Assert.Fail(); // todo
                        break;
                    case Angle._270ccvn:
                        Assert.Fail(); // todo
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(rotationAngle), rotationAngle, null);
                }

                break;
            case Axis.Z:
                switch (rotationAngle)
                {
                    case Angle._90cvp:
                        Assert.Fail(); // todo
                        break;
                    case Angle._180cvp:
                        Assert.Fail(); // todo
                        break;
                    case Angle._270cvp:
                        Assert.Fail(); // todo
                        break;
                    case Angle._90ccvn:
                        Assert.Fail(); // todo
                        break;
                    case Angle._180ccvn:
                        Assert.Fail(); // todo
                        break;
                    case Angle._270ccvn:
                        Assert.Fail(); // todo
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(rotationAngle), rotationAngle, null);
                }

                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(rotationAxis), rotationAxis, null);
        }
    }
}