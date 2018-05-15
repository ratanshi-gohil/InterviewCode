using InterviewCode.Common;
using InterviewCode.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCode.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<RecordDto> dtoRecords = new List<RecordDto>();

            //Parse pipe delimited input file
            var pipeDelimitedDtoRecords = BusinessLogic.ParseInputFile(Enums.InputFileType.PipeDelimited);
            if (pipeDelimitedDtoRecords != null)
            {
                dtoRecords.AddRange(pipeDelimitedDtoRecords);
            }

            //Parse comma delimited input file
            var commaDelimitedDtoRecords = BusinessLogic.ParseInputFile(Enums.InputFileType.CommaDelimited);
            if (commaDelimitedDtoRecords != null)
            {
                dtoRecords.AddRange(commaDelimitedDtoRecords);
            }

            //Parse space delimited input file
            var spaceDelimitedDtoRecords = BusinessLogic.ParseInputFile(Enums.InputFileType.SpaceDelimited);
            if (spaceDelimitedDtoRecords != null)
            {
                dtoRecords.AddRange(spaceDelimitedDtoRecords);
            }

            if (dtoRecords != null)
            {
                //Display three diffeerent views of records on user console
                DisplayRecords(dtoRecords, Enums.SortType.GenderAndLastNameAsc);
                DisplayRecords(dtoRecords, Enums.SortType.BirthDateAsc);
                DisplayRecords(dtoRecords, Enums.SortType.LastNameDesc);
            }
            else
            {
                Console.WriteLine("No records found");
            }
            Console.WriteLine("\nEnd of program. Press ENTER to end this program");
            Console.Read();

        }

        #region Private methods

        //This function displays parsed records on user console
        private static void DisplayRecords(List<RecordDto> recordsDto, Enums.SortType sortType)
        {

            List<RecordDto> sortedRecords = BusinessLogic.SortRecords(recordsDto, sortType);
            try
            {
                if (sortedRecords != null)
                {
                    string sortOrderString = Utility.GetSortOrderDescription(sortType);
                    Console.WriteLine(string.Format("\nDisplaying records sorted by {0}", sortOrderString));

                    foreach (var recordDto in sortedRecords)
                    {
                        Console.WriteLine(string.Format("{0} {1} {2} {3} {4}", recordDto.LastName, recordDto.FirstName, recordDto.Gender, recordDto.FavoriteColor, recordDto.DateOfBirth));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while executing Displayrecord");
                throw ex;
            }

        }




        #endregion
    }
}
