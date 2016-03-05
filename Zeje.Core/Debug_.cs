using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeje.Core
{
    /// <summary>
    /// </summary>
    public class Debug_
    {
        /// <summary>打印到控制台
        /// </summary>
        /// <param name="query"></param>
        public static void Print(IQueryable query)
        {
#if DEBUG
            System.Diagnostics.Debug.Print(query.ToString());
#endif
        }

        /// <summary>打印到控制台
        /// </summary>
        /// <param name="msg"></param>
        public static void Print(string msg)
        {
#if DEBUG
            System.Diagnostics.Debug.Print(msg);
#endif
        }
    }
}
