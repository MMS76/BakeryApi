using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace BakeryApi.Helpers
{
    public static class BakeryExtensions
    {
        public static string ToNormalPhoneNumber(this string phoneNumber)
        {
            var phone = phoneNumber;
            if (phone.StartsWith("+98"))
            {
                phone = "0" + phone.Remove(0, 3);
            }
            else if (phone.StartsWith("98"))
            {
                phone = "0" + phone.Remove(0, 2);
            }

            return phone.ToNormalNumber();

        }

        public static string ToNormalNumber(this string input)
        {
            return input
                .Replace("٠", "0")
                .Replace("١", "1")
                .Replace("٢", "2")
                .Replace("٣", "3")
                .Replace("٤", "4")
                .Replace("٥", "5")
                .Replace("٦", "6")
                .Replace("٧", "7")
                .Replace("٨", "8")
                .Replace("٩", "9")
                .Replace("۰", "0")
                .Replace("۱", "1")
                .Replace("۲", "2")
                .Replace("۳", "3")
                .Replace("۴", "4")
                .Replace("۵", "5")
                .Replace("۶", "6")
                .Replace("۷", "7")
                .Replace("۸", "8")
                .Replace("۹", "9");
        }

        public static string GetEnumName(this Enum enumValue)
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>().Name;
        }
    }
}