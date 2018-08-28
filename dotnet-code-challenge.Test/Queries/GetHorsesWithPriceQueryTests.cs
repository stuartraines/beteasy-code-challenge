using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_code_challenge.Models;
using dotnet_code_challenge.Queries;
using dotnet_code_challenge.Repositories;
using dotnet_code_challenge.Requests;
using FakeItEasy;
using NUnit.Framework;

namespace dotnet_code_challenge.Test.Queries
{
    public class GetHorsesWithPriceQueryTests
    {
        private IFeedRepository _repository;
        private GetHorsesWithPriceQuery _subject;

        [SetUp]
        public void Setup()
        {
            _repository = A.Fake<IFeedRepository>();
            _subject = new GetHorsesWithPriceQuery(_repository);
        }

        [Test]
        public void ShouldReturnHorsesForRequestedFeed()
        {
            // Arrange
            var FeedId = Guid.NewGuid().ToString();
            var feed = new Feed { FeedId = FeedId, Races = new[] { new Race { RaceNumber = 1, Horses = new[] { new Horse() } } } };

            A.CallTo(() => _repository.Read()).Returns(new[] { feed });
            var request = new GetHorsesWithPriceRequest { FeedId = FeedId };

            // Act
            var actual = _subject.Query(request);

            // Assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Horses.Count(), Is.EqualTo(1));
        }
    }
}
