using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Zeje.Core
{
    /// <summary>请求实用类
    /// </summary>
    public static class Request_
    {
        /// <summary>获得当前页面客户端的IP
        /// </summary>
        /// <returns>当前页面客户端的IP</returns>
        public static string IP_(this HttpContext httpContext)
        {
            String clientIP = "";
            if (HttpContext.Current != null)
            {
                //LogHelper.Log(httpRequestBase);
                clientIP = httpContext.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(clientIP) || (clientIP.ToLower() == "unknown"))
                {
                    clientIP = httpContext.Request.ServerVariables["HTTP_X_REAL_IP"];
                    if (string.IsNullOrEmpty(clientIP))
                    {
                        clientIP = httpContext.Request.ServerVariables["REMOTE_ADDR"];
                        if (string.IsNullOrEmpty(clientIP) || clientIP.IsIP_())
                            clientIP = "127.0.0.1";
                    }
                }
                else
                {
                    clientIP = clientIP.Split(',')[0];
                }
            }
            return clientIP;
        }

        #region 参数
        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpRequestBase"></param>
        /// <param name="strKey"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        private static T Get<T>(this HttpRequestBase httpRequestBase, string strKey, Func<object, T> func)
        {
            if (string.IsNullOrWhiteSpace(strKey))
            {
                return default(T);
            }
            else
            {
                object obj = httpRequestBase.QueryString[strKey] ?? httpRequestBase.Form[strKey];
                if (obj == null)
                {
                    return default(T);
                }
                else
                {
                    try
                    {
                        return func(obj);
                    }
                    catch
                    {
                        return default(T);
                    }
                }
            }
        }
        #region 不可空
        /// <summary>
        /// </summary>
        /// <param name="httpRequestBase"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static bool GetBool(this HttpRequestBase httpRequestBase, string strKey)
        {
            return httpRequestBase.Get<bool>(strKey, (object obj) =>
            {
                return Convert.ToBoolean(obj);
            });
        }
        /// <summary>
        /// </summary>
        /// <param name="httpRequestBase"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static Byte GetByte(this HttpRequestBase httpRequestBase, string strKey)
        {
            return httpRequestBase.Get<Byte>(strKey, (object obj) =>
            {
                return Convert.ToByte(obj);
            });
        }
        /// <summary>
        /// </summary>
        /// <param name="httpRequestBase"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static int GetInt(this HttpRequestBase httpRequestBase, string strKey)
        {
            return httpRequestBase.Get<int>(strKey, (object obj) =>
            {
                return Convert.ToInt32(obj);
            });
        }
        /// <summary>
        /// </summary>
        /// <param name="httpRequestBase"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static long GetLong(this HttpRequestBase httpRequestBase, string strKey)
        {
            return httpRequestBase.Get<long>(strKey, (object obj) =>
            {
                return Convert.ToInt64(obj);
            });
        }
        /// <summary>
        /// </summary>
        /// <param name="httpRequestBase"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static Decimal GetDecimal(this HttpRequestBase httpRequestBase, string strKey)
        {
            return httpRequestBase.Get<Decimal>(strKey, (object obj) =>
            {
                return Convert.ToDecimal(obj);
            });
        }
        /// <summary>
        /// </summary>
        /// <param name="httpRequestBase"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static float GetFloat(this HttpRequestBase httpRequestBase, string strKey)
        {
            return httpRequestBase.Get<float>(strKey, (object obj) =>
            {
                return Convert.ToSingle(obj);
            });
        }
        /// <summary>
        /// </summary>
        /// <param name="httpRequestBase"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static Double GetDouble(this HttpRequestBase httpRequestBase, string strKey)
        {
            return httpRequestBase.Get<Double>(strKey, (object obj) =>
            {
                return Convert.ToDouble(obj);
            });
        }
        /// <summary>
        /// </summary>
        /// <param name="httpRequestBase"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(this HttpRequestBase httpRequestBase, string strKey)
        {
            return httpRequestBase.Get<DateTime>(strKey, (object obj) =>
            {
                return Convert.ToDateTime(obj);
            });
        }
        #endregion
        #region 可空
        /// <summary>
        /// </summary>
        /// <param name="httpRequestBase"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static Nullable<bool> GetBool_(this HttpRequestBase httpRequestBase, string strKey)
        {
            return httpRequestBase.Get<Nullable<bool>>(strKey, (object obj) =>
            {
                return Convert.ToBoolean(obj);
            });
        }
        /// <summary>
        /// </summary>
        /// <param name="httpRequestBase"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static Nullable<Byte> GetByte_(this HttpRequestBase httpRequestBase, string strKey)
        {
            return httpRequestBase.Get<Nullable<Byte>>(strKey, (object obj) =>
            {
                return Convert.ToByte(obj);
            });
        }
        /// <summary>
        /// </summary>
        /// <param name="httpRequestBase"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static Nullable<int> GetInt_(this HttpRequestBase httpRequestBase, string strKey)
        {
            return httpRequestBase.Get<Nullable<int>>(strKey, (object obj) =>
            {
                return Convert.ToInt32(obj);
            });
        }
        /// <summary>
        /// </summary>
        /// <param name="httpRequestBase"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static Nullable<long> GetLong_(this HttpRequestBase httpRequestBase, string strKey)
        {
            return httpRequestBase.Get<Nullable<long>>(strKey, (object obj) =>
            {
                return Convert.ToInt64(obj);
            });
        }
        /// <summary>
        /// </summary>
        /// <param name="httpRequestBase"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static Nullable<Decimal> GetDecimal_(this HttpRequestBase httpRequestBase, string strKey)
        {
            return httpRequestBase.Get<Nullable<Decimal>>(strKey, (object obj) =>
            {
                return Convert.ToDecimal(obj);
            });
        }
        /// <summary>
        /// </summary>
        /// <param name="httpRequestBase"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static Nullable<float> GetFloat_(this HttpRequestBase httpRequestBase, string strKey)
        {
            return httpRequestBase.Get<Nullable<float>>(strKey, (object obj) =>
            {
                return Convert.ToSingle(obj);
            });
        }
        /// <summary>
        /// </summary>
        /// <param name="httpRequestBase"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static Nullable<Double> GetDouble_(this HttpRequestBase httpRequestBase, string strKey)
        {
            return httpRequestBase.Get<Nullable<Double>>(strKey, (object obj) =>
            {
                return Convert.ToDouble(obj);
            });
        }
        /// <summary>
        /// </summary>
        /// <param name="httpRequestBase"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static Nullable<DateTime> GetDateTime_(this HttpRequestBase httpRequestBase, string strKey)
        {
            return httpRequestBase.Get<Nullable<DateTime>>(strKey, (object obj) =>
            {
                return Convert.ToDateTime(obj);
            });
        }
        #endregion
        #endregion

    }
}
