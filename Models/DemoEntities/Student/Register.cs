using System;
using System.Collections.Generic;
using System.Text;

namespace demo.Models.DemoEntities
{
    /// <summary>
    /// 注册实体类
    /// </summary>
    public class Register
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 学生学号
        /// </summary>
        public string Studentid { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string Studentname { get; set; }
        
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Telephone { get;set; }

        /// <summary>
        /// 常用地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }
        
        /// <summary>
        /// 出生年月
        /// </summary>
        public DateTime? Birtherdate { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? Createtime { get; set; }

        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime? Updatetime { get; set; }
    }
}
