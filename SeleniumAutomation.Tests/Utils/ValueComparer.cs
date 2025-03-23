using System;
using System.Globalization;

namespace SeleniumAutomation.Tests.Utils
{
    public static class ValueComparer
    {
        public static int CompareValues(string value1, string value2)
        {
            if (decimal.TryParse(value1.TrimStart('$').Replace(",", ""), out decimal num1) &&
                decimal.TryParse(value2.TrimStart('$').Replace(",", ""), out decimal num2))
            {
                return num1.CompareTo(num2);
            }

            if (DateTime.TryParse(value1, out DateTime date1) &&
                DateTime.TryParse(value2, out DateTime date2))
            {
                return date1.CompareTo(date2);
            }

            return string.Compare(value1, value2, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsSorted(string[] values, bool ascending = true)
        {
            for (int i = 1; i < values.Length; i++)
            {
                int comparison = CompareValues(values[i - 1], values[i]);
                if (ascending && comparison > 0)
                    return false;
                if (!ascending && comparison < 0)
                    return false;
            }
            return true;
        }
    }
} 