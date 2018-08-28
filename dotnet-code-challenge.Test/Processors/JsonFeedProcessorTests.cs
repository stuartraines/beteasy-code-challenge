using System;
using System.IO;
using System.Linq;
using dotnet_code_challenge.Processors;
using NUnit.Framework;

namespace dotnet_code_challenge.Test.Processors
{
    public class JsonFeedProcessorTests
    {
        private JsonFeedProcessor _subject;

        [SetUp]
        public void Setup()
        {
            _subject = new JsonFeedProcessor();
        }

        [TestCase("fdsfd.xml", false)]
        [TestCase("dfdsf.json", true)]
        public void CanProcessReturnsCorrectResponseForFileExtension(string filename, bool expected)
        {
            // Act
            var actual = _subject.CanProcess(filename);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));        
        }

        //TODO: Break out asserts into separate tests
        [Test]
        public void ShouldDeserializeCorrectly()
        {
            // Arrange
            var fileContents = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData/TestJson.json"));

            // Act
            var actual = _subject.Process(fileContents);

            // Assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.FeedId, Is.EqualTo("bphVf_Ik6LkkxYT5aN1MgQvcta0"));
            Assert.That(actual.Races.Count(), Is.EqualTo(1));
            Assert.That(actual.Races.First().Horses.Count(), Is.EqualTo(2));
            Assert.That(actual.Races.First().Horses.First().Name, Is.EqualTo("Toolatetodelegate"));
            Assert.That(actual.Races.First().Horses.First().Price, Is.EqualTo(10m));
        }
    }
}
