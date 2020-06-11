using System;
using System.IO;
using Xunit;
using Exercise;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using TestMyCode.CSharp.API.Attributes;

namespace ExerciseTest
{
    public class Tests
    {
        private string @namespace = "Exercise";
        private string mainClass = "Program";
        private Type MainClassType;
        private MethodInfo MainMethod;
        private MethodBody MainMethodBody;

        public Tests()
        {
            this.MainClassType = Type.GetType($"{@namespace}.{mainClass},{@namespace}");
            this.MainMethod = this.MainClassType.GetMethod("Main", new[] { typeof(string[]) });
            this.MainMethodBody = this.MainMethod.GetMethodBody();
        }

        [Fact]
        public void TestMainExists()
        {
            Assert.NotNull(this.MainMethodBody);
        }

        [Fact]
        [Points("1")]
        public void TestDictionaryIsUsed()
        {
            IList<LocalVariableInfo> locals = this.MainMethodBody.LocalVariables;

            //This could be made more strict by requiring specific key and value types
            Assert.True(locals.Any(local =>
                local.LocalType.IsGenericType &&
                local.LocalType.GetGenericTypeDefinition() == typeof(Dictionary<,>)));
        }

        [Fact]
        [Points("1")]
        public void TestPrintKeys()
        {
            using (StringWriter sw = new StringWriter())
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("f.e", "for example");
                dict.Add("etc.", "and so on");
                dict.Add("i.e", "more precisely");
                dict.Add("jne", "ja niin edelleen");

                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Program.PrintKeys(dict);
                Console.SetOut(stdout);

                Assert.Contains("f.e", sw.ToString().Replace("\r\n", "\n"));
                Assert.Contains("etc", sw.ToString().Replace("\r\n", "\n"));
                Assert.Contains("i.e", sw.ToString().Replace("\r\n", "\n"));
                Assert.Contains("jne", sw.ToString().Replace("\r\n", "\n"));
            }
        }

        [Fact]
        [Points("1")]
        public void TestPrintKeysWhereI()
        {
            using (StringWriter sw = new StringWriter())
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("f.e", "for example");
                dict.Add("etc.", "and so on");
                dict.Add("i.e", "more precisely");
                dict.Add("jne", "ja niin edelleen");

                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Program.PrintKeysWhere(dict, "i");
                Console.SetOut(stdout);

                Assert.Equal("i.e\n", sw.ToString().Replace("\r\n", "\n"));
            }
        }

        [Fact]
        [Points("1")]
        public void TestPrintKeysWhereJ()
        {
            using (StringWriter sw = new StringWriter())
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("f.e", "for example");
                dict.Add("etc.", "and so on");
                dict.Add("i.e", "more precisely");
                dict.Add("jne", "ja niin edelleen");

                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Program.PrintKeysWhere(dict, "j");
                Console.SetOut(stdout);

                Assert.Equal("jne\n", sw.ToString().Replace("\r\n", "\n"));
            }
        }

        [Fact]
        [Points("1")]
        public void TestPrintKeysWhereDotE()
        {
            using (StringWriter sw = new StringWriter())
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("f.e", "for example");
                dict.Add("etc.", "and so on");
                dict.Add("i.e", "more precisely");
                dict.Add("jne", "ja niin edelleen");

                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Program.PrintKeysWhere(dict, ".e");
                Console.SetOut(stdout);

                Assert.Contains("f.e", sw.ToString().Replace("\r\n", "\n"));
                Assert.Contains("i.e", sw.ToString().Replace("\r\n", "\n"));
            }
        }

        [Fact]
        [Points("1")]
        public void TestPrintValuesWhereDotE()
        {
            using (StringWriter sw = new StringWriter())
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("f.e", "for example");
                dict.Add("etc.", "and so on");
                dict.Add("i.e", "more precisely");
                dict.Add("jne", "ja niin edelleen");

                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Program.PrintValuesOfKeysWhere(dict, ".e");
                Console.SetOut(stdout);

                Assert.Contains("for example", sw.ToString().Replace("\r\n", "\n"));
                Assert.Contains("more precisely", sw.ToString().Replace("\r\n", "\n"));
                Assert.DoesNotContain("ja niin edelleen", sw.ToString().Replace("\r\n", "\n"));
            }
        }
    }
}