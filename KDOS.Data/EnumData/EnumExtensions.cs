using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDOS.Data.EnumData
{
    public static class EnumExtensions
    {
        public static string GetEnumDescription<TEnum>(string value) where TEnum : Enum
        {
            if (Enum.TryParse(typeof(TEnum), value, out var enumValue))
            {
                return enumValue.ToString();
            }
            return "Unknown";
        }
    }
}
