using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using demo.Models.DemoEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using demo.Models.Common;
using Newtonsoft.Json;

namespace demo.Api.Controllers
{
    /// <summary>
    /// 注册验证接口
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        //[HttpGet]
        //[Route("queryUser")]
        //public string QueryUser()
        //{
        //    try
        //    {
        //        SqlConnection sqlConnection =
        //         new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
        //        sqlConnection.Open();
        //        string sql = "SELECT * FROM [demo].[dbo].[Student]";
        //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
        //        DataSet dataSet = new DataSet();
        //        sqlDataAdapter.Fill(dataSet);
        //        if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        //        {
        //            return JsonConvert.SerializeObject(dataSet);
        //        }
        //        else
        //        {
        //            return ("查无数据");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.ToString();
        //    }

        //}

        /// <summary>
        /// 向数据库中添加数据
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("postUser")]
        public JsonResult PostUser([FromBody]Register register)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                string sql1 = "SELECT * FROM [demo].[dbo].[Student] WHERE studentid='" + register.Studentid + "'";
                SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sql1, sqlConnection);
                DataSet dataSet1 = new DataSet();
                sqlDataAdapter1.Fill(dataSet1);
                if ((dataSet1 != null && dataSet1.Tables.Count > 0 && dataSet1.Tables[0].Rows.Count > 0) == true)
                {
    return ApiResultBuilder<List<Login>>.Return(-1, "账号已存在");
                }
                string sql = "INSERT INTO [demo].[dbo].[Student] VALUES('"+register.Id+"','" + register.Studentid + "','" + register.Studentname + "','" + register.Password + "','" + register.Telephone + "','" + register.Address + "','" + register.Email + "'," + register.Sex + ",'"+register.Birtherdate+"','"+register.Createtime+"','"+register.Updatetime+"') ";
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);
                return ApiResultBuilder<List<Login>>.Return(0, "注册成功");
                //return JsonConvert.SerializeObject(dataSet);
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Login>.Return(-2, "数据异常" + e.Message);
            }
        }
    }
}