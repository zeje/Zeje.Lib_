using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Zeje.Utils
{
    /// <summary>时间辅助类
    /// </summary>
    public partial class DateTime_
    {
        /// <summary>取每月的第一/最末一天
        /// </summary>
        /// <param name="time">传入时间</param>
        /// <param name="firstDay">第一天还是最末一天</param>
        /// <returns></returns>
        public static DateTime DayOfMonth(DateTime time, bool firstDay = true)
        {
            DateTime time1 = new DateTime(time.Year, time.Month, 1);
            if (firstDay) return time1;
            else return time1.AddMonths(1).AddDays(-1);
        }
        /// <summary>取每季度的第一/最末一天
        /// </summary>
        /// <param name="time">传入时间</param>
        /// <param name="firstDay">第一天还是最末一天</param>
        /// <returns></returns>
        public static DateTime DayOfQuarter(DateTime time, bool firstDay = true)
        {
            int m = 0;
            switch (time.Month)
            {
                case 1:
                case 2:
                case 3:
                    m = 1; break;
                case 4:
                case 5:
                case 6:
                    m = 4; break;
                case 7:
                case 8:
                case 9:
                    m = 7; break;
                case 10:
                case 11:
                case 12:
                    m = 11; break;
            }

            DateTime time1 = new DateTime(time.Year, m, 1);
            if (firstDay) return time1;
            else return time1.AddMonths(3).AddDays(-1);
        }
        /// <summary>取每年的第一/最末一天
        /// </summary>
        /// <param name="time">传入时间</param>
        /// <param name="firstDay">第一天还是最末一天</param>
        /// <returns></returns>
        public static DateTime DayOfYear(DateTime time, bool firstDay = true)
        {
            if (firstDay) return new DateTime(time.Year, 1, 1);
            else return new DateTime(time.Year, 12, 31);
        }
        /// <summary>返回标准日期格式string(yyyy-MM-dd)
        /// </summary>
        public static string GetDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }
        /// <summary>返回标准时间格式string
        /// </summary>
        public static string GetTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }
        /// <summary>返回标准时间格式string
        /// </summary>
        public static string GetDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        /// <summary>月份补满
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string strMon(int i)
        {
            string sResult = "-";
            if (i < 10)
            {
                sResult += "0" + i.ToString();
            }
            else
            {
                sResult += i.ToString();
            }
            return sResult;
        }
    }
}
