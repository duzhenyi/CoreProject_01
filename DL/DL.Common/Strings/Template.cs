using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace DL.Common.Strings
{
    public static class StringExtensions
    {
        /// <summary>
        /// 指示指定的字符串是 null 或者 System.String.Empty 字符串
        /// </summary>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// 指示指定的字符串是 null、空或者仅由空白字符组成。
        /// </summary>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}