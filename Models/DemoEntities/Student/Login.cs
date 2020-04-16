using System;
using System.Collections.Generic;
using System.Text;

namespace demo.Models.DemoEntities
{
    /// <summary>
    ///  登录实体类
    /// </summary>
    public class Login
    {

        /// <summary>
        /// id
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 学生id
        /// </summary>
        public string Studentid { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}
