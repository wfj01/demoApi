using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using demo.Models;
using demo.Models.Common;
using demo.Models.DemoEntities;
using demo.Models.DemoEntities.Student;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.Api.Controllers.Student
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        
        /// <summary>
        /// 提交订单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("confirmorder")]
        public JsonResult Confirmorder([FromBody]List<IdList> orders,string Name, string Address, string Phone)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                var TimeStamps = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
                foreach (var item in orders)
                {
                    string sql = "UPDATE [demo].[dbo].[order] SET name='"+Name+"',address='"+Address + "',phone='"+Phone+"',isSubmit='"+1+"',updatetime='"+ TimeStamps + "'where orderid='"+item.OrderId+"'";
                    DataSet dataSet = new DataSet();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                    sqlDataAdapter.Fill(dataSet);
                }
                return new JsonResult(new { rtnCode = 0, resultMsg = "保存到购物车成功", data = TimeStamps });
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Online>.Return(-2, "数据异常" + e.Message);
            }
        }
        /// <summary>
        /// 订单详情
        /// </summary>
        /// <param name="username"></param>
        /// <param name="orderid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("QueryOrderDetail")]
        public JsonResult QueryOrderDetail(string username,string orderid)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "SELECT * FROM [demo].[dbo].[order] where username='" + username + "'And orderid='" + orderid + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<List<FoodList>>.Return(0, "查询成功", dataSet);
                }
                else
                {
                    return ApiResultBuilder<FoodList>.Return(-1, "查无数据", dataSet);
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<FoodList>.Return(-2, "数据异常" + e.Message);
            }
        }
        /// <summary>
        /// 全部订单
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("QueryOrderList")]
        public JsonResult QueryOrderList(string username)
        {
            if (username == null) {
                username = "";
                try
                {
                    SqlConnection sqlConnection =
                     new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                    sqlConnection.Open();
                    string sql = "SELECT * FROM [demo].[dbo].[order] ";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<FoodList>>.Return(0, "查询成功", dataSet);
                    }
                    else
                    {
                        return ApiResultBuilder<FoodList>.Return(-1, "查无数据", dataSet);
                    }
                }
                catch (Exception e)
                {
                    return ApiResultBuilder<FoodList>.Return(-2, "数据异常" + e.Message);
                }

            }
            else
            {
                try
                {
                    SqlConnection sqlConnection =
                     new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                    sqlConnection.Open();
                    string sql = "SELECT * FROM [demo].[dbo].[order] where username='" + username + "'And isSubmit='" + 1 + "'";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<FoodList>>.Return(0, "查询成功", dataSet);
                    }
                    else
                    {
                        return ApiResultBuilder<FoodList>.Return(-1, "查无数据", dataSet);
                    }
                }
                catch (Exception e)
                {
                    return ApiResultBuilder<FoodList>.Return(-2, "数据异常" + e.Message);
                }

            }
        }
        /// <summary>
        /// 已完成订单（未完成订单）
        /// </summary>
        /// <param name="username"></param>
        /// <param name="Complete"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("QueryCompleteOrderList")]
        public JsonResult QueryCompleteOrderList(string username, string Complete)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "SELECT * FROM [demo].[dbo].[order] where username='" + username + "'And isComplete='" + Complete + "'And isSubmit='" + 1 + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<List<FoodList>>.Return(0, "查询成功", dataSet);
                }
                else
                {
                    return ApiResultBuilder<FoodList>.Return(-1, "查无数据", dataSet);
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<FoodList>.Return(-2, "数据异常" + e.Message);
            }
        }
        /// <summary>
        /// 完成订单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("PostOrder")]
        public JsonResult PostOrder(string username, string orderid)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "UPDATE [demo].[dbo].[order] set isComplete='" + 1+"' where username='" + username + "'And orderid='" + orderid + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                return ApiResultBuilder<List<FoodList>>.Return(0, "更新成功", dataSet);
            }
            catch (Exception e)
            {
                return ApiResultBuilder<FoodList>.Return(-2, "数据异常" + e.Message);
            }
        }
        /// <summary>
        /// 已完成评价（未完成评价）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("QueryEvaluateOrderList")]
        public JsonResult QueryEvaluateOrderList(string username, string Evaluate)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "SELECT * FROM [demo].[dbo].[order] where username='" + username + "'And isEvaluate='" + Evaluate + "'And isComplete='" + 1 + "'And isSubmit='" + 1 + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<List<FoodList>>.Return(0, "查询成功", dataSet);
                }
                else
                {
                    return ApiResultBuilder<FoodList>.Return(-1, "查无数据", dataSet);
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<FoodList>.Return(-2, "数据异常" + e.Message);
            }
        }
        /// <summary>
        /// 提交评价
        /// </summary>
        /// <param name="username"></param>
        /// <param name="orderid"></param>
        /// <param name="pingjia"></param>
        /// <param name="pingfen"></param>
        /// <param name="imagelist"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("PostPingjia")]
        public JsonResult PostPingjia(string username, string orderid,string pingjia,string pingfen,string imagelist)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                var TimeStamps = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
                string sql = "UPDATE [demo].[dbo].[order] SET pingjia='" + pingjia + "',pingfen='" + pingfen + "',pingjiadate='"+ TimeStamps + "',isEvaluate='" + 1+ "',pinjiaimage='" + imagelist + "'where orderid='" + orderid + "'And username = '"+username+"'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                    return ApiResultBuilder<List<FoodList>>.Return(0, "更新成功", dataSet);
            }
            catch (Exception e)
            {
                return ApiResultBuilder<FoodList>.Return(-2, "数据异常" + e.Message);
            }
        }

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("DeleteOrder")]
        public JsonResult DeleteOrder(string orderid)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "Delete [demo].[dbo].[order] where orderid='" + orderid + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                return ApiResultBuilder<List<FoodList>>.Return(0, "删除成功", dataSet);
            }
            catch (Exception e)
            {
                return ApiResultBuilder<FoodList>.Return(-2, "数据异常" + e.Message);
            }
        }
    }
}