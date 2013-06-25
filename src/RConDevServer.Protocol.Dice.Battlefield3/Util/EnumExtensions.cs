namespace RConDevServer.Protocol.Dice.Battlefield3.Util
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    /// <summary>
    /// Extension methods for enum types
    /// </summary>
    public static class EnumExtensions
    {
        public static IList<KeyValuePair<TEnum, string>> ToDataSource<TEnum>()
            where TEnum : struct , IConvertible
        {
            var enumType = typeof (TEnum);
            Requires.EnumType(enumType);

            var names = Enum.GetNames(enumType);
            return names
                .Select(x =>
                    {
                        var currentValue = (TEnum) Enum.Parse(enumType, x);
                        var name = currentValue.ToString();
                        var memberInfo = enumType.GetMember(currentValue.ToString());

                        if (memberInfo.Length > 0)
                        {
                            var attributes = memberInfo[0].GetCustomAttributes(typeof (DisplayAttribute), false);
                            if (attributes.Length > 0)
                            {
                                name = ((DisplayAttribute) attributes[0]).Name;
                            }
                        }
                        return new KeyValuePair<TEnum, string>(currentValue, name);
                    })
                .ToList();
        }
    }
}
