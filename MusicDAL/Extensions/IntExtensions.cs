using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDAL.Extensions
{
    public static class IntExtensions
    {
        public static string ToThousandsSeparator(this int value)
        {
            return value.ToString("N0");
        }

        public static string ToThousandsSeparator(this long value)
        {
            return value.ToString("N0");
        }
    }
}
