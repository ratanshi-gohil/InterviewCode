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
            _recordService = new RecordService(new RecordRepository());
        }


        // GET: records/gender
        [HttpGet]
        [Route("Gender")]
        public IEnumerable<RecordDto> Gender()
        {
            return _recordService.GetAllrecords().OrderBy(p => p.Gender);
        }

        // GET: records/birthdate
        [HttpGet]
        [Route("Birthdate")]
        public IEnumerable<RecordDto> Birthdate()
        {
            return _recordService.GetAllrecords().OrderBy(p => p.DateOfBirth);
        }
        // GET: Records/name
        [HttpGet]
        [Route("Name")]
        public IEnumerable<RecordDto> Name()
        {
            return _recordService.GetAllrecords().OrderBy(p => p.FirstName);
        }

        // POST: Records
        public void Post([FromBody]RecordDto recordDto)
        {
            _recordService.SaveRecord(recordDto);
        }


    }
}
