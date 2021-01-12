using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using demo.Models.Common;
using demo.Models.DemoEntities.Billboard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.Api.Controllers.QueryBillboard
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryBillboardController : ControllerBase
    {
        #region 加载排行榜列表
        /// <summary>
        /// 查询排行榜列表信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("QueryBillboardList")]
        public JsonResult QueryBillboardList(string mokuai)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "select top 30 * from [dbo].billboard where mokuai = '"+mokuai+"' order by score ";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<Billboard>.Return(0, "查询成功", dataSet);
                }
                else
                {
                    return ApiResultBuilder<Billboard>.Return(-1, "查无数据", dataSet);
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Billboard>.Return(-2, "数据异常" + e.Message);
            }
        }
        #endregion

        #region 加入排行榜
        /// <summary>
        /// 向排行榜中添加数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("PostBillboard")]
        public JsonResult PostBillboard(string Name, string Score,string Mokuai)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                var TimeStamps = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
                string sql = "INSERT INTO [demo].[dbo].[billboard](name,score,datetime,mokuai) VALUES('" + Name + "','" + Score + "','" + TimeStamps + "','" + Mokuai + "') ";
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);
                return ApiResultBuilder<Billboard>.Return(0, "保存到排行榜成功");
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Billboard>.Return(-2, "数据异常" + e.Message);
            }
        }
        #endregion
    }
}