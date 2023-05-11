using System;

namespace Bacen.Dollar.Api.Client.Extensions
{
    internal static class DateTimeFormater
    {
        internal static string FormatToBacenDollarApi(this DateTime date)
        {
            var day = date.Day;
            var month = date.Month;
            var year = date.Year;

            return "'" + month + "-" + 
                day + "-" +
                year + "'";
        }
    }
}
