
using System;
using System.IO;
using System.Reflection;
using log4net;

namespace Zeje.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class LogHelper
    {
        #region 全局设置
        /// <summary>
        /// 
        /// </summary>
        public static void Init()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var xml = assembly.GetManifestResourceStream("Zeje.Core.Logs.Default.config");
            log4net.Config.XmlConfigurator.Configure(xml);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public static void Init(string path)
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo(path));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        public static void Init(Stream xml)
        {
            log4net.Config.XmlConfigurator.Configure(xml);
        }
        #endregion
        /// <summary>wait
        /// </summary>
        /// <param name="msg"></param>
        public static void Error(string msg)
        {
#if DEBUG
            System.Diagnostics.Debug.Print(msg);
#endif
        }
        /// <summary>wait
        /// </summary>
        /// <param name="ex"></param>
        public static void Error(Exception ex)
        {
#if DEBUG
            System.Diagnostics.Debug.Print(ex.Message);
#endif
        }
        /// <summary>wait
        /// </summary>
        /// <param name="functionName"></param>
        /// <param name="ex"></param>
        public static void Error(string functionName, Exception ex)
        {
#if DEBUG
            System.Diagnostics.Debug.Print(ex.Message);
#endif
        }
        /// <summary>wait
        /// </summary>
        /// <param name="msg"></param>
        public static void Info(string msg)
        {
#if DEBUG
            System.Diagnostics.Debug.Print(msg);
#endif
        }
        /// <summary>wait
        /// </summary>
        /// <param name="log"></param>
        /// <param name="function"></param>
        /// <param name="tryHandle"></param>
        /// <param name="errorHandleType"></param>
        /// <param name="catchHandle"></param>
        /// <param name="finallyHandle"></param>
        public static void Error(ILog log, string function, Action tryHandle, ErrorHandle errorHandleType = ErrorHandle.Throw, Action<Exception> catchHandle = null, Action finallyHandle = null)
        {
            try
            {
                log.Debug(function);
                tryHandle();
            }
            catch (Exception ex)
            {
                log.Error(function + "失败", ex);

                if (catchHandle != null)
                    catchHandle(ex);

                if (errorHandleType == ErrorHandle.Throw)
                    throw ex;
            }
            finally
            {
                if (finallyHandle != null)
                    finallyHandle();
            }
        }
    }
}
