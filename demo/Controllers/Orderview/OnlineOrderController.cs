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
        [Route("unOrderqueryUser")]
        public JsonResult QueryUser()
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "SELECT * FROM [demo].[dbo].[Order] where isSubmit = 'true' and isConfirm='false' and isComplete='false'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<List<Online>>.Return(0,"查询成功",dataSet);
                }
                else
                {
                    return ApiResultBuilder<Online>.Return(-1, "查无数据",dataSet);
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
        [Route("confirmedOrder")]
        public JsonResult ConfirmedOrder()
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "SELECT * FROM [demo].[dbo].[Order] where isConfirm='true' and isComplete='false'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<List<Online>>.Return(0, "查询成功", dataSet);
                }
                else
                {
                    return ApiResultBuilder<Online>.Return(-1, "查无数据",dataSet);
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
        [Route("completedOrder")]
        public JsonResult CompletedOrder()
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "SELECT * FROM [demo].[dbo].[Order] where isConfirm='true' and isComplete='true'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<List<Online>>.Return(0, "查询成功", dataSet);
                }
                else
                {
                    return ApiResultBuilder<Online>.Return(-1, "查无数据",dataSet);
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Online>.Return(-2, "数据异常" + e.Message);
            }
        }

        [HttpGet]
        [Route("confirmorder")]
        public JsonResult Confirmorder([FromQuery] Online online,string id)
        {


            try
            {
                SqlConnection sqlConnection =
                new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "UPDATE [demo].[dbo].[Order] set isConfirm='" + true + "',updatetime='"+online.UpdateTime+"'where id='" + id + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);

                return ApiResultBuilder<Online>.Return(0, "确认订单成功",dataSet);
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Online>.Return(-2, "数据异常" + e.Message);
            }
        }

        [HttpGet]
        [Route("completemorder")]
        public JsonResult Completemorder([FromQuery] Online online, string id)
        {
            try
            {
                SqlConnection sqlConnection =
                new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "UPDATE [demo].[dbo].[Order] set isComplete='" + true + "',updatetime='" + online.UpdateTime + "'where id='" + id + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                return ApiResultBuilder<Online>.Return(0, "订单已完成",dataSet);
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Online>.Return(-2, "数据异常" + e.Message);
            }
        }
    }
}