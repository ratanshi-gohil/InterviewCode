using InterviewCode.Dto;
using System;
using System.Collections.Generic;
using System.IO;
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

        //this function parses input file
        public static List<RecordDto> ParseInputFile(Enums.InputFileType inputType)
        {
            try
            {
                string inputFile = Utility.GetFullFilePathWithExtension(inputType);
                if (File.Exists(inputFile))
                {
                    
                    var dtoRecords =
                    from line in File.ReadLines(inputFile)
                    let record = ParseInputLine(line, inputType)
                    select record;

                    return dtoRecords.ToList();
                    
                }
                else { return null; }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while executing ParseInputFile");
                throw ex;
            }

        }

        private static RecordDto ParseInputLine(string inputLine, Enums.InputFileType inputType)
        {
            Char[] seperator = Utility.GetDelimiterChar(inputType);
            var recordDtoArr = inputLine.Split(seperator, StringSplitOptions.None);
            RecordDto recordDto = new RecordDto();
            recordDto.LastName = recordDtoArr[0];
            recordDto.FirstName = recordDtoArr[1];
            recordDto.Gender = recordDtoArr[2];
            recordDto.FavoriteColor = recordDtoArr[3];
            recordDto.DateOfBirth = Convert.ToDateTime(recordDtoArr[4]).ToString("M/d/yyyy");

            return recordDto;
        }
    }
}
