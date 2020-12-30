using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using demo.Models.Joke;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.Api.Controllers.TodayOnhistory
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodayOnhistoryController : ControllerBase
    {
        private IHttpClientFactory _httpClient;
        //在访问控制器时，进行IHttpClientFactory的初始化
        public TodayOnhistoryController(IHttpClientFactory _httpClient)
        {
            this._httpClient = _httpClient;
        }

        /// <summary>
        /// 历史上的今天-事件列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTodayOnhistory")]
        public async Task<ActionResult> GetTodayOnhistory(string key, string date)
        {
            //设置请求的路径
            var url = "http://v.juhe.cn/todayOnhistory/queryEvent.php?key=" + key + "&date=" + date;
            //使用注入的httpclientfactory获取client
            var client = _httpClient.CreateClient();
            //设置请求体中的内容，并以get的方式请求
            var response = await client.GetAsync(url);
            //获取请求到数据，并转化为字符串
            var result = response.Content.ReadAsStringAsync().Result;
            return new ContentResult { Content = result, ContentType = "application/json" };
        }

        /// <summary>
        /// 历史上的今天-根据id查事件详情
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTodaydetail")]
        public async Task<ActionResult> GetTodaydetail(string key, string e_id)
        {
            //设置请求的路径
            var url = "http://v.juhe.cn/todayOnhistory/queryDetail.php?key=" + key + "&e_id=" + e_id;
            //使用注入的httpclientfactory获取client
            var client = _httpClient.CreateClient();
            //设置请求体中的内容，并以get的方式请求
            var response = await client.GetAsync(url);
            //获取请求到数据，并转化为字符串
            var result = response.Content.ReadAsStringAsync().Result;
            return new ContentResult { Content = result, ContentType = "application/json" };
        }
    }

}