using System;
using System.Collections.Generic;
using InterviewCode.Data;
using InterviewCode.Dto;
using InterviewCode.RecordsApi.Controllers;
using InterviewCode.Repository;
using InterviewCode.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace InterviewCode.RecordsApi.Tests
{
    [TestClass]
    public class RecordsControllerTest
    {
        private Mock<IRecordService> _mockRecordService;
        private Mock<IRecordRepository> _mockRecordRepository;

        [TestInitialize]
        public void Init()
        {
            _mockRecordService = new Mock<IRecordService>();
            _mockRecordService.Setup(s => s.GetAllrecords()).Returns(GetAllrecords());
            _mockRecordService.Setup(s => s.SaveRecord(GenerateRecordtoSave())).Returns(true);

            _mockRecordRepository = new Mock<IRecordRepository>();
            _mockRecordRepository.Setup(s => s.UpdateRecord(GenerateRecordIdentityToSave())).Returns(false);
            _mockRecordRepository.Setup(s => s.InsertRecord(GenerateRecordIdentityToSave())).Returns(true);

        }

        [TestMethod]
        public void SortRecordsByGenderTest()
        {
            RecordsController recordsController = new RecordsController(_mockRecordService.Object);
            List<RecordDto> recordsDto = recordsController.Gender();
            
            Assert.AreEqual("Female", recordsDto[0].Gender);
        }

        

        [TestMethod]
        public void SortRecordsByBirthDayTest()
        {
            RecordsController recordsController = new RecordsController(_mockRecordService.Object);
            List<RecordDto> recordsDto = recordsController.Birthdate();

            Assert.AreEqual("Jobs", recordsDto[0].LastName);

        }

        [TestMethod]
        public void SortRecordsByNameTest()
        {
            RecordsController recordsController = new RecordsController(_mockRecordService.Object);
            List<RecordDto> recordsDto = recordsController.Name();

            Assert.AreEqual("Gates", recordsDto[0].LastName);
        }

        [TestMethod]
        public void SaveRecordTest()
        {
            RecordsController recordsController = new RecordsController(_mockRecordService.Object);
            
            string recordDtoStr = "Jones,Andrew,Male,Purple,09/15/1975";
            var success = recordsController.Post(recordDtoStr);

            Assert.IsTrue(success);


        }

        #region Private methods

        private RecordDto GenerateRecordtoSave()
        {
            return new RecordDto()
            {
                LastName = "Gates",
                FirstName = "Bill",
                Gender = "Male",
                FavoriteColor = "Blue",
                DateOfBirth = "10/28/1955"
            };
        }
        
        private RecordEntity GenerateRecordIdentityToSave()
        {
            return new RecordEntity()
            {
                LastName = "Gates",
                FirstName = "Bill",
                Gender = "Male",
                FavoriteColor = "Blue",
                DateOfBirth = new DateTime(1955, 2, 24)
            };
        }

        private List<RecordDto> GetAllrecords()
        {
            List<RecordDto> recordsDto = new List<RecordDto>();
            recordsDto.Add(new RecordDto()
            {
                LastName = "Gates",
                FirstName = "Bill",
                Gender = "Male",
                FavoriteColor = "Blue",
                DateOfBirth = "10/28/1955"
            });

            recordsDto.Add(new RecordDto()
            {
                LastName = "Nooyi",
                FirstName = "Indra",
                Gender = "Female",
                FavoriteColor = "Black",
                DateOfBirth = "10/28/1955"
            });

            recordsDto.Add(new RecordDto()
            {
                LastName = "Jobs",
                FirstName = "Steve",
                Gender = "Male",
                FavoriteColor = "White",
                DateOfBirth = "2/24/1955"
            });

            return recordsDto;
        }
        #endregion
    }
}
