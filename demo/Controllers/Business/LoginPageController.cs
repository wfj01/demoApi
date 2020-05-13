using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using demo.Models.Common;
using demo.Models.DemoEntities.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.Api.Controllers.Business
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginPageController : ControllerBase
    {
        /// <summary>
        /// 登录接口
        /// </summary>
        /// <param name="businessLogin"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getUser")]
        public JsonResult Login([FromQuery]BusinessLogin businessLogin)
        {
            try
            {
                SqlConnection sqlConnection =
                     new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql1 = "SELECT * FROM [demo].[dbo].[businessMessage] where name='" + businessLogin.Name + "'";
                SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sql1, sqlConnection);
                DataSet dataSet1 = new DataSet();
                sqlDataAdapter1.Fill(dataSet1);
                string sql2 = "SELECT * FROM [demo].[dbo].[businessMessage] where password='" + businessLogin.Password + "'";
                SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sql2, sqlConnection);
                DataSet dataSet2 = new DataSet();
                sqlDataAdapter2.Fill(dataSet2);
                string sql3= "SELECT name FROM [demo].[dbo].[licenseCode] Where code='" + businessLogin.License+"'";
                SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sql3, sqlConnection);
                DataSet dataSet3= new DataSet();
                sqlDataAdapter3.Fill(dataSet3);
                if ((dataSet3 != null && dataSet3.Tables.Count > 0 && dataSet3.Tables[0].Rows.Count > 0))
                {
                    if ((dataSet1 != null && dataSet1.Tables.Count > 0 && dataSet1.Tables[0].Rows.Count > 0) &&
                    (dataSet2 != null && dataSet2.Tables.Count > 0 && dataSet2.Tables[0].Rows.Count > 0))
                {
                    return new JsonResult("查询成功");
                }
                else
                {
                    if ((dataSet1 != null && dataSet1.Tables.Count > 0 && dataSet1.Tables[0].Rows.Count > 0) == false)
                    {
                        return ApiResultBuilder<List<BusinessLogin>>.Return(-1, "Id不正确");
                    }
                    else
                    {
                        return ApiResultBuilder<List<BusinessLogin>>.Return(-1, "密码不正确");
                    }
                }
                }
                else
                {
                    return ApiResultBuilder<List<BusinessLogin>>.Return(-1, "授权码不正确");
                }

            }
            catch (Exception e)
            {
                return ApiResultBuilder<BusinessLogin>.Return(-2, "数据异常" + e.Message);
            }
        }

        [HttpGet]
        [Route("personaldata")]
        public JsonResult Personaldata()
        {
            try
            {
                SqlConnection sqlConnection =
                new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "SELECT * FROM businessMessage where name='王富军'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<List<BusinessLogin>>.Return(0,"查询成功",dataSet);
                }
                else
                {
                    return ApiResultBuilder<BusinessLogin>.Return(-1, "查无数据");
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<BusinessLogin>.Return(-2, "数据异常" + e.Message);
            }
        }
    }
}