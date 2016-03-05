
using System;
using System.Web;
using System.Web.Security;
namespace Zeje.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public static class FormsAuth
    {
        /// <summary>登录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="loginName"></param>
        /// <param name="userData"></param>
        /// <param name="expireMin">默认0</param>
        public static void SignIn<T>(string loginName, T userData, int expireMin = 0)
        {
            var data = Utils.Json_.GetString(userData);

            //创建一个FormsAuthenticationTicket，它包含登录名以及额外的用户数据。
            var ticket = new FormsAuthenticationTicket(2,
                loginName, DateTime.Now, DateTime.Now.AddDays(1), true, data);

            //加密Ticket，变成一个加密的字符串。
            var cookieValue = FormsAuthentication.Encrypt(ticket);

            //根据加密结果创建登录Cookie
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieValue)
                {
                    HttpOnly = true,
                    Secure = FormsAuthentication.RequireSSL,
                    Domain = FormsAuthentication.CookieDomain,
                    Path = FormsAuthentication.FormsCookiePath
                };
            if (expireMin > 0)
                cookie.Expires = DateTime.Now.AddMinutes(expireMin);

            var context = HttpContext.Current;
            if (context == null)
                throw new InvalidOperationException();

            //写登录Cookie
            context.Response.Cookies.Remove(cookie.Name);
            context.Response.Cookies.Add(cookie);
        }
        /// <summary>退出登录
        /// </summary>
        public static void SingOut()
        {
            FormsAuthentication.SignOut();
        }

        /// <summary>获取用户信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetUserData<T>() where T : class, new()
        {
            T UserData = null;
            try
            {
                var context = HttpContext.Current;
                var cookie = context.Request.Cookies[FormsAuthentication.FormsCookieName];
                var ticket = FormsAuthentication.Decrypt(cookie.Value);
                UserData = Utils.Json_.GetObject<T>(ticket.UserData);
            }
            catch
            { }

            return UserData;
        }
    }
}
