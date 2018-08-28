using System;
using dotnet_code_challenge.Commands;
using dotnet_code_challenge.Models;
using dotnet_code_challenge.Repositories;
using FakeItEasy;
using NUnit.Framework;

namespace dotnet_code_challenge.Test.Commands
{
    public class PersistFeedCommandTests
    {
        private IFeedRepository _repository;
        private PersistFeedCommand _subject;

        [SetUp]
        public void Setup()
        {
            _repository = A.Fake<IFeedRepository>();
            _subject = new PersistFeedCommand(_repository);
        }

        [Test]
        public void GivenRecordDoesNotExistThenShouldPersist()
        {
            // Arrange
            var feed = new Feed();

            // Act
            _subject.Execute(new Requests.PersistFeedRequest { Feed = feed });

            // Assert
            A.CallTo(() => _repository.Persist(feed)).MustHaveHappenedOnceExactly();
        }
    }
}
