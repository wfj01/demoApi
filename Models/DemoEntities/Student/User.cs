using System;
using System.Collections.Generic;
using System.Text;

namespace demo.Models.DemoEntities
{
    public  class User
    {

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 头像地址
        /// </summary>
        public string Portrait { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public string Birtherdate { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public string Updatetime { get; set; }
    }
}
