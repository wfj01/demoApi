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

namespace demo.Api.Controllers.Student
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyMessageController : ControllerBase
    {
        #region 第一餐厅-加载表格数据
        /// <summary>
        /// 第一餐厅-加载表格数据
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
                string sql = "SELECT * FROM [demo].[dbo].[student] where studentid="+studentid;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<List<Register>>.Return(0,"查询成功",dataSet);
                }
                else
                {
                    return ApiResultBuilder<Register>.Return(-1, "查无数据");
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Register>.Return(-2, "数据异常" + e.Message);
            }
        }
        #endregion

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="Studentid"></param>
        /// <param name="Password"></param>
        /// <param name="Telephone"></param>
        /// <param name="Address"></param>
        /// <param name="Email"></param>
        /// <param name="Studentname"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("saveUpdata")]
        public JsonResult SaveUpdata([FromQuery]string Studentid, string Password,string Telephone,string Address,string Email,string Studentname)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                string sql1 = "SELECT * FROM [demo].[dbo].[Student] where studentid='" + Studentid + "'";
                SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sql1, sqlConnection);
                DataSet dataSet1 = new DataSet();
                sqlDataAdapter1.Fill(dataSet1);
                if ((dataSet1 != null && dataSet1.Tables.Count > 0 && dataSet1.Tables[0].Rows.Count > 0) == false)
                {
                    return ApiResultBuilder<List<Login>>.Return(-1, "账号不存在");
                }
                string sq2 = "UPDATE [demo].[dbo].[Student] SET password='" + Password + "',phone='"+Telephone+ "',address='"+Address+ "',email='"+Email+ "',name='"+Studentname+"' WHERE studentid='" + Studentid + "'";
                DataSet dataSet2 = new DataSet();
                SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sq2, sqlConnection);
                sqlDataAdapter2.Fill(dataSet2);
                return ApiResultBuilder<Login>.Return(0, "修改成功");
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Login>.Return(-2, "数据异常" + e.Message);
            }
        }
    }
}