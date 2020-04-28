using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using demo.Models;
using demo.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnlineOrderController : ControllerBase
    {
        /// <summary>
        /// 未确认订单查询
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
                string sql = "SELECT * FROM [demo].[dbo].[Online] where isConfirm='false' and i";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<List<Online>>.Return(dataSet);
                }
                else
                {
                    return ApiResultBuilder<Online>.Return(-1, "查无数据");
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Online>.Return(-2, "数据异常" + e.Message);
            }
        }

        /// <summary>
        /// 已确认的订单查询
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("queryUsera")]
        public JsonResult QueryUsera()
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "SELECT * FROM [demo].[dbo].[Online] where isComplete='true'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<List<Online>>.Return(dataSet);
                }
                else
                {
                    return ApiResultBuilder<Online>.Return(-1, "查无数据");
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Online>.Return(-2, "数据异常" + e.Message);
            }
        }

        /// <summary>
        /// 已完成的订单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("queryUserb")]
        public JsonResult QueryUserb()
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "SELECT * FROM [demo].[dbo].[Online] where isComplete='true'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<List<Online>>.Return(dataSet);
                }
                else
                {
                    return ApiResultBuilder<Online>.Return(-1, "查无数据");
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Online>.Return(-2, "数据异常" + e.Message);
            }
        }

        [HttpGet]
        [Route("confirmorder")]
        public JsonResult Confirmorder(string id)
        {
            try
            {
                SqlConnection sqlConnection =
                new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "UPDATE [demo].[dbo].[Online] set isConfirm='" + true + "'where id='" + id + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                return ApiResultBuilder<Online>.Return(0, "确认订单成功");
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Online>.Return(-2, "数据异常" + e.Message);
            }
        }

        [HttpGet]
        [Route("completemorder")]
        public JsonResult Completemorder(string id)
        {
            try
            {
                SqlConnection sqlConnection =
                new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "UPDATE [demo].[dbo].[Online] set isComplete='" + true + "'where id='" + id + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                return ApiResultBuilder<Online>.Return(0, "订单已完成");
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Online>.Return(-2, "数据异常" + e.Message);
            }
        }
    }
}