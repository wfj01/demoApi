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
    public class FirstroomController : ControllerBase
    {

        #region 第一餐厅-加载表格数据
        /// <summary>
        /// 第一餐厅-加载表格数据
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
                string sql = "SELECT * FROM [demo].[dbo].[firstroom]";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<List<Firstroom>>.Return(0,"查询成功",dataSet);
                }
                else
                {
                    return ApiResultBuilder<List<Firstroom>>.Return(-1, "查无数据", dataSet);
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Firstroom>.Return(-2, "数据异常" + e.Message);
            }
        }
        #endregion

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
                        return ApiResultBuilder<List<Firstroom>>.Return(0,"查询成功",dataSet);
                    }
                    else
                    {
                        return ApiResultBuilder<List<Firstroom>>.Return(-1, "查无数据", dataSet);
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
                        return ApiResultBuilder<List<Firstroom>>.Return(0,"查询成功",dataSet);
                    }
                    else
                    {
                        return ApiResultBuilder<List<Firstroom>>.Return(-1, "查无数据", dataSet);
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
                        return ApiResultBuilder<List<Firstroom>>.Return(0,"查询成功",dataSet);
                    }
                    else
                    {
                        return ApiResultBuilder<List<Firstroom>>.Return(-1, "查无数据", dataSet);
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
                        return ApiResultBuilder<List<Firstroom>>.Return(0,"查询成功",dataSet);
                    }
                    else
                    {
                        return ApiResultBuilder<List<Firstroom>>.Return(-1, "查无数据", dataSet);
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
                        return ApiResultBuilder<List<Firstroom>>.Return(0,"查询成功",dataSet);
                    }
                    else
                    {
                        return ApiResultBuilder<List<Firstroom>>.Return(-1, "查无数据", dataSet);
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
                        return ApiResultBuilder<List<Firstroom>>.Return(0,"查询成功",dataSet);
                    }
                    else
                    {
                        return ApiResultBuilder<List<Firstroom>>.Return(-1, "查无数据", dataSet);
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
                        return ApiResultBuilder<List<Firstroom>>.Return(0,"查询成功",dataSet);
                    }
                    else
                    {
                        return ApiResultBuilder<List<Firstroom>>.Return(-1, "查无数据", dataSet);
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
                        return ApiResultBuilder<List<Firstroom>>.Return(0,"查询成功",dataSet);
                    }
                    else
                    {
                        return ApiResultBuilder<List<Firstroom>>.Return(-1, "查无数据", dataSet);
                    }
                }

            }
            catch (Exception e)
            {
                return ApiResultBuilder<Firstroom>.Return(-2, "数据异常" + e.Message);
            }
        }
        #endregion

        
    }
}