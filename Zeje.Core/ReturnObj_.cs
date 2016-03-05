using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Zeje.Core
{
    /// <summary>返回多个信息的集合
    /// </summary>
    public class ReturnObj_<T> : ReturnObj
    {
        /// <summary>
        /// </summary>
        public ReturnObj_()
            : base()
        {
        }
        /// <summary>根据实际返回一个对象
        /// </summary>
        public T obj { get; set; }

    }
}
