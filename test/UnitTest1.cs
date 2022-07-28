using Xunit;

namespace test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var s_c = new SerialConnection();
        Assert.Null(s_c.ReadData());
    }
}