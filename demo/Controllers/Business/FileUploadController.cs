﻿using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace FileUploadManage.Controllers
{
    /// <summary>
    /// 图片，视频，音频，文档等相关文件通用上传服务类
    /// </summary>
    public class FileUploadController : Controller
    {
        private static IHostingEnvironment _hostingEnvironment;

        public FileUploadController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        ///  多文件上传
        /// </summary>
        /// <param name="formCollection">表单集合值</param>
        /// <returns>服务器存储的文件信息</returns>
        [HttpPost]
        [Route("MultiFileUpload")]
        public JsonResult MultiFileUpload(IFormCollection formCollection)
        {
            var currentDate = DateTime.Now;
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

                        var filePath = $"/UploadFile/{currentDate:yyyyMMdd}/";

                        //创建每日存储文件夹
                        if (!Directory.Exists(webRootPath + filePath))
                        {
                            Directory.CreateDirectory(webRootPath + filePath);
                        }

                        //文件后缀
                        var fileExtension = Path.GetExtension(file.FileName);//获取文件格式，拓展名

                        //判断文件大小
                        var fileSize = file.Length;

                        if (fileSize > 1024 * 1024 * 10) //10M TODO:(1mb=1024X1024b)
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
                        var completeFilePath = Path.Combine(filePath, saveName);

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