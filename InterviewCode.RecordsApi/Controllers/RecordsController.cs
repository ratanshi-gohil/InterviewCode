using InterviewCode.Common;
using InterviewCode.Dto;
using InterviewCode.Repository;
using InterviewCode.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InterviewCode.RecordsApi.Controllers
{
    [RoutePrefix("Records")]
    public class RecordsController : ApiController
    {
        IRecordService _recordService;
        public RecordsController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        public RecordsController()
        {
        }


        // GET: records/gender
        [HttpGet]
        [Route("Gender")]
        public List<RecordDto> Gender()
        {
            return BusinessLogic.SortRecords(_recordService.GetAllrecords(), Enums.SortType.GenderAndLastNameAsc);
        }

        // GET: records/birthdate
        [HttpGet]
        [Route("Birthdate")]
        public List<RecordDto> Birthdate()
        {
            return BusinessLogic.SortRecords(_recordService.GetAllrecords(), Enums.SortType.BirthDateAsc);
        }
        // GET: Records/name
        [HttpGet]
        [Route("Name")]
        public List<RecordDto> Name()
        {
            return BusinessLogic.SortRecords(_recordService.GetAllrecords(), Enums.SortType.LastNameDesc);
        }

        // POST: Records
        public bool Post([FromBody]RecordDto recordDto)
        {
            return _recordService.SaveRecord(recordDto);
        }


    }
}
