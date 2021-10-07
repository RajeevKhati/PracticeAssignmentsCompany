using AutoMapper;
using Company.Project.EventDomain.AppServices;
using Company.Project.EventDomain.AppServices.DTOs;
using Company.Project.EventDomain.Domain;
using Company.Project.EventDomain.Repository;
using Moq;
using System;
using Xunit;

namespace Company.Project.Tests
{
    public class EventAppServiceTest
    {
        /*
        private readonly EventAppService _serviceUnderTest;
        private readonly Mock<IEventRepository> _eventRepoMock = new Mock<IEventRepository>();
        private readonly Mock<IAccountRepository> _accountRepoMock = new Mock<IAccountRepository>();
        private readonly Mock<IEventAndPersonRepository> _eventAndPersonRepoMock = new Mock<IEventAndPersonRepository>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

        public EventAppServiceTest()
        {
            _serviceUnderTest = new EventAppService(_eventRepoMock.Object, _mapperMock.Object, _eventAndPersonRepoMock.Object, _accountRepoMock.Object);
        }

        [Fact]
        public void GetEventById_ReturnsEvent_IfEventIsPresentInDatabase()
        {
            //Arrange
            int eventId = 5;
            string titleOfBook = "meaning of life";
            string location = "mumbai";
            var eventItem = new Event
            {
                Id = eventId,
                TitleOfBook = titleOfBook,
                Location = location
            };
            var eventDTO = new EventDTO
            {
                Id = eventId,
                TitleOfBook = titleOfBook,
                Location = location
            };
            _eventRepoMock.Setup(x => x.GetById(eventId)).Returns(eventItem);
            _mapperMock.Setup(x => x.Map<Event, EventDTO>(eventItem)).Returns(eventDTO);

            //Act
            var operationResult = _serviceUnderTest.GetEventById(eventId);
            var eventById = operationResult.Data;

            //Assert
            Assert.Equal(eventId, eventById.Id);
        }

        [Fact]
        public void GetEventById_ReturnsNull_WhenFalseEventIdIsProvided()
        {

            //Arrange
            int randomId = 52426;
            _eventRepoMock.Setup(x => x.GetById(randomId)).Returns(() => null);
            _mapperMock.Setup(x => x.Map<Event, EventDTO>(null)).Returns(()=>null);

            //Act
            var operationResult = _serviceUnderTest.GetEventById(randomId);
            var eventById = operationResult.Data;

            //Assert
            Assert.Null(eventById);
        }

        [Fact]
        public void GetTotalPeopleInvited_ReturnsNumberOfPeopleInvitedInAnEvent_WhenGivenEventId()
        {
            //Arrange
            int eventId = 11;
            int numOfPeopleInvited = 5;
            _eventAndPersonRepoMock.Setup(x => x.GetCountOfInvitedPeople(eventId)).Returns(numOfPeopleInvited);

            //Act
            var operationResult = _serviceUnderTest.GetTotalPeopleInvited(eventId);
            var count = operationResult.Data;

            //Assert
            Assert.Equal(numOfPeopleInvited, count);
        }

        [Fact]
        public void IsUserValid_ReturnsTrue_IfUserIsPresentInDatabase()
        {
            //Arrange
            string userId = Guid.NewGuid().ToString();
            _accountRepoMock.Setup(x => x.IsUserPresentInDatabase(userId)).Returns(true);

            //Act
            var operationResult = _serviceUnderTest.IsUserValid(userId);
            var isUserValid = operationResult.Data;

            //Assert
            Assert.True(isUserValid);
        }

        [Fact]
        public void IsUserValid_ReturnsFalse_IfFalseUserIdIsProvided()
        {
            //Arrange
            string userId = Guid.NewGuid().ToString();
            _accountRepoMock.Setup(x => x.IsUserPresentInDatabase(userId)).Returns(false);

            //Act
            var operationResult = _serviceUnderTest.IsUserValid(userId);
            var isUserValid = operationResult.Data;

            //Assert
            Assert.False(isUserValid);
        }

        */
    }
}
