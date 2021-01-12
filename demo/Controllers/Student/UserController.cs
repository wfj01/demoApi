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

namespace demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("queryUser")]
        public JsonResult QueryUser( string username)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "SELECT * FROM [demo].[dbo].[user] where username = '"+username+"'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null&&dataSet.Tables.Count>0&&dataSet.Tables[0].Rows.Count>0)
                {
                   
                    return ApiResultBuilder<User>.Return(0,"查询成功",dataSet);
                }
                else
                {
                    return ApiResultBuilder<User>.Return(-1, "查无数据", dataSet);
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<User>.Return(-2, "数据异常" + e.Message);
            }

        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("updateUser")]
        public JsonResult UpdateUser([FromForm]User users)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                var TimeStamps = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
                string sql = "UPDATE [demo].[dbo].[user](username,name，password,telephone,email,sex,portrait,birtherdate,updatetime) " +
                    "VALUES('" + users.Username + "','" + users.Name + "'," +
                    "'" + users.Password + "','" + users.Telephone + "','" + users.Email + "'," + users.Sex + ",'" + users.Portrait + "'," +
                    "'" + users.Birtherdate + "','" + TimeStamps + "') where username= '"+users.Username+"'";
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);
                return ApiResultBuilder<User>.Return(0, "更新成功", dataSet);
            }
            catch (Exception e)
            {
                return ApiResultBuilder<User>.Return(-2, "数据异常" + e.Message);
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("deleteUser")]
        public string DeleteUser(int id)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                string sql1 = "SELECT * FROM [demo].[dbo].[User] WHERE id=" + id;
                SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sql1, sqlConnection);
                DataSet dataSet1 = new DataSet();
                sqlDataAdapter1.Fill(dataSet1);
                if ((dataSet1 != null && dataSet1.Tables.Count > 0 && dataSet1.Tables[0].Rows.Count > 0) == false)
                {
                    return ("id不存在");
                }
                string sql = "DELETE FROM [demo].[dbo].[User] WHERE id="+id;
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);
                return ("删除成功");
                //return JsonConvert.SerializeObject(dataSet);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}