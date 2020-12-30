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
    public class BusinessRegisterController : ControllerBase
    {
        /// <summary>
        /// 向数据库中添加数据
        /// </summary>
        /// <param name="businessLogin"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("postUser")]
        public JsonResult PostUser([FromBody]BusinessLogin businessLogin)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                string sql1 = "SELECT * FROM [demo].[dbo].[businessMessage] WHERE license='" + businessLogin.License + "'";
                SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sql1, sqlConnection);
                DataSet dataSet1 = new DataSet();
                sqlDataAdapter1.Fill(dataSet1);
                if ((dataSet1 != null && dataSet1.Tables.Count > 0 && dataSet1.Tables[0].Rows.Count > 0) == true)
                {
                    return ApiResultBuilder<List<BusinessLogin>>.Return(-1, "授权码已存在");
                }
                string sql = "INSERT INTO [demo].[dbo].[businessMessage] VALUES('" + businessLogin.Name + "','" + businessLogin.Password + "','" + businessLogin.Shopname + "','" + businessLogin.Shopaddress + "','" + businessLogin.Phonenumber + "','" + businessLogin.Selfintroduction + "','" + businessLogin.Createddate + "','" + businessLogin.Updatedate + "','" + businessLogin.License + "') ";
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);
                return ApiResultBuilder<List<BusinessLogin>>.Return(0, "注册成功");
                //return JsonConvert.SerializeObject(dataSet);
            }
            catch (Exception e)
            {
                return ApiResultBuilder<BusinessLogin>.Return(-2, "数据异常" + e.Message);
            }
        }
    }
}