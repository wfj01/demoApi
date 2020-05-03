using System;
using System.Collections.Generic;
using System.Text;

namespace demo.Models.DemoEntities.Student
{
    public class Order
    {
        /// <summary>
        /// id
        /// </summary>
        public int? Id { get; set; }
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
        /// 做法
        /// </summary>
        public string Practice { get; set; }
        /// <summary>
        /// 窗口
        /// </summary>
        public string Windows { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public string Prices { get; set; }

        /// <summary>
        /// 是否确认
        /// </summary>
        public bool IsConfirm { get; set; } = false;

        /// <summary>
        /// 是否完成
        /// </summary>
        public bool IsComplete { get; set; } = false;


        /// <summary>
        /// 更新时间
        /// </summary>
        public string UpdateTime { get; set; } = DateTime.Now.ToString();
    }
}
