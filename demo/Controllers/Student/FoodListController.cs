using System;
using demo.Models.DemoEntities;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using demo.Models.Common;

namespace demo.Api.Controllers
{
    /// <summary>
    /// 第一餐厅控制器
    /// </summary>

    /// <summary>
    /// 这是一个api方法的注释
    /// </summary>
    /// <returns></returns>
    [Route("api/[controller]")]
    [ApiController]
    public class FoodListController : ControllerBase
    {

        #region 加载菜单数据
        /// <summary>
        /// 加载菜单数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("QueryfoodList")]
        public JsonResult QueryfoodList(string windowid)
        {
            try
            {

                if (windowid == null)
                {
                    windowid = "";
                    SqlConnection sqlConnection =
                   new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                    sqlConnection.Open();
                    string sql = "SELECT * FROM [demo].[dbo].[foodList]";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<FoodList>>.Return(0, "查询成功", dataSet);
                    }
                    else
                    {
                        return ApiResultBuilder<List<FoodList>>.Return(-1, "查无数据", dataSet);
                    }
                }
                else
                {
                    SqlConnection sqlConnection =
                    new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                    sqlConnection.Open();
                    string sql = "SELECT * FROM [demo].[dbo].[foodList]where wid = '" + windowid + "'";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<FoodList>>.Return(0, "查询成功", dataSet);
                    }
                    else
                    {
                        return ApiResultBuilder<List<FoodList>>.Return(-1, "查无数据", dataSet);
                    }
                }

            }
            catch (Exception e)
            {
                return ApiResultBuilder<FoodList>.Return(-2, "数据异常" + e.Message);
            }
        }
        #endregion

        #region 加载菜单数据
        /// <summary>
        /// 筛选数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ShaiXuanfoodList")]
        public JsonResult ShaiXuanfoodList(string windows)
        {
            try
            {

                if (windows == null)
                {
                    windows = "";
                    SqlConnection sqlConnection =
                   new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                    sqlConnection.Open();
                    string sql = "SELECT * FROM [demo].[dbo].[foodList]";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<FoodList>>.Return(0, "查询成功", dataSet);
                    }
                    else
                    {
                        return ApiResultBuilder<List<FoodList>>.Return(-1, "查无数据", dataSet);
                    }
                }
                else
                {
                    SqlConnection sqlConnection =
                    new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                    sqlConnection.Open();
                    string sql = "SELECT * FROM [demo].[dbo].[foodList]where windows = '" + windows + "'";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<FoodList>>.Return(0, "查询成功", dataSet);
                    }
                    else
                    {
                        return ApiResultBuilder<List<FoodList>>.Return(-1, "查无数据", dataSet);
                    }
                }

            }
            catch (Exception e)
            {
                return ApiResultBuilder<FoodList>.Return(-2, "数据异常" + e.Message);
            }
        }
        #endregion

        /// <summary>
        /// 新增一条数据
        /// </summary>
        /// <param name="foodList"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PostFoodText")]
        public JsonResult PostFoodText([FromBody]FoodList foodList)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                var TimeStamps = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;

                string sql = "INSERT INTO [demo].[dbo].[foodList](wid,dishname,price,score,time,remarks,windows,number,imagesrc,updatetime) VALUES" +
                    "('" + foodList.WId + "','" + foodList.Dishname + "','" + foodList.Price + "','" + foodList.Score + "','" + foodList.Time + "','" + foodList.Remarks + "','" + foodList.Windows + "','" + foodList.Number + "','" + foodList.ImageSrc + "','" + TimeStamps + "') ";
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);
                return new JsonResult(new { rtnCode = 0, resultMsg = "保存成功", data = TimeStamps });
            }
            catch (Exception e)
            {
                return ApiResultBuilder<FoodList>.Return(-2, "数据异常" + e.Message);
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="foodList"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpDataNoticeText")]
        public JsonResult UpDataNoticeText([FromBody]FoodList foodList)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                var TimeStamps = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
                string sql = "UPDATE [demo].[dbo].[foodList] set wid = '" + foodList.WId+ "',dishname='"+ foodList.Dishname+ "',price='"+foodList.Price+"',score='"+foodList.Score+"',time='"+foodList.Time+"',remarks='"+foodList.Remarks+"',windows='"+foodList.Windows+"',number='"+foodList.Number+"',imagesrc='"+foodList.ImageSrc+"',updatetime='"+TimeStamps+"'where id='"+foodList.Id+"'";
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);
                return new JsonResult(new { rtnCode = 0, resultMsg = "更新成功" });
            }
            catch (Exception e)
            {
                return ApiResultBuilder<FoodList>.Return(-2, "数据异常" + e.Message);
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("PostRemoveList")]
        public JsonResult PostRemoveList(string id) {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                string sql = "DELETE FROM  [demo].[dbo].[foodList] where id ='" + id + "'";
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);
                return new JsonResult(new { rtnCode = 0, resultMsg = "删除成功"});
            }
            catch (Exception e)
            {
                return ApiResultBuilder<FoodList>.Return(-2, "数据异常" + e.Message);
            }
        }


        #region 第一餐厅-查询数据
        /// <summary>
        /// 第一餐厅-查询数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("SearchBtn")]
        public JsonResult SearchBtn(string dishname, string price1, string price2)
        {
            if (dishname == null)
            {
                dishname = "";
            }
            if (price1 == null)
            {
                price1 = "";
            }
            if (price2 == null)
            {
                price2 = "";
            }
            try
            {
                SqlConnection sqlConnection = new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                if (dishname == "" && price1 == "" && price2 == "")
                {
                    string sql = "SELECT * FROM [demo].[dbo].[firstroom]";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<FoodList>>.Return(0, "查询成功", dataSet);
                    }
                    else
                    {
                        return ApiResultBuilder<List<FoodList>>.Return(-1, "查无数据", dataSet);
                    }
                }
                else if (dishname != "" && price1 == "" && price2 == "")
                {
                    string sql1 = "SELECT * FROM [demo].[dbo].[firstroom] where dishname like'" + dishname + "%'";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql1, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<FoodList>>.Return(0, "查询成功", dataSet);
                    }
                    else
                    {
                        return ApiResultBuilder<List<FoodList>>.Return(-1, "查无数据", dataSet);
                    }
                }
                else if (dishname == "" && price1 != "" && price2 != "")
                {
                    string sql2 = "SELECT * FROM [demo].[dbo].[firstroom] WHERE price between  " + int.Parse(price1) + "  and " + int.Parse(price2) + "";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql2, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<FoodList>>.Return(0, "查询成功", dataSet);
                    }
                    else
                    {
                        return ApiResultBuilder<List<FoodList>>.Return(-1, "查无数据", dataSet);
                    }
                }
                else if (dishname != "" && price1 != "" && price2 == "")
                {

                    string sql3 = "SELECT * FROM [demo].[dbo].[firstroom]  where dishname like'" + dishname + "%' and price =" + int.Parse(price1) + "";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql3, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<FoodList>>.Return(0, "查询成功", dataSet);
                    }
                    else
                    {
                        return ApiResultBuilder<List<FoodList>>.Return(-1, "查无数据", dataSet);
                    }
                }
                else if (dishname != "" && price1 == "" && price2 != "")
                {

                    string sql4 = "SELECT * FROM [demo].[dbo].[firstroom]  where dishname like'" + dishname + "%'  and  price =" + int.Parse(price2) + "";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql4, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<FoodList>>.Return(0, "查询成功", dataSet);
                    }
                    else
                    {
                        return ApiResultBuilder<List<FoodList>>.Return(-1, "查无数据", dataSet);
                    }
                }
                else if (dishname == "" && price1 == "" && price2 != "")
                {
                    string sql5 = "SELECT * FROM [demo].[dbo].[firstroom]  where  price  =" + int.Parse(price2) + "";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql5, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<FoodList>>.Return(0, "查询成功", dataSet);
                    }
                    else
                    {
                        return ApiResultBuilder<List<FoodList>>.Return(-1, "查无数据", dataSet);
                    }
                }
                else if (dishname == "" && price1 != "" && price2 == "")
                {
                    string sql6 = "SELECT * FROM [demo].[dbo].[firstroom]  where  price =" + int.Parse(price1) + "";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql6, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<FoodList>>.Return(0, "查询成功", dataSet);
                    }
                    else
                    {
                        return ApiResultBuilder<List<FoodList>>.Return(-1, "查无数据", dataSet);
                    }
                }
                else
                {

                    string sql7 = "SELECT * FROM [demo].[dbo].[firstroom] where dishname like'" + dishname + "%' and price between  " + int.Parse(price1) + " and " + int.Parse(price2) + "";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql7, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<FoodList>>.Return(0, "查询成功", dataSet);
                    }
                    else
                    {
                        return ApiResultBuilder<List<FoodList>>.Return(-1, "查无数据", dataSet);
                    }
                }

            }
            catch (Exception e)
            {
                return ApiResultBuilder<FoodList>.Return(-2, "数据异常" + e.Message);
            }
        }
        #endregion


    }
}