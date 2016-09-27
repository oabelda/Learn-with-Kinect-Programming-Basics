using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFG_AIK_OscarJoseAbeldaFernandez.Utilities
{
    public static class ClockConverter
    {
        public static string ticksToTenthsSecondsMinutesFormat(long ticks, int TicksPerSecond, string format)
        {
            if (ticks < 0) ticks = 0;
            long tenths = ticks % TicksPerSecond;
            long seconds = ticks / TicksPerSecond;
            long minutes = seconds / 60;
            seconds = seconds % 60;
            return string.Format(format, tenths, seconds, minutes);
        }

    }
}
