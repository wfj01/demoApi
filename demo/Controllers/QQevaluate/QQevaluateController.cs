﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using demo.Models.Joke;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.Api.Controllers.QQevaluate
{
    [Route("api/[controller]")]
    [ApiController]
    public class QQevaluateController : ControllerBase
    {
        private IHttpClientFactory _httpClient;
        //在访问控制器时，进行IHttpClientFactory的初始化
        public QQevaluateController(IHttpClientFactory _httpClient)
        {
            this._httpClient = _httpClient;
        }

        /// <summary>
        /// QQ凶吉解释
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetQQevaluate")]
        public async Task<ActionResult> GetQQevaluate(string key, string qq)
        {
            //设置请求的路径
            var url = "http://japi.juhe.cn/qqevaluate/qq?key=" + key + "&qq=" + qq;
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