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
        /// 头像
        /// </summary>
        public string Portrait { get; set; }


        /// <summary>
        /// 昵称或账号
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Telephone { get;set; }

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
        public string Birtherdate { get; set; }

        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime? Updatetime { get; set; }
    }
}
