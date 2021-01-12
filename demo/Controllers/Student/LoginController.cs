using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using demo.Models.Common;
using demo.Models.DemoEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace demo.Api.Controllers
{

    /// <summary>
    /// 登录验证接口
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        /// <summary>
        /// 登录接口
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getUser")]
        public JsonResult Login([FromQuery]Login login)
        {
            try
            {
                SqlConnection sqlConnection =
                     new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql1 = "SELECT * FROM [demo].[dbo].[user] where username='" + login.Username+"'";
                SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sql1, sqlConnection);
                DataSet dataSet1 = new DataSet();
                sqlDataAdapter1.Fill(dataSet1);
                string sql2 = "SELECT * FROM [demo].[dbo].[user] where password='" + login.Password + "'and username='" + login.Username + "'";
                SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sql2, sqlConnection);
                DataSet dataSet2 = new DataSet();
                sqlDataAdapter2.Fill(dataSet2);
                string sql3 = "SELECT name FROM [demo].[dbo].[user] where username='" + login.Username + "'";
                SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sql2, sqlConnection);
                DataSet dataSet3 = new DataSet();
                sqlDataAdapter3.Fill(dataSet3);
                if ((dataSet1 != null && dataSet1.Tables.Count > 0 && dataSet1.Tables[0].Rows.Count > 0) &&
                    (dataSet2 != null && dataSet2.Tables.Count > 0 && dataSet2.Tables[0].Rows.Count > 0))
                {
                    return ApiResultBuilder<List<Login>>.Return(0, "登录成功",dataSet3);
                }
                else
                {
                    if ((dataSet1 != null && dataSet1.Tables.Count > 0 && dataSet1.Tables[0].Rows.Count > 0) == false)
                    {
                        return ApiResultBuilder<List<Login>>.Return(-1, "账号不正确");
                    }
                    else
                    {
                        return ApiResultBuilder<List<Login>>.Return(-1, "密码不正确");
                    }
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Login>.Return(-2, "数据异常" + e.Message);
            }
        }


        /// <summary>
        /// 登录接口
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("searchdata")]
        public JsonResult Searchdata(string username)
        {
            try
            {
                SqlConnection sqlConnection =
                     new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql1 = "SELECT * FROM [demo].[dbo].[user] where username='" + username + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql1, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<List<Login>>.Return(0, "查询成功", dataSet);
                }
                else
                {
                    return ApiResultBuilder<List<Login>>.Return(-1, "查无数据", dataSet);
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Login>.Return(-2, "数据异常" + e.Message);
            }
        }
    }
}