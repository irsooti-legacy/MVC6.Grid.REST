using System;
using System.Collections.Generic;
using System.Text;

namespace MVC6.Grid.REST.Types
{
    public static class FilterTypes
    {
        public const string EQUALS = "-equals";
        public const string CONTAINS = "-contains";
        public const string START_SWITH = "-starts-with";
        public const string ENDS_WITH = "-ends-with";
        public const string NOT_EQUALS = "-not-equals";
        public const string GREATER_THAN = "-greater-than";
        public const string LESS_THAN_OR_EQUAL = "-less-than-or-equal";
        public const string GREATER_THAN_OR_EQUAL = "-greater-than-or-equal";
        public const string LESS_THAN = "-less-than";
        public const string EARLIER_THAN = "-earlier-than";
        public const string EARLIER_THAN_OR_EQUAL = "-earlier-than-or-equal";
        public const string LATER_THAN_OR_EQUAL = "-later-than-or-equal";
        public const string LATER_THAN = "-later-than";
    }
}
