using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Runtime.Serialization;

namespace Zeje.Core
{
    /// <summary>返回多个信息的集合
    /// </summary>
    public class ReturnObj
    {
        /// <summary>
        /// 
        /// </summary>
        public ReturnObj()
        {
            flag = false;
            lstMsg = lstMsg ?? new List<string>();
        }

        /// <summary>是否成功
        /// </summary>
        public bool flag { get; set; }
        /// <summary>消息
        /// </summary>
        public string msg
        {
            get
            {
                return this.ToAlertString();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected List<string> lstMsg { get; set; }
        /// <summary>添加信息
        /// </summary>
        /// <param name="str"></param>
        public void Add(string str)
        {
            lstMsg.Add(str);
        }
        /// <summary>添加异常信息
        /// </summary>
        /// <param name="ex"></param>
        public void Add(Exception ex)
        {
            lstMsg.Add(GetExceptionMessage(ex));
        }
        /// <summary>
        /// </summary>
        /// <param name="returnObj"></param>
        public void Add(ReturnObj returnObj)
        {
            flag = returnObj.flag;
            lstMsg.AddRange(returnObj.lstMsg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="returnObj"></param>
        public void Add<T>(ReturnObj<T> returnObj)
        {
            flag = returnObj.flag;
            lstMsg.AddRange(returnObj.lstMsg);
        }

        /// <summary>添加异常信息
        /// </summary>
        /// <param name="errorPrex">前缀</param>
        /// <param name="ex"></param>
        public void Add(string errorPrex, Exception ex)
        {
            lstMsg.Add(errorPrex + GetExceptionMessage(ex));
        }

        /// <summary>获得深层次的错误提示
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private string GetExceptionMessage(Exception ex)
        {
            string str = string.Empty;
            if (ex.InnerException != null)
            {
                if (ex.InnerException.InnerException != null)
                {
                    str = ex.InnerException.InnerException.Message;
                }
                else
                {
                    str = ex.InnerException.Message;
                }
            }
            else
            {
                str = ex.Message;
            }
            return str;
        }
        /// <summary>转换为以换行隔开的字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (lstMsg != null && lstMsg.Count > 0) ? string.Join(Environment.NewLine, lstMsg) : "";
        }
        /// <summary>转换<br/>以换行隔开的字符串
        /// </summary>
        /// <returns></returns>
        public string ToAlertString()
        {
            //return (lstMsg != null && lstMsg.Count > 0) ? string.Join("<br/>", lstMsg) : "";
            return (lstMsg != null && lstMsg.Count > 0) ? string.Join("\u000d", lstMsg) : "";
        }

        /// <summary>转换为客户端对象
        /// </summary>
        /// <returns></returns>
        public Return2ClientObj ToClient()
        {
            Return2ClientObj r2c = new Return2ClientObj();
            r2c.flag = flag;
            r2c.msg = r2c.msg;
            return r2c;
        }
    }

    /// <summary>返回多个信息的集合
    /// </summary>
    public class ReturnObj<T> : ReturnObj
    {
        /// <summary>
        /// </summary>
        public ReturnObj()
            : base()
        {
        }
        /// <summary>根据实际返回一个对象
        /// </summary>
        public T obj { get; set; }
        /// <summary>转换为可序列化的对象
        /// </summary>
        /// <returns></returns>
        public new Return2ClientObj<T> ToClient()
        {
            Return2ClientObj<T> r2c = new Return2ClientObj<T>();
            r2c.flag = flag;
            r2c.msg = r2c.msg;
            r2c.obj = obj;
            return r2c;
        }
    }
}
