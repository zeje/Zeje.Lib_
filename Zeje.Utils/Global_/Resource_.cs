using System;
using System.Resources;
using System.Web;


namespace Zeje.Utils
{
    /// <summary>资源文件辅助类
    /// </summary>
    public static class Resource_
    {

        private static ResourceManager m_resourceManager;
    
        static Resource_()
		{
            m_resourceManager = new ResourceManager("ResourceNamespace.myResources", typeof(Resource_).Assembly);

            //myString = myManager.GetString("StringResource");
            //myImage = (System.Drawing.Image)myManager.GetObject("ImageResource");
		}
        /// <summary>
        /// </summary>
        /// <param name="MessageCode"></param>
        /// <returns></returns>
        public static string GetMessage(string MessageCode)
		{
            string FieldName="";
            if (MessageCode == null || MessageCode.Trim().Equals("")){return "";}
            try{FieldName = HttpContext.GetGlobalResourceObject("Message", MessageCode).ToString();}
            catch{FieldName = MessageCode;}
            return FieldName;
		}
        /// <summary>
        /// </summary>
        /// <param name="MessageCode"></param>
        /// <param name="Parms"></param>
        /// <returns></returns>
        public static string GetMessage(string MessageCode,params object[] Parms)
        {
            string msg = GetMessage(MessageCode);
            if (Parms != null) msg = String.Format(msg, Parms);
            return msg;
        }
        /// <summary>
        /// </summary>
        /// <param name="Resource"></param>
        /// <param name="Field"></param>
        /// <returns></returns>
        public static string GetResource(string Resource,string Field)
        {
            //return m_resourceManager.GetString(name);
            //return HttpContext.GetGlobalResourceObject("ResMessage", FieldCode).ToString();
            string FieldName = "";
            try { FieldName = HttpContext.GetGlobalResourceObject(Resource, Field).ToString();}
            catch {FieldName=Field; }
            return FieldName;
        }

    }
}
