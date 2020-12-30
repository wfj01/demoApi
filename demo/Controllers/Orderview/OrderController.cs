using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
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
                string sql = "SELECT * FROM [demo].[dbo].[order] where studentid='" + studentid + "'and isSubmit= '0'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<List<Firstroom>>.Return(0,"查询成功",dataSet);
                }
                else
                {
                    return ApiResultBuilder<Firstroom>.Return(-1, "查无数据",dataSet);
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Firstroom>.Return(-2, "数据异常" + e.Message);
            }
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("updatanumber")]
        public JsonResult UpdataNumber([FromBody]Firstroom orders)
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
                return ApiResultBuilder<Firstroom>.Return(0, "更新成功");
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Firstroom>.Return(-2, "数据异常" + e.Message);
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="updatetime"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("deleteorder")]
        public JsonResult DeleteOrder(string updatetime)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                string sql = "DELETE FROM [demo].[dbo].[order] WHERE updatetime=" + updatetime;
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);
                return ApiResultBuilder<Firstroom>.Return(0, "删除成功");
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Firstroom>.Return(-2, "数据异常" + e.Message);
            }
        }

        /// <summary>
        /// 提交订单
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="Studentid"></param>
        /// <param name="StudentName"></param>
        /// <param name="StudentAddress"></param>
        /// <param name="StudentPhone"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("confirmorder")]
        public JsonResult Confirmorder([FromBody]List<Firstroom> orders,string Studentid,string StudentName,string StudentAddress,string StudentPhone)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                foreach (var item in orders)
                {
                    string sql = "UPDATE [demo].[dbo].[order] SET studentname='"+StudentName+"',studentaddress='"+StudentAddress+"',phone='"+StudentPhone+"',isSubmit='"+true+"',updatetime='"+ DateTime.Now.ToString() + "'where studentid='"+Studentid+"'";
                    DataSet dataSet = new DataSet();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                    sqlDataAdapter.Fill(dataSet);
                }
                QueryUser(Studentid);
                return ApiResultBuilder<Firstroom>.Return(0, "提交成功");
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Firstroom>.Return(-2, "数据异常" + e.Message);
            }
        }

        [HttpGet]
        [Route("ordermanage")]
        public JsonResult Ordermanage(string studentid)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "SELECT * FROM [demo].[dbo].[order] where studentid='" + studentid + "'and isSubmit= 'true'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<List<Firstroom>>.Return(0, "查询成功", dataSet);
                }
                else
                {
                    return ApiResultBuilder<Firstroom>.Return(-1, "查无数据", dataSet);
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Firstroom>.Return(-2, "数据异常" + e.Message);
            }
        }
    }
}