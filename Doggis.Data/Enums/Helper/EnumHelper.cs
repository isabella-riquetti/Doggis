using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enums.Helper
{
    public static class EnumHelper
    {
        public static string GetDescription(System.Enum @enum)
        {
            var type = @enum.GetType();
            var memInfo = type.GetMember(@enum.ToString());

            if (memInfo.Length <= 0)
                return @enum.ToString();

            var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attrs.Length > 0 ? ((DescriptionAttribute)attrs[0]).Description : @enum.ToString();
        }

        public static List<TEnum> GetEnumsFlags<TEnum>(this TEnum currentEnum, bool indexed = false) where TEnum : Enum
        {
            var result = System.Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Where(f => currentEnum.HasFlag(f))
            .OrderBy(f => f.ToString())
            .ToList();

            return result;
        }

        public static TEnum ListEnumToEnumFlag<TEnum>(this IEnumerable<TEnum> FromListOfEnums) where TEnum : Enum, IConvertible, IFormattable
        {
            var provider = new System.Globalization.NumberFormatInfo();
            var intlist = FromListOfEnums.Select(x => x.ToInt32(provider));
            var aggregatedint = intlist.Aggregate((prev, next) => prev | next);
            return (TEnum)Enum.ToObject(typeof(TEnum), aggregatedint);
        }

        public static Dictionary<int, string> EnumDictionary<TEnum>() where TEnum : struct
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>()
                .ToDictionary(e => Convert.ToInt32(e), e => EnumHelper.GetDescription(e as System.Enum));
        }
    }
}
