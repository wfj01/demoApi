using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using demo.Models.Joke;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.Api.Controllers.Calendar
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private IHttpClientFactory _httpClient;
        //在访问控制器时，进行IHttpClientFactory的初始化
        public CalendarController(IHttpClientFactory _httpClient)
        {
            this._httpClient = _httpClient;
        }

        /// <summary>
        /// 获取当天详细信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetcalendarDay")]
        public async Task<ActionResult> GetcalendarDay(string key, string date)
        {
            //设置请求的路径
            var url = "http://v.juhe.cn/calendar/day?key=" + key + "&date=" + date;
            //使用注入的httpclientfactory获取client
            var client = _httpClient.CreateClient();
            //设置请求体中的内容，并以get的方式请求
            var response = await client.GetAsync(url);
            //获取请求到数据，并转化为字符串
            var result = response.Content.ReadAsStringAsync().Result;
            return new ContentResult { Content = result, ContentType = "application/json" };
        }
        /// <summary>
        /// 查询近期假期
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Calendarmonth")]
        public async Task<ActionResult> Calendarmonth(string key, string yearmonth)
        {
            //设置请求的路径
            var url = "http://v.juhe.cn/calendar/month?key=" + key + "&year-month=" + yearmonth;
            //使用注入的httpclientfactory获取client
            var client = _httpClient.CreateClient();
            //设置请求体中的内容，并以get的方式请求
            var response = await client.GetAsync(url);
            //获取请求到数据，并转化为字符串
            var result = response.Content.ReadAsStringAsync().Result;
            return new ContentResult { Content = result, ContentType = "application/json" };
        }
        /// <summary>
        /// 查询当年假期
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Calendaryear")]
        public async Task<ActionResult> Calendaryear(string key, string year)
        {
            //设置请求的路径
            var url = "http://v.juhe.cn/calendar/year?key=" + key + "&year=" + year;
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