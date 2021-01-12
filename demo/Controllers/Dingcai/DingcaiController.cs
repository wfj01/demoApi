using System;
using System.Data;
using System.Data.SqlClient;
using demo.Models.Common;
using demo.Models.DemoEntities.Dingcai;
using Microsoft.AspNetCore.Mvc;

namespace demo.Api.Controllers.Dingcai
{
    [Route("api/[controller]")]
    [ApiController]
    public class DingcaiController : ControllerBase
    {
        #region 加载顶踩排行榜列表
        /// <summary>
        /// 查询顶踩列表信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("QueryDingCaiList")]
        public JsonResult QueryDingCaiList()
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "select top 50 * from [dbo].dingcai  order by cishu ";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<DingCaiCai>.Return(0, "查询成功", dataSet);
                }
                else
                {
                    return ApiResultBuilder<DingCaiCai>.Return(-1, "查无数据", dataSet);
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<DingCaiCai>.Return(-2, "数据异常" + e.Message);
            }
        }
        #endregion

        #region 加入顶踩
        /// <summary>
        /// 向顶踩中添加数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("PostDingCai")]
        public JsonResult PostDingCai([FromForm] DingCaiCai dingcaicai)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                var TimeStamps = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
                string sql = "INSERT INTO [demo].[dbo].[dingcai](username,detail,isdingcai,cishu,dateTime) VALUES('" + dingcaicai.Username + "','" + dingcaicai.Detail + "','" + dingcaicai.IsDingcai + "','" + dingcaicai.Cishu + "','" + TimeStamps + "') ";
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);
                return ApiResultBuilder<DingCaiCai>.Return(0, "保存到排行榜成功");
            }
            catch (Exception e)
            {
                return ApiResultBuilder<DingCaiCai>.Return(-2, "数据异常" + e.Message);
            }
        }
        #endregion
    }
}
