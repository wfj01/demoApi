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

namespace demo.Api.Controllers
{
    /// <summary>
    /// 大学城订餐接口
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeTownController : ControllerBase
    {
        /// <summary>
        /// 大学城-加载
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
                string sql = "SELECT * FROM [demo].[dbo].[collegetown]";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<List<Collegetown>>.Return(dataSet);
                }
                else
                {
                    return new JsonResult("查无数据");
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Collegetown>.Return(-2, "数据异常" + e.Message);
            }

        }
    }
}