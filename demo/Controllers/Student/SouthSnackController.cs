using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using demo.Models.Common;
using demo.Models.DemoEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.Api.Controllers
{
    /// <summary>
    /// 南门饭店
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SouthSnackController : ControllerBase
    {
        /// <summary>
        /// 南门饭店-查询
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
                string sql = "SELECT * FROM [demo].[dbo].[southsnack]";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<List<SouthSnack>>.Return(dataSet);
                }
                else
                {
                    return new JsonResult("查无数据");
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<SouthSnack>.Return(-2, "数据异常" + e.Message);
            }

        }
        /// <summary>
        /// 查询数据
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
                    string sql = "SELECT * FROM [demo].[dbo].[southsnack]";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<SouthSnack>>.Return(dataSet);
                    }
                    else
                    {
                        return new JsonResult("查无数据");
                    }
                }
                else if (dishname != "" && price1 == "" && price2 == "")
                {
                    string sql1 = "SELECT * FROM [demo].[dbo].[southsnack] where dishname like'" + dishname + "%'";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql1, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<SouthSnack>>.Return(dataSet);
                    }
                    else
                    {
                        return new JsonResult("查无数据");
                    }
                }
                else if (dishname == "" && price1 != "" && price2 != "")
                {
                    string sql2 = "SELECT * FROM [demo].[dbo].[southsnack] WHERE price between'" + price1 + "'and'" + price2 + "'";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql2, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<SouthSnack>>.Return(dataSet);
                    }
                    else
                    {
                        return new JsonResult("查无数据");
                    }
                }
                else if (dishname != "" && price1 != "" && price2 == "")
                {

                    string sql3 = "SELECT * FROM [demo].[dbo].[southsnack]  where dishname like'" + dishname + "%' and price ='" + price1 + "'";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql3, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<SouthSnack>>.Return(dataSet);
                    }
                    else
                    {
                        return new JsonResult("查无数据");
                    }
                }
                else if (dishname != "" && price1 == "" && price2 != "")
                {

                    string sql4 = "SELECT * FROM [demo].[dbo].[southsnack]  where dishname like'" + dishname + "%' and price ='" + price2 + "'";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql4, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<SouthSnack>>.Return(dataSet);
                    }
                    else
                    {
                        return new JsonResult("查无数据");
                    }
                }
                else if (dishname == "" && price1 == "" && price2 != "")
                {
                    string sql5 = "SELECT * FROM [demo].[dbo].[southsnack]  where  price ='" + price2 + "'";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql5, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<SouthSnack>>.Return(dataSet);
                    }
                    else
                    {
                        return new JsonResult("查无数据");
                    }
                }
                else if (dishname == "" && price1 != "" && price2 == "")
                {
                    string sql6 = "SELECT * FROM [demo].[dbo].[southsnack]  where  price ='" + price1 + "'";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql6, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<SouthSnack>>.Return(dataSet);
                    }
                    else
                    {
                        return new JsonResult("查无数据");
                    }
                }
                else
                {

                    string sql7 = "SELECT * FROM [demo].[dbo].[southsnack] where dishname like'" + dishname + "%' and price between '" + price1 + "'and'" + price2 + "'";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql7, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        return ApiResultBuilder<List<SouthSnack>>.Return(dataSet);
                    }
                    else
                    {
                        return new JsonResult("查无数据");
                    }
                }

            }
            catch (Exception e)
            {
                return ApiResultBuilder<SouthSnack>.Return(-2, "数据异常" + e.Message);
            }
        }

        /// <summary>
        /// 向订单表中添加数据
        /// </summary>
        /// <param name="southSnacks"></param>
        /// <param name="studentid"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("postUser")]
        public JsonResult PostUser([FromBody]List<SouthSnack> southSnacks, string studentid)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                foreach (var item in southSnacks)
                {
                    string sql = "INSERT INTO [demo].[dbo].[order](studentid,dishname,price,score,time,practice,windows,remarks,number,isSubmit,isConfirm,isComplete,updatetime) VALUES('" + studentid + "','" + item.Dishname + "','" + item.Price + "','" + item.Score + "','" + item.Time + "','" + item.Practice + "','" + item.Windows + "','" + item.Remarks + "','" + item.Number + "','" + false + "','" + false + "','" + false + "','" + DateTime.Now.ToString() + "') ";
                    DataSet dataSet = new DataSet();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                    sqlDataAdapter.Fill(dataSet);
                }
                return ApiResultBuilder<SouthSnack>.Return(0, "保存成功");
            }
            catch (Exception e)
            {
                return ApiResultBuilder<SouthSnack>.Return(-2, "数据异常" + e.Message);
            }
        }
    }
}