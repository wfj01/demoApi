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
    public class OrderController : ControllerBase
    {
        /// <summary>
        /// 购物车-加载表格数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("queryUser")]
        public JsonResult QueryUser(string studentid)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "SELECT * FROM [demo].[dbo].[order] where studentid='" + studentid + "'and isSubmit= 'false'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<List<Order>>.Return(dataSet);
                }
                else
                {
                    return new JsonResult("查无数据");
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Order>.Return(-2, "数据异常" + e.Message);
            }
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("updatanumber")]
        public JsonResult UpdataNumber([FromBody]Order orders)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                string sql =
                    "UPDATE [demo].[dbo].[order] SET dishname='" + orders.Dishname
                    + "',price='" + orders.Price + "',score='" + orders.Score
                    + "',time='" + orders.Time + "',windows='" + orders.Windows + "',remarks='" + orders.Remarks
                    + "',number='" + orders.Number + "'where id=" + orders.Id + "";
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);
                return ApiResultBuilder<Order>.Return(0, "更新成功");
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Order>.Return(-2, "数据异常" + e.Message);
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("deleteorder")]
        public JsonResult DeleteOrder(int id)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                string sql1 = "Select * FROM [demo].[dbo].[Order] WHERE id=" + id;
                SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sql1, sqlConnection);
                DataSet dataSet1 = new DataSet();
                sqlDataAdapter1.Fill(dataSet1);
                if ((dataSet1 != null && dataSet1.Tables.Count > 0 && dataSet1.Tables[0].Rows.Count > 0) == false)
                {
                    return ApiResultBuilder<Order>.Return(-1, "id不存在");
                }
                string sql = "DELETE FROM [demo].[dbo].[Order] WHERE id=" + id;
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);
                return ApiResultBuilder<Order>.Return(0, "删除成功");
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Order>.Return(-2, "数据异常" + e.Message);
            }
        }

        /// <summary>
        /// 提交订单
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="studentid"></param>
        /// <param name="StudentName"></param>
        /// <param name="StudentAddress"></param>
        /// <param name="StudentPhone"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("confirmorder")]
        public JsonResult Confirmorder([FromBody]List<Order> orders, string studentid,string StudentName,string StudentAddress,string StudentPhone)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                foreach (var item in orders)
                {
                    string sql = "INSERT INTO [demo].[dbo].[order] VALUES('" + studentid + "','" + StudentName + "','" + StudentAddress + "','" + StudentPhone + "','" + item.Dishname + "','" + item.Price + "','" + item.Score + "','" + item.Time + "','" + item.Practice + "','" + item.Windows + "','" + item.Remarks + "','" + item.Number + "','" + true + "','"+item.IsConfirm+"','"+item.IsComplete+"','"+item.UpdateTime+"') ";
                    DataSet dataSet = new DataSet();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                    sqlDataAdapter.Fill(dataSet);
                }
                return ApiResultBuilder<Order>.Return(0, "提交成功");
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Order>.Return(-2, "数据异常" + e.Message);
            }
        }
    }
}