using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Zeje.Core
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageJson<T>
    {
        /// <summary>
        /// </summary>
        private PageJson()
        { }
        /// <summary>
        /// </summary>
        /// <param name="total"></param>
        /// <param name="rows"></param>
        public PageJson(int total, List<T> rows)
        {
            this.total = total;
            this.rows = rows;
        }
        /// <summary>
        /// </summary>
        public int? total { get; set; }
        /// <summary>
        /// </summary>
        public IEnumerable<T> rows { get; set; }
    }
}