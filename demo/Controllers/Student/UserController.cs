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

namespace demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("queryUser")]
        public string QueryUser()
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "SELECT * FROM [demo].[dbo].[User]";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null&&dataSet.Tables.Count>0&&dataSet.Tables[0].Rows.Count>0)
                {
                   
                    return JsonConvert.SerializeObject(dataSet);
                }
                else
                {
                    return ("查无数据");
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }
        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getUser")]
        public string GetUser(int id,string password)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                string sql1 = "select * from [demo].[dbo].[User] where id = "+id;
                SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sql1, sqlConnection);
                DataSet dataSet1 = new DataSet();
                sqlDataAdapter1.Fill(dataSet1);
                string sql2 = "select * from [demo].[dbo].[User] where password ='"+password+"'";
                SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sql2, sqlConnection);
                DataSet dataSet2 = new DataSet();
                sqlDataAdapter2.Fill(dataSet2);
                if ((dataSet1 != null && dataSet1.Tables.Count > 0 && dataSet1.Tables[0].Rows.Count > 0) &&
                    (dataSet2 != null && dataSet2.Tables.Count > 0 && dataSet2.Tables[0].Rows.Count > 0))
                {
                    return JsonConvert.SerializeObject(dataSet1);
                }
                else
                {
                    if ((dataSet1 != null && dataSet1.Tables.Count > 0 && dataSet1.Tables[0].Rows.Count > 0)==false)
                    {
                        return ("id不正确");
                    }
                    else
                    {
                        return ("密码不正确");
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        ///// <summary>
        ///// 向数据库中添加数据
        ///// </summary>
        ///// <param name="users"></param>
        ///// <returns></returns>
        //[HttpPost]
        //[Route("postUser")]
        //public string PostUser(User users)
        //{
        //    try
        //    {
        //        SqlConnection sqlConnection =
        //         new SqlConnection(
        //          "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
        //        sqlConnection.Open();
        //        string sql1 = "SELECT * FROM [demo].[dbo].[User] WHERE id="+users.id;
        //        SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sql1, sqlConnection);
        //        DataSet dataSet1 = new DataSet();
        //        sqlDataAdapter1.Fill(dataSet1);
        //        if ((dataSet1 != null && dataSet1.Tables.Count > 0 && dataSet1.Tables[0].Rows.Count > 0) == true)
        //        {
        //            return("id已存在");
        //        }
        //        string sql = "INSERT INTO [demo].[dbo].[User] VALUES(" + users.id+",'"+users.NickName+"','"+users.Password+"','"+users.Phone+"','"+users.RegTime + "','"+users.MsgCode+"',"+users.State + ") ";
        //        DataSet dataSet = new DataSet();
        //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
        //        sqlDataAdapter.Fill(dataSet);
        //        return ("插入成功");
        //        //return JsonConvert.SerializeObject(dataSet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.ToString();
        //    }
        //}

        ///// <summary>
        ///// 更新数据
        ///// </summary>
        ///// <param name="users"></param>
        ///// <returns></returns>
        //[HttpPost]
        //[Route("updateUser")]
        //public string UpdateUser(User users)
        //{
        //    try
        //    {
        //        SqlConnection sqlConnection =
        //         new SqlConnection(
        //          "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
        //        sqlConnection.Open();
        //        string sql = "UPDATE [demo].[dbo].[User] SET phone=" + users.Phone + "nivkname=" + users.NickName;
        //        DataSet dataSet = new DataSet();
        //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
        //        sqlDataAdapter.Fill(dataSet);
        //        return JsonConvert.SerializeObject(dataSet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.ToString();
        //    }
        //}


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