using InterviewCode.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCode.Repository
{
    public class RecordRepository : IRecordRepository
    {
        public List<RecordEntity> RecordEntities()
        {
            List<RecordEntity> recordEntities = new List<RecordEntity>();
            recordEntities.Add(new RecordEntity()
            {
                LastName = "Gates",
                FirstName = "Bill",
                Gender = "Male",
                FavoriteColor = "Blue",
                DateOfBirth = new DateTime(1955, 10, 28)
            });
            recordEntities.Add(new RecordEntity()
            {
                LastName = "Nooyi",
                FirstName = "Indra",
                Gender = "Female",
                FavoriteColor = "Black",
                DateOfBirth = new DateTime(1955, 10, 28)
            });
            recordEntities.Add(new RecordEntity()
            {
                LastName = "Jobs",
                FirstName = "Steve",
                Gender = "Male",
                FavoriteColor = "White",
                DateOfBirth = new DateTime(1955, 2, 24)
            });

            return recordEntities;
        }
    }
}
