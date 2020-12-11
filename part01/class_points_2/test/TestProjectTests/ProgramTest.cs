using System;
using Xunit;
using TestProject;
using TestMyCode.CSharp.API.Attributes;

namespace TestProjectTests
{
    [Fact]
    [Points("1")]
    public class ProgramTest
    {
        public void TestReturnsTrue()
        {
            Assert.True(Program.ReturnTrue);
        }

        public void ReturnsNotInput()
        {
            Assert.True(Program.ReturnNotInput(false));
            Assert.False(Program.ReturnNotInput(true));
        }

        public void ReturnsString()
        {
            string s = "asd";
            
            Assert.Equal(s, Program.ReturnInputString(s));
        }
    }
}
