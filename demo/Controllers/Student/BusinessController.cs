using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using demo.Models.Common;
using demo.Models.DemoEntities.Student;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.Api.Controllers.Student
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        /// <summary>
        /// 加载数据
        /// </summary>
        [HttpGet]
        [Route("loaddata")]
        public JsonResult Loaddata()
        {
            try
            {
                SqlConnection sqlConnection =
                new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "SELECT * FROM [demo].[dbo].[shangpin]";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<List<Businessview>>.Return(dataSet);
                }
                else
                {
                    return ApiResultBuilder<Businessview>.Return(-1, "查无数据");
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Businessview>.Return(-2, "数据异常" + e.Message);
            }
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        [HttpPost]
        [Route("adddate")]
        public JsonResult Adddate([FromBody] Businessview business,string valueText)
        {
            try
            {
                SqlConnection sqlConnection =
                new SqlConnection(
                 "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                
                if (valueText == "第一餐厅一窗口")
                {
                    string sql1 = "INSERT INTO [demo].[dbo].[firstroom](dishname,price,score,time,remarks,windows,practice,number) VALUES('" + business.dishname + "','" + business.price + "','" + business.score + "','" + business.time + "','" + business.remarks + "','" + valueText + "','" + business.practice + "','" + 1 + "') ";
                    DataSet dataSet1 = new DataSet();
                    SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sql1, sqlConnection);
                    sqlDataAdapter1.Fill(dataSet1);
                    return ApiResultBuilder<Businessview>.Return(0, "插入成功",dataSet1);
                }
                else if (valueText == "第二餐厅一窗口")
                {
                    string sql1 = "INSERT INTO [demo].[dbo].[secondroom](dishname,price,score,time,remarks,windows,practice,number) VALUES('" + business.dishname + "','" + business.price + "','" + business.score + "','" + business.time + "','" + business.remarks + "','" + valueText + "','" + business.practice + "','" + 1 + "') ";
                    DataSet dataSet1 = new DataSet();
                    SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sql1, sqlConnection);
                    sqlDataAdapter1.Fill(dataSet1);
                    return ApiResultBuilder<Businessview>.Return(0, "插入成功", dataSet1);
                }
                else if (valueText == "南门饭店")
                {
                    string sql1 = "INSERT INTO [demo].[dbo].[southsnack](dishname,price,score,time,remarks,windows,practice,number) VALUES('" + business.dishname + "','" + business.price + "','" + business.score + "','" + business.time + "','" + business.remarks + "','" + valueText + "','" + business.practice + "','" + 1 + "') ";
                    DataSet dataSet1 = new DataSet();
                    SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sql1, sqlConnection);
                    sqlDataAdapter1.Fill(dataSet1);
                    return ApiResultBuilder<Businessview>.Return(0, "插入成功", dataSet1);
                }
                else if (valueText == "大学城")
                {
                    string sql1 = "INSERT INTO [demo].[dbo].[collegetown](dishname,price,score,time,remarks,windows,practice,number) VALUES('" + business.dishname + "','" + business.price + "','" + business.score + "','" + business.time + "','" + business.remarks + "','" + valueText + "','" + business.practice + "','" + 1 + "') ";
                    DataSet dataSet1 = new DataSet();
                    SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sql1, sqlConnection);
                    sqlDataAdapter1.Fill(dataSet1);
                    return ApiResultBuilder<Businessview>.Return(0, "插入成功", dataSet1);
                }
                else {
                    string sql = "INSERT INTO [demo].[dbo].[shangpin](dishname,price,score,time,remarks,windows,practice,number) VALUES('" + business.dishname + "','" + business.price + "','" + business.score + "','" + business.time + "','" + business.remarks + "','" + valueText + "','" + business.practice + "','" + 1 + "') ";
                    DataSet dataSet = new DataSet();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                    sqlDataAdapter.Fill(dataSet);
                    return ApiResultBuilder<Businessview>.Return(0, "插入成功",dataSet);
                }

            }
            catch (Exception e)
            {
                return ApiResultBuilder<Businessview>.Return(-2, "数据异常" + e.Message);
            }
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="business"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("updatedate")]
        public JsonResult UpdateDate([FromBody] Businessview business)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                string sql =
                    "UPDATE [demo].[dbo].[shangpin" +
                    "] SET dishname='" + business.dishname
                    + "',price='" + business.price + "',practice='" + business.practice
                    + "',time='" + business.time + "',windows='" + business.windows + "',remarks='" + business.remarks + "";
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);
                return ApiResultBuilder<Businessview>.Return(0, "更新成功");
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Businessview>.Return(-2, "数据异常" + e.Message);
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("deletedate")]
        public JsonResult DeleteDate(int id)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                string sql1 = "Select * FROM [demo].[dbo].[shangpin] WHERE id=" + id;
                SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sql1, sqlConnection);
                DataSet dataSet1 = new DataSet();
                sqlDataAdapter1.Fill(dataSet1);
                if ((dataSet1 != null && dataSet1.Tables.Count > 0 && dataSet1.Tables[0].Rows.Count > 0) == false)
                {
                    return ApiResultBuilder<Businessview>.Return(-1, "id不存在");
                }
                string sql = "DELETE FROM [demo].[dbo].[shangpin] WHERE id=" + id;
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);
                return ApiResultBuilder<Businessview>.Return(0, "删除成功");
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Businessview>.Return(-2, "数据异常" + e.Message);
            }
        }
    }
}