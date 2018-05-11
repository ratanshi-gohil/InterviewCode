using InterviewCode.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCode.Repository
{
    public interface IRecordRepository
    {
        List<RecordEntity> RecordEntities();
    }
}
