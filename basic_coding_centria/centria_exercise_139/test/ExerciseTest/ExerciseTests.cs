using System;
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
        private string abbreviationsClass = "Abbreviations";
        private Type MainClassType;
        private Type AbbreviationsType;
        private MethodInfo MainMethod;
        private MethodBody MainMethodBody;

        public Tests()
        {
            this.MainClassType = Type.GetType($"{@namespace}.{mainClass},{@namespace}");
            this.AbbreviationsType = Type.GetType($"{@namespace}.{abbreviationsClass},{@namespace}");
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
        public void TestAbbreviationsIsCreated()
        {   
            Assert.NotNull(AbbreviationsType);
        }

        [Fact]
        [Points("1")]
        public void TestDictionaryIsUsed()
        {
            FieldInfo[] fields = AbbreviationsType != null ? AbbreviationsType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance) : new FieldInfo[0];
            bool hasDict = fields.Any(field => field.FieldType == typeof(Dictionary<string, string>));
            Assert.True(hasDict);
        }

        [Fact]
        [Points("1")]
        public void TestAbbreviationsClassHasAbbs()
        {
            Abbreviations abbs = new Abbreviations();
            abbs.AddAbbreviation("np", "no problem");
            Assert.True(abbs.HasAbbreviation("np"));
        }

        [Fact]
        [Points("1")]
        public void TestAbbreviationsClassFindExpNP()
        {
            Abbreviations abbs = new Abbreviations();
            abbs.AddAbbreviation("np", "no problem");
            Assert.Equal("no problem", abbs.FindExplanationFor("np"));
        }

        [Fact]
        [Points("1")]
        public void TestAbbreviationsClassFindExpETC()
        {
            Abbreviations abbs = new Abbreviations();
            abbs.AddAbbreviation("etc", "et cetera");
            Assert.Equal("et cetera", abbs.FindExplanationFor("etc"));
        }

        [Fact]
        [Points("1")]
        public void TestAbbreviationsClassFindExpJNE()
        {
            Abbreviations abbs = new Abbreviations();
            abbs.AddAbbreviation("jne", "ja niin edelleen");
            Assert.Equal("ja niin edelleen", abbs.FindExplanationFor("jne"));
        }

        [Fact]
        [Points("1")]
        public void TestAbbreviationsClassDoNotFindUnexisting()
        {
            Abbreviations abbs = new Abbreviations();
            Assert.Equal("not found", abbs.FindExplanationFor("jne"));
        }
    }
}