using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
    public class UnloadAppController : Controller
    {
        private static IHostingEnvironment _hostingEnvironment;

        public UnloadAppController( IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        ///  多文件上传
        /// </summary>
        /// <returns>服务器存储的文件信息</returns>
        [HttpGet]
        [Route("MultiFileAppUpload")]
        public JsonResult MultiFileAppUpload(string appid, string note, string version, IFormCollection formCollection)
        {
            var currentDate = DateTime.Now;
            var completeFilePath = "";
            var webRootPath = _hostingEnvironment.WebRootPath;//>>>相当于HttpContext.Current.Server.MapPath("") 
            var uploadFileRequestList = new List<UploadFileRequest>();
            try
            {
                //FormCollection转化为FormFileCollection
                var files = (FormFileCollection)formCollection.Files;

                if (files.Any())
                {
                    foreach (var file in files)
                    {
                        var uploadFileRequest = new UploadFileRequest();

                        var filePath = $"/UploadFile/App/{currentDate:yyyyMMdd}/";

                        //创建每日存储文件夹
                        if (!Directory.Exists(webRootPath + filePath))
                        {
                            Directory.CreateDirectory(webRootPath + filePath);
                        }

                        //文件后缀
                        var fileExtension = Path.GetExtension(file.FileName);//获取文件格式，拓展名

                        //判断文件大小
                        var fileSize = file.Length;

                        if (fileSize > 1024 * 1024 * 30) //10M TODO:(1mb=1024X1024b)
                        {
                            continue;
                        }

                        //保存的文件名称(以名称和保存时间命名)
                        var saveName = file.FileName.Substring(0, file.FileName.LastIndexOf('.')) + "_" + currentDate.ToString("HHmmss") + fileExtension;

                        //文件保存
                        using (var fs = System.IO.File.Create(webRootPath + filePath + saveName))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }

                        //完整的文件路径
                        completeFilePath = Path.Combine(filePath, saveName);

                        uploadFileRequestList.Add(new UploadFileRequest()
                        {
                            FileName = saveName,
                            FilePath = completeFilePath
                        });
                    }
                }
                else
                {
                    return new JsonResult(new { isSuccess = false, resultMsg = "上传失败，未检测上传的文件信息~" });
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { isSuccess = false, resultMsg = "文件保存失败，异常信息为：" + ex.Message });
            }

            if (uploadFileRequestList.Any())
            {
                SqlConnection sqlConnection =
                     new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql1 = "INSERT INTO [dbo].updateApp (appid, url,note,version) VALUES  ('" + appid+ "', '" + completeFilePath + "', '" + note + "', '" + version + "') ";
                SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sql1, sqlConnection);
                DataSet dataSet1 = new DataSet();
                sqlDataAdapter1.Fill(dataSet1);
                return new JsonResult(new { isSuccess = true, returnMsg = "上传成功", filePathArray = uploadFileRequestList });
            }
            else
            {
                return new JsonResult(new { isSuccess = false, resultMsg = "网络打瞌睡了，文件保存失败" });
            }
        }

    }

    /// <summary>
    /// 对文件上传响应模型
    /// </summary>
    public class UploadFileRequest
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath { get; set; }
    }
}