using System;
using System.Collections.Generic;
using System.Text;

namespace demo.Models.DemoEntities.Student
{
    public class Taday
    {
        /// <summary>
        /// id
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
        /// 评分
        /// </summary>
        public string Score { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string Time { get; set; }
        /// <summary>
        /// 窗口
        /// </summary>
        public string Windows { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Remarks { get; set; }

    }
}
