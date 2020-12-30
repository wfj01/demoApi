using System;
using System.Collections.Generic;
using System.Text;

namespace demo.Models.DemoEntities.Business
{
    public class Totalshopping
    {
        /// <summary>
        /// id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 菜名
        /// </summary>
        public string Dishname { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public string Price { get; set; }
        /// <summary>
        /// 得分
        /// </summary>
        public string Praction { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// 做法
        /// </summary>
        public string Practice { get; set; }

        /// <summary>
        /// 购买窗口
        /// </summary>
        public string Windows { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
    }
}
