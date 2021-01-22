using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using demo.Models.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace demo.Api.Controllers.UnloadApp
{
    /// <summary>
    /// 上传APP文件用来更新
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UnloadAppController : Controller
    {
        /// <summary>
        ///  多文件上传
        /// </summary>
        /// <returns>服务器存储的文件信息</returns>
        [HttpGet]
        [Route("MultiFileAppUploadd")]
        public JsonResult MultiFileAppUploadd(string Appid, string Fileurl, string Note, string Version, string Versionnum)
        {
            try
            {
                SqlConnection sqlConnection =
                     new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                var TimeStamps = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
                string sql1 = "INSERT INTO [dbo].updateApp (appid, url,note,version,versionnum,date) VALUES  ('" + Appid + "', '" + Fileurl + "', '" + Note + "', '" + Version + "','" + Versionnum + "','" + TimeStamps + "') ";
                SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sql1, sqlConnection);
                DataSet dataSet1 = new DataSet();
                sqlDataAdapter1.Fill(dataSet1);
                if (dataSet1 != null && dataSet1.Tables.Count > 0 && dataSet1.Tables[0].Rows.Count > 0)
                {
                    return new JsonResult(new { isSuccess = -1, returnMsg = "上传失败" });
                }
                else
                {
                    return new JsonResult(new { isSuccess = 0, returnMsg = "上传成功" });
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<UploadFileRequest>.Return(-2, "数据异常" + e.Message);
            }
        }
    }
    /// <summary>
    /// 对文件上传响应模型
    /// </summary>
    public class UploadFileRequest
    {
        
        public string Appid { get; set; }
        public string Fileurl { get; set; }
        public string Note { get; set; }
        public string Version { get; set; }
        public string Versionnum { get; set; }
    }
}
