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
                string sql1 = "SELECT * FROM [demo].[dbo].[Student] where studentid='" + login.Studentid+"'";
                SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sql1, sqlConnection);
                DataSet dataSet1 = new DataSet();
                sqlDataAdapter1.Fill(dataSet1);
                string sql2 = "SELECT * FROM [demo].[dbo].[Student] where password='" + login.Password + "'";
                SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sql2, sqlConnection);
                DataSet dataSet2 = new DataSet();
                sqlDataAdapter2.Fill(dataSet2);
                if ((dataSet1 != null && dataSet1.Tables.Count > 0 && dataSet1.Tables[0].Rows.Count > 0) &&
                    (dataSet2 != null && dataSet2.Tables.Count > 0 && dataSet2.Tables[0].Rows.Count > 0))
                {
                    return new JsonResult("查询成功");
                }
                else
                {
                    if ((dataSet1 != null && dataSet1.Tables.Count > 0 && dataSet1.Tables[0].Rows.Count > 0) == false)
                    {
                        return ApiResultBuilder<List<Login>>.Return(-1, "Id不正确");
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
    }
}