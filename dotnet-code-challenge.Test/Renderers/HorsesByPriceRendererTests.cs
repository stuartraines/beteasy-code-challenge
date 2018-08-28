using System;
using dotnet_code_challenge.Models;
using dotnet_code_challenge.Renderers;
using dotnet_code_challenge.Responses;
using dotnet_code_challenge.Utils;
using FakeItEasy;
using NUnit.Framework;

namespace dotnet_code_challenge.Test.Renderers
{
    public class HorsesByPriceRendererTests
    {
        private Utils.IOutputWriter _writer;
        private HorsesByPriceRenderer _subject;

        [SetUp]
        public void Setup()
        {
            //_writer = A.Fake<dotnet_code_challenge.Services.IOutputWriter>();
            _subject = new HorsesByPriceRenderer(_writer);
        }

        [Test]
        public void ShouldWriteOutputCorrectly()
        {
            // Arrange
            var data = new GetHorsesWithPriceResponse
            {
                Horses = new[]
                {
                    new Horse
                    {
                        Name = "Test",
                        Price = 99m
                    }
                }
            };

            // Act
            _subject.Render(data);

            // Assert
            A.CallTo(() => _writer.WriteLine(A<string>.That.Matches(s => s.Contains("Test") && s.Contains("$99.00")))).MustHaveHappenedOnceExactly();
        }
    }
}
