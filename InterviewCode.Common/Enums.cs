using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCode.Common
{
    public static class Enums
    {
        public enum InputFileType
        {
            UnKnown = 0,
            PipeDelimited = 1,
            CommaDelimited = 2,
            SpaceDelimited = 3,
        }

        public enum SortType
        {
            [Description("gender (females before males) then by last name ascending")]
            GenderAndLastNameAsc = 0,
            [Description("birth date, ascending")]
            BirthDateAsc = 1,
            [Description("last name, descending")]
            LastNameDesc = 2
        }
    }
}
