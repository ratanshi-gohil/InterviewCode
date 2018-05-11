using InterviewCode.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCode.Common
{
    public static class BusinessLogic
    {
        //this function sorts parsed records
        public static List<RecordDto> SortRecords(List<RecordDto> recordsDto, Enums.SortType sortType)
        {
            try
            {
                List<RecordDto> sortedRecords = null;
                if (sortType.Equals(Enums.SortType.GenderAndLastNameAsc))
                {
                    sortedRecords = recordsDto.OrderBy(i => i.Gender).ThenBy(i => i.LastName).ToList();
                }
                else if (sortType.Equals(Enums.SortType.BirthDateAsc))
                {
                    sortedRecords = recordsDto.OrderBy(i => Convert.ToDateTime(i.DateOfBirth)).ToList();
                }
                else if (sortType.Equals(Enums.SortType.LastNameDesc))
                {
                    sortedRecords = recordsDto.OrderByDescending(i => i.LastName).ToList();
                }
                return sortedRecords;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while executing SortRecords");
                throw ex;
            }
        }
    }
}
