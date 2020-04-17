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
    /// 第一餐厅-控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FirstroomController : ControllerBase
    {
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
                    return ApiResultBuilder<List<Firstroom>>.Return(dataSet);
                }
                else
                {
                    return new JsonResult("查无数据");
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Firstroom>.Return(-2, "数据异常" + e.Message);
            }
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("SearchBtn")]
        public JsonResult SearchBtn(string names, string question1, string question2)
        {
            if (names == null)
            {
                names = "";
            }
            if (question1 == null)
            {
                question1 = "";
            }
            if (question2 == null)
            {
                question2 = "";
            }
            try
            {
                SqlConnection sqlConnection = new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                if (names == "" && question1 == "" && question2 == "")
                {
                    string sql = "SELECT * FROM [demo].[dbo].[firstroom]";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<User>>.Return(dataSet);
                    }
                    else
                    {
                        return new JsonResult("查无数据");
                    }
                }
                else if (names != "" && question1 == "" && question2 == "")
                {
                    string sql1 = "SELECT * FROM [demo].[dbo].[firstroom] where names like'" + names + "%'";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql1, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<User>>.Return(dataSet);
                    }
                    else
                    {
                        return new JsonResult("查无数据");
                    }
                }
                else if (names == "" && question1 != "" && question2 != "")
                {
                    string sql2 = "SELECT * FROM [demo].[dbo].[firstroom] WHERE question between'" + question1 + "'and'" + question2 + "'";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql2, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<User>>.Return(dataSet);
                    }
                    else
                    {
                        return new JsonResult("查无数据");
                    }
                }
                else if (names != "" && question1 != "" && question2 == "")
                {

                    string sql3 = "SELECT * FROM [demo].[dbo].[firstroom]  where names like'" + names + "%' and question ='" + question1 + "'";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql3, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<User>>.Return(dataSet);
                    }
                    else
                    {
                        return new JsonResult("查无数据");
                    }
                }
                else if (names != "" && question1 == "" && question2 != "")
                {

                    string sql4 = "SELECT * FROM [demo].[dbo].[firstroom]  where names like'" + names + "%' and question ='" + question2 + "'";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql4, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<User>>.Return(dataSet);
                    }
                    else
                    {
                        return new JsonResult("查无数据");
                    }
                }
                else if (names == "" && question1 == "" && question2 != "")
                {
                    string sql5 = "SELECT * FROM [demo].[dbo].[firstroom]  where  question ='" + question2 + "'";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql5, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<User>>.Return(dataSet);
                    }
                    else
                    {
                        return new JsonResult("查无数据");
                    }
                }
                else if (names == "" && question1 != "" && question2 == "")
                {
                    string sql6 = "SELECT * FROM [demo].[dbo].[firstroom]  where  question ='" + question1 + "'";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql6, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<User>>.Return(dataSet);
                    }
                    else
                    {
                        return new JsonResult("查无数据");
                    }
                }
                else
                {

                    string sql7 = "SELECT * FROM [demo].[dbo].[firstroom] where names like'" + names + "%' and question between '" + question1 + "'and'" + question2 + "'";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql7, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<User>>.Return(dataSet);
                    }
                    else
                    {
                        return new JsonResult("查无数据");
                    }
                }

            }
            catch (Exception e)
            {
                return ApiResultBuilder<User>.Return(-2, "数据异常" + e.Message);
            }
        }
    }
}