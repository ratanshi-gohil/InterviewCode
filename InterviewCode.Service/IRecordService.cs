using InterviewCode.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCode.Service
{
    public interface IRecordService
    {
        List<RecordDto> GetAllrecords();
    }
}
