using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using demo.Models.Joke;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.Api.Controllers.Chinesezodiac
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChinesezodiacController : ControllerBase
    {
        private IHttpClientFactory _httpClient;
        //在访问控制器时，进行IHttpClientFactory的初始化
        public ChinesezodiacController(IHttpClientFactory _httpClient)
        {
            this._httpClient = _httpClient;
        }

        /// <summary>
        /// 生肖配对
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetShengxiaopd")]
        public async Task<ActionResult> GetShengxiaopd(string key, string men, string women)
        {
            //设置请求的路径
            var url = "http://apis.juhe.cn/sxpd/query?key=" + key + "&men=" + men + "&women=" + women;
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