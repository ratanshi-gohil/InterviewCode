﻿using InterviewCode.Common;
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
            //Parse input file
            var dtoRecords = ParseInputFile(Enums.InputFileType.PipeDelimited);
            dtoRecords.AddRange(ParseInputFile(Enums.InputFileType.CommaDelimited));
            dtoRecords.AddRange(ParseInputFile(Enums.InputFileType.SpaceDelimited));

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

        //this function seeks user input for type of file which needs processed
        private static Enums.InputFileType ReadUserInputType()
        {
            try
            {
                Console.WriteLine(string.Format("Choose input file type. Based on your selection, appropriate file will be parsed and records displayed\n\nPress 1 for Pipe-delimited\nPress 2 for Comma-delimited \nPress 3 for Space-delimited"));
                var consoleKeyInfo = Console.ReadKey();
                while (!ValidateUserSelection(consoleKeyInfo))
                {
                    Console.WriteLine(string.Format("\nIncorrect key. Please try again"));
                    consoleKeyInfo = Console.ReadKey();
                }

                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.D1:
                        return Enums.InputFileType.PipeDelimited;
                    case ConsoleKey.D2:
                        return Enums.InputFileType.CommaDelimited;
                    case ConsoleKey.D3:
                        return Enums.InputFileType.SpaceDelimited;
                    default:
                        return Enums.InputFileType.UnKnown;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while executing ReadUserInputType");
                throw ex;
            }

        }

        //this function parses input file
        private static List<RecordDto> ParseInputFile(Enums.InputFileType inputType)
        {
            try
            {
                string inputFile = Utility.GetFullFilePathWithExtension(inputType);
                if (File.Exists(inputFile))
                {
                    Char[] seperator = Utility.GetDelimiterChar(inputType);

                    var dtoRecord =
                    from line in File.ReadLines(inputFile)
                    let record = line.Split(seperator, StringSplitOptions.None)
                    select new RecordDto()
                    {
                        LastName = record[0],
                        FirstName = record[1],
                        Gender = record[2],
                        FavoriteColor = record[3],
                        DateOfBirth = Convert.ToDateTime(record[4]).ToString("M/d/yyyy")

                    };

                    return dtoRecord.ToList();
                }
                else { return null; }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while executing ParseInputFile");
                throw ex;
            }

        }

        //This function validated user key input
        private static bool ValidateUserSelection(ConsoleKeyInfo consoleKeyInfo)
        {
            if (consoleKeyInfo.Key.Equals(ConsoleKey.D1) || consoleKeyInfo.Key.Equals(ConsoleKey.D2) || consoleKeyInfo.Key.Equals(ConsoleKey.D3))
                return true;
            else
                return false;
        }

        #endregion
    }
}
