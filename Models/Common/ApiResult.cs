using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace demo.Models.Common
{
    /// <summary>
    /// Api 返回值的构造器
    /// </summary>
    public class ApiResultBuilder<T> where T : class//, new()
    {
        public static JsonResult Return(ReturnResultNormal<T> obj)
        {
            return new JsonResult(obj);
        }

        public static JsonResult Return(DataSet obj)
        {
            return new JsonResult(new ReturnResultNormal<DataSet>(obj));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rtnCode"></param>
        /// <param name="rtnMsg"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static JsonResult Return(int rtnCode, string rtnMsg = "", DataSet data = null)
        {
            return new JsonResult(new ReturnResultNormal<T>(rtnCode, rtnMsg, data));
        }

        /// <summary>
        /// 执行成功，返回码=0
        /// </summary>
        /// <returns></returns>
        public static JsonResult Ok()
        {
            return new JsonResult(new ReturnResultNormal<T>());
        }


        /// <summary>
        /// 请求失败
        /// </summary>
        /// <param name="msg">错误消息</param>
        /// <returns></returns>
        public static JsonResult BadRequest(string msg = "请求无效")
        {
            var result = new JsonResult(new ReturnResultNormal<T>(400, msg));

            return result;
        }

        public static JsonResult Return(int v1, string v2, SqlDataAdapter sqlDataAdapter2)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 请求失败
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public static JsonResult BadRequest(ModelStateDictionary modelState)
        {
            var returnObj = new ReturnResultNormal<T>
            {
                //RtnCode = 400,
                //RtnMsg = "无效的请求." + JsonConvert.SerializeObject(modelState)
            };


            var result = new JsonResult(returnObj);
            return result;
        }

        /// <summary>
        /// 请求失败
        /// </summary>
        /// <param name="field"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public static JsonResult BadRequest(string field, string errMsg)
        {
            var returnObj = new ReturnResultNormal<T>
            {
                //RtnCode = 400,
                //RtnMsg = $"{{\"Name\":\"{field}\",\"Error\":\"{errMsg}\"}}"
            };

            var result = new JsonResult(returnObj);
            //{
            //    StatusCode = 400
            //};

            return result;
        }


        /// <summary>
        /// 未找到指定的数据
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static JsonResult NotFound(string msg = "未找到对应的数据")
        {
            return new JsonResult(new ReturnResultNormal<T>(404, msg));
        }
    }
}
