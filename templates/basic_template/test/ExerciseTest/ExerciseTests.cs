using System;
using Xunit;
using Exercise;
using System.Reflection;
using TestMyCode.CSharp.API.Attributes;

namespace ExerciseTest
{
    public class Tests
    {
        private string @namespace = "Exercise";
        private string mainClass = "Program";
        private Type MainClassType;
        private MethodInfo MainMethod;

        public Tests()
        {
            this.MainClassType = Type.GetType($"{@namespace}.{mainClass},{@namespace}");
            this.MainMethod = this.MainClassType.GetMethod("Main", new[] { typeof(string[]) });
        }

        [Fact]
        public void TestMainExists()
        {
            MethodBody MainMethodBody = this.MainMethod.GetMethodBody();
            Assert.NotNull(MainMethodBody);
        }

        [Fact]
        [Points("1")]
        public void DummyTest() {
            Assert.True(true);
        }
    }
}