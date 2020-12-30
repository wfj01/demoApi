using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using demo.Models.Joke;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.Api.Controllers.Oneiromancy
{
    [Route("api/[controller]")]
    [ApiController]
    public class OneiromancyController : ControllerBase
    {
        private IHttpClientFactory _httpClient;
        //在访问控制器时，进行IHttpClientFactory的初始化
        public OneiromancyController(IHttpClientFactory _httpClient)
        {
            this._httpClient = _httpClient;
        }

        /// <summary>
        /// 获取类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCategory")]
        public async Task<ActionResult> GetCategory(string key, string fid)
        {
            //设置请求的路径
            var url = "http://v.juhe.cn/dream/category?key=" + key + "&fid=" + fid;
            //使用注入的httpclientfactory获取client
            var client = _httpClient.CreateClient();
            //设置请求体中的内容，并以get的方式请求
            var response = await client.GetAsync(url);
            //获取请求到数据，并转化为字符串
            var result = response.Content.ReadAsStringAsync().Result;
            return new ContentResult { Content = result, ContentType = "application/json" };
        }
        /// <summary>
        /// 解梦查询
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Dreamquery")]
        public async Task<ActionResult> Dreamquery(string key, string q,string cid,string full)
        {
            //设置请求的路径
            var url = "http://v.juhe.cn/dream/query?key=" + key + "&q=" + q + "&cid="+ cid+ "&full="+ full;
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