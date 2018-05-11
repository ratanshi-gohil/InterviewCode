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
        public RecordRepository() { }

        public bool InsertRecord(RecordEntity recordEntity)
        {
            int ID = 1;
            string line = string.Format("{0}|{1}|{2}|{3}|{4}|{5}", ID, recordEntity.LastName, recordEntity.FirstName, recordEntity.Gender, recordEntity.FavoriteColor, recordEntity.DateOfBirth);
            return true;
        }

        public List<RecordEntity> RecordEntities()
        {
            int ID = 0;
            List<RecordEntity> recordEntities = new List<RecordEntity>();
            recordEntities.Add(new RecordEntity()
            {
                ID = ID++,
                LastName = "Gates",
                FirstName = "Bill",
                Gender = "Male",
                FavoriteColor = "Blue",
                DateOfBirth = new DateTime(1955, 10, 28)
            });
            recordEntities.Add(new RecordEntity()
            {
                ID = ID++,
                LastName = "Nooyi",
                FirstName = "Indra",
                Gender = "Female",
                FavoriteColor = "Black",
                DateOfBirth = new DateTime(1955, 10, 28)
            });
            recordEntities.Add(new RecordEntity()
            {
                ID = ID++,
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
