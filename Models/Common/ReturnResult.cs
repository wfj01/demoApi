using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace demo.Models.Common
{
    /// <summary>
    /// 用于在各层（或方法之间）传递返回结果的通用对象
    /// </summary>
    public class ReturnResultNormal<T> where T : class//,new()
    {
        /// <summary>
        /// 返回码
        /// </summary>
        public int rtnCode { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        public string rtnMsg { get; set; }

        /// <summary>
        /// 返回的数据
        /// </summary>
        public DataSet data { get; set; }



        public ReturnResultNormal(DataSet data)
        {
            rtnCode = 0;
            rtnMsg = "ok";
            this.data = data;
        }

        public ReturnResultNormal(int rtnCode = 0, string rtnMsg = "ok", DataSet data = null)
        {
            this.rtnCode = rtnCode;
            this.rtnMsg = rtnMsg;
            this.data = data;
        }

    }
}
