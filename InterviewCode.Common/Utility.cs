using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCode.Common
{
    public static class Utility
    {
        public static Char[] GetDelimiterChar(Enums.InputFileType inputType)
        {
            Char[] delimiter = null;
            if (inputType.Equals(Enums.InputFileType.PipeDelimited))
            {
                delimiter = new Char[] { '|' };
            }
            else if (inputType.Equals(Enums.InputFileType.CommaDelimited))
            {
                delimiter = new Char[] { ',' };
            }
            else if (inputType.Equals(Enums.InputFileType.SpaceDelimited))
            {
                delimiter = new Char[] { ' ' };
            }
            return delimiter;
        }

        public static string GetSortOrderDescription(Enums.SortType sortType)
        {

            if (sortType.Equals(Enums.SortType.GenderAndLastNameAsc))
            {
                return "gender (females before males) then by last name ascending";
            }
            else if (sortType.Equals(Enums.SortType.BirthDateAsc))
            {
                return "birth date, ascending";
            }
            else if (sortType.Equals(Enums.SortType.LastNameDesc))
            {
                return "last name, descending";
            }
            return string.Empty;
        }

        public static string GetFullFilePathWithExtension(Enums.InputFileType inputType)
        {
            if (inputType.Equals(Enums.InputFileType.PipeDelimited))
                return Path.Combine(Directory.GetCurrentDirectory(), Constants.PIPE_DELIMITED_INPUT_FILE);
            else if (inputType.Equals(Enums.InputFileType.CommaDelimited))
                return Path.Combine(Directory.GetCurrentDirectory(), Constants.COMMA_DELIMITED_INPUT_FILE);
            else if (inputType.Equals(Enums.InputFileType.SpaceDelimited))
                return Path.Combine(Directory.GetCurrentDirectory(), Constants.SPACE_DELIMITED_INPUT_FILE);
            else
                return string.Empty;
        }
    }
}
