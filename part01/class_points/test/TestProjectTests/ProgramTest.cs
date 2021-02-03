using System;
using Xunit;
using TestProject;
using TestMyCode.CSharp.API.Attributes;

namespace TestProjectTests
{
    [Points("1")]
    public class ProgramTest
    {
        [Fact]
        [Points("1.1")]
        public void TestReturnsTrue()
        {
            Assert.True(Program.ReturnTrue);
        }

        [Fact]
        [Points("1.1")]
        public void TestForDualPoint()
        {
            Assert.True(Program.BooleanForDualTestPoint);
        }

        [Fact]
        [Points("1.2")]
        public void ReturnsString()
        {
            string s = "asd";

            Assert.Equal(s, Program.ReturnInputString(s));
        }

        [Fact]
        public void TestForClassPoint()
        {
            Assert.True(Program.BooleanForClassPoint);
        }

        public void NotAPointTest()
        {
            Assert.True(false);
        }
    }
}
