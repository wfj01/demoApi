using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.Api.Controllers.Weather
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimpleWeatherController : ControllerBase
    {
        private IHttpClientFactory _httpClient;
        //在访问控制器时，进行IHttpClientFactory的初始化
        public SimpleWeatherController(IHttpClientFactory _httpClient)
        {
            this._httpClient = _httpClient;
        }

        /// <summary>
        /// 城市天气预报
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCityWeather")]
        public async Task<ActionResult> GetCityWeather(string key, string city)
        {
            //设置请求的路径
            var url = "http://apis.juhe.cn/simpleWeather/query?key=" + key + "&city=" + city;
            //使用注入的httpclientfactory获取client
            var client = _httpClient.CreateClient();
            //设置请求体中的内容，并以get的方式请求
            var response = await client.GetAsync(url);
            //获取请求到数据，并转化为字符串
            var result = response.Content.ReadAsStringAsync().Result;
            return new ContentResult { Content = result, ContentType = "application/json" };
        }

        /// <summary>
        /// 城市天气预报
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCityShiYi")]
        public async Task<ActionResult> GetCityShiYi(string key, string city)
        {
            //设置请求的路径
            var url = "http://apis.juhe.cn/simpleWeather/life?key=" + key + "&city=" + city;
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