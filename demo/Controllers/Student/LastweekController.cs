using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using demo.Models.Common;
using demo.Models.DemoEntities.Student;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.Api.Controllers.Student
{
    [Route("api/[controller]")]
    [ApiController]
    public class LastweekController : ControllerBase
    {
        /// <summary>
        /// 本月榜单加载数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("queryUser")]
        public JsonResult QueryUser()
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "SELECT * FROM [demo].[dbo].[lastweek]";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<List<Lastweek>>.Return(dataSet);
                }
                else
                {
                    return ApiResultBuilder<Lastweek>.Return(-1, "查无数据");
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Taday>.Return(-2, "数据异常" + e.Message);
            }
        }
    }
}