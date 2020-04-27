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
        [HttpGet]
        [Route("loaddata")]
        public JsonResult Loaddata()
        {
            try
            {
                SqlConnection sqlConnection =
                new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "SELECT * FROM shopping";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<List<Business>>.Return(dataSet);
                }
                else
                {
                    return ApiResultBuilder<Business>.Return(-1, "查无数据");
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Business>.Return(-2, "数据异常" + e.Message);
            }
        }

        [HttpPost]
        [Route("adddate")]
        public JsonResult Adddate([FromBody] Business business)
        {
            try
            {
                SqlConnection sqlConnection =
                new SqlConnection(
                 "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                string sql = "INSERT INTO [demo].[dbo].[shopping] VALUES(" + business.id + ",'" + business.dishname + "','" + business.price + "','" + business.practice + "','" + business.time + "','" + business.windows + "','" + business.remarks + "') ";
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);
                return ApiResultBuilder<Business>.Return(0, "插入成功");

            }
            catch (Exception e)
            {
                return ApiResultBuilder<Business>.Return(-2, "数据异常" + e.Message);
            }
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="business"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("updatedate")]
        public JsonResult UpdateDate([FromBody] Business business)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                string sql =
                    "UPDATE [demo].[dbo].[shopping" +
                    "] SET dishname='" + business.dishname
                    + "',price='" + business.price + "',practice='" + business.practice
                    + "',time='" + business.time + "',windows='" + business.windows + "',remarks='" + business.remarks + "";
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);
                return ApiResultBuilder<Business>.Return(0, "更新成功");
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Business>.Return(-2, "数据异常" + e.Message);
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
                string sql1 = "Select * FROM [demo].[dbo].[shopping] WHERE id=" + id;
                SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sql1, sqlConnection);
                DataSet dataSet1 = new DataSet();
                sqlDataAdapter1.Fill(dataSet1);
                if ((dataSet1 != null && dataSet1.Tables.Count > 0 && dataSet1.Tables[0].Rows.Count > 0) == false)
                {
                    return ApiResultBuilder<Business>.Return(-1, "id不存在");
                }
                string sql = "DELETE FROM [demo].[dbo].[shopping] WHERE id=" + id;
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);
                return ApiResultBuilder<Business>.Return(0, "删除成功");
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Business>.Return(-2, "数据异常" + e.Message);
            }
        }
    }
}