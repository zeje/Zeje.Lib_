using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Zeje.Core
{
    /// <summary>方法处理返回类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class Return2ClientObj
    {
        /// <summary>是否成功
        /// </summary>
        [DataMember]
        public bool flag { get; set; }
        /// <summary>消息
        /// </summary>
        [DataMember]
        public string msg { get; set; }
    }

    [Serializable]
    [DataContract]
    public partial class Return2ClientObj<T>
    {
        [DataMember]
        public bool flag { get; set; }

        [DataMember]
        public string msg { get; set; }

        [DataMember]
        public T obj { get; set; }
    }
}
