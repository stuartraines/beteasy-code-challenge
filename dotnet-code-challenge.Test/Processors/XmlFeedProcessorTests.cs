using System;
using dotnet_code_challenge.Processors;
using NUnit.Framework;

namespace dotnet_code_challenge.Test.Processors
{
    public class XmlFeedProcessorTests
    {
        private XmlFeedProcessor _subject;

        [SetUp]
        public void Setup()
        {
            _subject = new XmlFeedProcessor();
        }

        [TestCase("fdsfd.xml", true)]
        [TestCase("dfdsf.json", false)]
        public void CanProcessReturnsCorrectResponseForFileExtension(string filename, bool expected)
        {
            // Act
            var actual = _subject.CanProcess(filename);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        //TODO: Complete test
        [Test]
        [Ignore("Not enough time")]
        public void ShouldDeserializeCorrectly()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
