using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.FormatDate
{
    public class FormatDate
    {
        public string FormatDateBasedOnInterval(DateTime date, TimeSpan interval)
        {
            if (interval.TotalDays >= 365)
            {
                return date.ToString("yyyy");
            }
            else if (interval.TotalDays >= 30)
            {
                return date.ToString("yyyy/MM");
            }
            else if (interval.TotalDays >= 1)
            {
                return date.ToString("MM/dd");
            }
            else if (interval.TotalHours >= 1)
            {
                return date.ToString("dd HH:mm");
            }
            else if (interval.TotalMinutes >= 1)
            {
                return date.ToString("HH:mm");
            }
            else
            {
                return date.ToString("HH:mm:ss");
            }
        }

    }
}
