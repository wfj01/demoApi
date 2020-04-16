using System;
using System.Collections.Generic;
using System.Text;

namespace demo.Models.DemoEntities
{
    public  class User
    {
        /// <summary>
        /// Id
        /// </summary>
        public int ?Id { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string Studentname { get; set; }

        /// <summary>
        /// 学生学号
        /// </summary>
        public string Studentid { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}
