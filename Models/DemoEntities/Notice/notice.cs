using System;
using System.Collections.Generic;
using System.Text;

namespace demo.Models.DemoEntities.Notice
{
    public class notice
    {
        /// <summary>
        /// pid
        /// </summary>
        public string Pid { get; set; }

        /// <summary>
        /// title 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// details 文章详情
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// source 来源
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// datatiem 时间
        /// </summary>
        public string Datatime { get; set; }
    }
}
