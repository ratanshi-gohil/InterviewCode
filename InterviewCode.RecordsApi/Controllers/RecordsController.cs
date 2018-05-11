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
            return _recordService.GetAllrecords().OrderBy(p => p.Gender).ToList();
        }

        // GET: records/birthdate
        [HttpGet]
        [Route("Birthdate")]
        public List<RecordDto> Birthdate()
        {
            return _recordService.GetAllrecords().OrderBy(p => Convert.ToDateTime(p.DateOfBirth)).ToList();
        }
        // GET: Records/name
        [HttpGet]
        [Route("Name")]
        public List<RecordDto> Name()
        {
            return _recordService.GetAllrecords().OrderBy(p => p.FirstName).ToList();
        }

        // POST: Records
        public bool Post([FromBody]RecordDto recordDto)
        {
            return _recordService.SaveRecord(recordDto);
        }


    }
}
