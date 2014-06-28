using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eClock.Web.Utilities
{
    public class EnumUtility
    {
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}