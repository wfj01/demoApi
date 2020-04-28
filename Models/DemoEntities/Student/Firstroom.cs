using System;
using System.Collections.Generic;
using System.Text;

namespace demo.Models.DemoEntities
{
    /// <summary>
    /// 第一餐厅-实体类
    /// </summary>
    public class Firstroom
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
    /// 购买窗口
    /// </summary>
    public string Windows { get; set; }

     /// <summary>
     /// 备注
     /// </summary>
    public string Remarks { get; set; }

    /// <summary>
    /// 数量
    /// </summary>
    public string Number { get; set; }
    }
}
