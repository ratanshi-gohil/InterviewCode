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
        List<RecordEntity> recordEntities;

        public RecordRepository()
        {
            PopulateRecordEntities();
        }

        private void PopulateRecordEntities()
        {
            recordEntities = new List<RecordEntity>();
            int ID = 0;
            recordEntities.Add(new RecordEntity()
            {
                ID = ++ID,
                LastName = "Gates",
                FirstName = "Bill",
                Gender = "Male",
                FavoriteColor = "Blue",
                DateOfBirth = new DateTime(1955, 10, 28)
            });
            recordEntities.Add(new RecordEntity()
            {
                ID = ++ID,
                LastName = "Nooyi",
                FirstName = "Indra",
                Gender = "Female",
                FavoriteColor = "Black",
                DateOfBirth = new DateTime(1955, 10, 28)
            });
            recordEntities.Add(new RecordEntity()
            {
                ID = ++ID,
                LastName = "Jobs",
                FirstName = "Steve",
                Gender = "Male",
                FavoriteColor = "White",
                DateOfBirth = new DateTime(1955, 2, 24)
            });
        }

        public bool InsertRecord(RecordEntity recordEntity)
        {
            RecordEntity existingRecordEntity = recordEntities.Find(p => p.ID.Equals(recordEntity.ID));
            if (existingRecordEntity != null)
            {
                UpdateRecord(recordEntity);
            }
            else
            {
                recordEntities.Add(new RecordEntity()
                {
                    ID = 1,
                    LastName = recordEntity.LastName,
                    FirstName = recordEntity.FirstName,
                    Gender = recordEntity.Gender,
                    FavoriteColor = recordEntity.FavoriteColor,
                    DateOfBirth = recordEntity.DateOfBirth
                });
            }
            return true;
        }

        public bool UpdateRecord(RecordEntity recordEntity)
        {
            if (recordEntities != null)
            {
                RecordEntity existingRecordEntity = recordEntities.Find(p => p.ID.Equals(recordEntity.ID));
                if (existingRecordEntity != null)
                {
                    existingRecordEntity.LastName = recordEntity.LastName;
                    existingRecordEntity.FirstName = recordEntity.FirstName;
                    existingRecordEntity.Gender = recordEntity.Gender;
                    existingRecordEntity.FavoriteColor = recordEntity.FavoriteColor;
                    existingRecordEntity.DateOfBirth = recordEntity.DateOfBirth;
                }
            }
            return true;
        }

        public List<RecordEntity> RecordEntities()
        {
            
            return recordEntities;
        }
    }
}
