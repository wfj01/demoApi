using System;
using System.Collections.Generic;
using System.Text;

namespace demo.Models.DemoEntities
{
    /// <summary>
    /// 大学城订餐
    /// </summary>
    public class Collegetown
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 菜名
        /// </summary>
        public string Dishname { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// 加工时间
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
        /// 备份
        /// </summary>
        public string Remarks { get; set; }
    }
}
