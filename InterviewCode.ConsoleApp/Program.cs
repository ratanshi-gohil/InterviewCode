using InterviewCode.Common;
using InterviewCode.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCode.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFileType = ReadUserInputType();
            var dtoRecords = ParseInputFile(inputFileType);

            if (dtoRecords != null)
            {
                DisplayRecords(dtoRecords, Enums.ViewType.GenderAndLastNameAsc);
                DisplayRecords(dtoRecords, Enums.ViewType.BirthDateAsc);
                DisplayRecords(dtoRecords, Enums.ViewType.LastNameDesc);
            }
            else
            {
                Console.WriteLine("No records found");
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        private static void DisplayRecords(List<RecordDto> dtoRecords, Enums.ViewType viewType)
        {

        }

        private static Enums.InputFileType ReadUserInputType()
        {
            return Enums.InputFileType.UnKnown;

        }

        private static List<RecordDto> ParseInputFile(Enums.InputFileType inputType)
        {
            return new List<RecordDto>();

        }
    }
}
