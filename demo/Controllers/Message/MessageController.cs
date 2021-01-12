using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using demo.Models.Common;
using demo.Models.DemoEntities.Message;
using Microsoft.AspNetCore.Mvc;

namespace demo.Api.Controllers.Messagee
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        #region 加载消息列表
        /// <summary>
        /// 查询消息列表信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("QueryMessage")]
        public JsonResult QueryMessage(string IsShow,string Username)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "SELECT * FROM [demo].[dbo].[message] where isshow='"+IsShow+"'And username='"+ Username+ "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<Message>.Return(0, "查询成功", dataSet);
                }
                else
                {
                    return ApiResultBuilder<Message>.Return(-1, "查无数据", dataSet);
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Message>.Return(-2, "数据异常" + e.Message);
            }
        }
        #endregion

        /// <summary>
        /// 更新数据（查看消息）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("UpdateMessage")]
        public JsonResult UpdateMessage(string Mid, string Username)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                string sql = "UPDATE [demo].[dbo].[message] SET isshow=" + 1 + "where mid='" + Mid + "'And username='" + Username + "'";
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);
                return ApiResultBuilder<Message>.Return(0, "查询成功", dataSet);
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Message>.Return(-2, "数据异常" + e.Message);
            }
        }
        #region 
        /// <summary>
        /// 全部已读
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("PostMessage")]
        public JsonResult PostMessage(string Username)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                string sql = "UPDATE [demo].[dbo].[message] SET isshow=" + 1 + "where  username='" + Username + "'";
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);
                return ApiResultBuilder<Message>.Return(0, "全部已读成功");
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Message>.Return(-2, "数据异常" + e.Message);
            }
        }
        #endregion
    }
}