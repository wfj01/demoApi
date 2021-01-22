using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using demo.Models.Common;
using demo.Models.DemoEntities.Notice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.Api.Controllers.Notice
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticeController : ControllerBase
    {
        /// <summary>
        /// 加载公告列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("QueryNotice")]
        public JsonResult QueryNotice(string id)
        {
            SqlConnection sqlConnection =
            new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
            sqlConnection.Open();
            if (id == null)
            {
                try
                {
                   
                    string sql = "SELECT * FROM [demo].[dbo].[notice] ";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<notice>>.Return(0, "查询成功", dataSet);
                    }
                    else
                    {
                        return ApiResultBuilder<List<notice>>.Return(-1, "查无数据", dataSet);
                    }
                }
                catch (Exception e)
                {
                    return ApiResultBuilder<notice>.Return(-2, "数据异常" + e.Message);
                }
            }
            else
            {
                try
                {
                    string sql = "SELECT * FROM [demo].[dbo].[notice] where nid = '" + id + "'";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<notice>>.Return(0, "查询成功", dataSet);
                    }
                    else
                    {
                        return ApiResultBuilder<List<notice>>.Return(-1, "查无数据", dataSet);
                    }
                }
                catch (Exception e)
                {
                    return ApiResultBuilder<notice>.Return(-2, "数据异常" + e.Message);
                }
            }
        }
        /// <summary>
        /// 筛选公告列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ShaixuanNotice")]
        public JsonResult ShaixuanNotice(string source)
        {
            SqlConnection sqlConnection =
            new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
            sqlConnection.Open();
            if (source == null)
            {
                try
                {

                    string sql = "SELECT * FROM [demo].[dbo].[notice] ";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<notice>>.Return(0, "查询成功", dataSet);
                    }
                    else
                    {
                        return ApiResultBuilder<List<notice>>.Return(-1, "查无数据", dataSet);
                    }
                }
                catch (Exception e)
                {
                    return ApiResultBuilder<notice>.Return(-2, "数据异常" + e.Message);
                }
            }
            else
            {
                try
                {
                    string sql = "SELECT * FROM [demo].[dbo].[notice] where source = '" + source + "'";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<notice>>.Return(0, "查询成功", dataSet);
                    }
                    else
                    {
                        return ApiResultBuilder<List<notice>>.Return(-1, "查无数据", dataSet);
                    }
                }
                catch (Exception e)
                {
                    return ApiResultBuilder<notice>.Return(-2, "数据异常" + e.Message);
                }
            }
        }
        /// <summary>
        /// 新增一条数据
        /// </summary>
        /// <param name="notice"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PostNoticeText")]
        public JsonResult PostNoticeText([FromBody]notice notice)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                var TimeStamps = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;

                string sql = "INSERT INTO [demo].[dbo].[notice](title,jianjie,details,source,datatime) VALUES" +
                    "('" + notice.Title + "','" + notice.Jianjie + "','" + notice.Details + "','" + notice.Source + "','" + TimeStamps+"') ";
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);
                return new JsonResult(new { rtnCode = 0, resultMsg = "保存成功"});
            }
            catch (Exception e)
            {
                return ApiResultBuilder<notice>.Return(-2, "数据异常" + e.Message);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="notice"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpDataNoticeText")]
        public JsonResult UpDataNoticeText([FromBody]notice notice)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                var TimeStamps = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;

                string sql = "UPDATE [demo].[dbo].[notice] set title='"+notice.Title+"',jianjie='"+notice.Jianjie+"',details='"+notice.Details+"',source='"+notice.Source+"',datatime='"+TimeStamps+"' where nid = '"+notice.Nid+"'";
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);
                return new JsonResult(new { rtnCode = 0, resultMsg = "更新成功" });
            }
            catch (Exception e)
            {
                return ApiResultBuilder<notice>.Return(-2, "数据异常" + e.Message);
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("PostRemoveList")]
        public JsonResult PostRemoveList(string id)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                string sql = "DELETE FROM  [demo].[dbo].[notice] where nid ='" + id + "'";
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);
                return new JsonResult(new { rtnCode = 0, resultMsg = "删除成功" });
            }
            catch (Exception e)
            {
                return ApiResultBuilder<notice>.Return(-2, "数据异常" + e.Message);
            }
        }
    }
}