using System;
using Xunit;
using Exercise;
using System.Reflection;
using TestMyCode.CSharp.API.Attributes;

namespace ExerciseTest
{
    public class Tests
    {
        string @namespace = "Exercise";
        string mainclass = "Program";
        private Type MainClassType;
        private MethodInfo MainMethod;

        public Tests()
        {
            MainClassType = Type.GetType($"{@namespace}.{mainclass},{@namespace}");
            this.MainMethod = this.MainClassType.GetMethod("Main", new[] { typeof(string[]) });
        }

        [Fact]
        public void TestMainExists()
        {
            Assert.NotNull(MainMethod);
            MethodBody MainMethodBody = this.MainMethod.GetMethodBody();
            Assert.NotNull(MainMethodBody);
        }

        [Fact]
        [Points("1")]
        public void TestMethodExists()
        {
            string methodName = "MethodToCreate";
            MethodInfo info = this.MainClassType.GetMethod(methodName);
            Assert.NotNull(info);
        }
    }
}