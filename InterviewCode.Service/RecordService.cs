using InterviewCode.Dto;
using InterviewCode.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCode.Service
{
    public class RecordService : IRecordService
    {
        IRecordRepository _recordRepository;
        public RecordService(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;

        }
        public List<RecordDto> GetAllrecords()
        {
            var dtoRecords = (from entities in _recordRepository.RecordEntities()
                              select new RecordDto
                              {
                                  LastName = entities.LastName,
                                  FirstName = entities.FirstName,
                                  Gender = entities.Gender,
                                  DateOfBirth = entities.DateOfBirth.ToString("M/dd/yyyy"),
                                  FavoriteColor = entities.FavoriteColor
                              }).ToList();

            return dtoRecords;
        }
    }
}
