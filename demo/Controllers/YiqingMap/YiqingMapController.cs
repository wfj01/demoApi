using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.Api.Controllers.YiqingMap
{
    [Route("api/[controller]")]
    [ApiController]
    public class YiqingMapController : ControllerBase
    {
        private IHttpClientFactory _httpClient;
        //在访问控制器时，进行IHttpClientFactory的初始化
        public YiqingMapController(IHttpClientFactory _httpClient)
        {
            this._httpClient = _httpClient;
        }
        /// <summary>
        /// 疫情分布地图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("SpreadQuery")]
        public async Task<ActionResult> SpreadQuery()
        {
            //设置请求的路径
            var url = "https://qayz.api.storeapi.net/api/94/219?format=json&appid=5183&sign=3165718bda855c9254aab2f966c47d3f";
            //使用注入的httpclientfactory获取client
            var client = _httpClient.CreateClient();
            //设置请求体中的内容，并以get的方式请求
            var response = await client.GetAsync(url);
            //获取请求到数据，并转化为字符串
            var result = response.Content.ReadAsStringAsync().Result;
            return new ContentResult { Content = result, ContentType = "application/json" };
        }

        /// <summary>
        /// 百度地图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("BaiduCodeQuery")]
        public async Task<ActionResult> BaiduCodeQuery(string city)
        {
            //设置请求的路径
            var url = "http://api.map.baidu.com/geocoder?address=" +
                      city +
                      "&output=json&key=ccrbBUEq6Ai1FY3KxhdbFCjXdWZu2RF8";
            //使用注入的httpclientfactory获取client
            var client = _httpClient.CreateClient();
            //设置请求体中的内容，并以get的方式请求
            var response = await client.GetAsync(url);
            //获取请求到数据，并转化为字符串
            var result = response.Content.ReadAsStringAsync().Result;
            return new ContentResult { Content = result, ContentType = "application/json" };
        }
        /// <summary>
        /// 国内疫情
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCityQuery")]
        public async Task<ActionResult> CityQuery(string cityname,string sign)
        {
            //设置请求的路径
            var url = "https://qayz.api.storeapi.net/api/94/221?format=json&appid=5183&city_name=" + cityname + "&sign="+sign+"";
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