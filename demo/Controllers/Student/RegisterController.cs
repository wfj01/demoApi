using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using demo.Models.DemoEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using demo.Models.Common;
using Newtonsoft.Json;

namespace demo.Api.Controllers
{
    /// <summary>
    /// 注册验证接口
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        /// <summary>
        /// 生成随机数的种子
        /// </summary>
        /// <returns></returns>
        private static int getNewSeed()
        {
            byte[] rndBytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(rndBytes);
            return BitConverter.ToInt32(rndBytes, 0);
        }     /// <summary>
              /// 生成8位随机数
              /// </summary>
              /// <param name="len"></param>
              /// <returns></returns>
        static public string GetRandomString(int len)
        {
            string s = "123456789abcdefghijklmnpqrstuvwxyzABCDEFGHIJKLMNPQRSTUVWXYZ";
            string reValue = string.Empty;
            Random rnd = new Random(getNewSeed());
            while (reValue.Length < len)
            {
                string s1 = s[rnd.Next(0, s.Length)].ToString();
                if (reValue.IndexOf(s1) == -1) reValue += s1;
            }
            return reValue;
        }
        /// <summary>
        /// 查询账号是否重复
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetIsUser")]
        public JsonResult GetIsUser(string username)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                string sql1 = "SELECT * FROM [demo].[dbo].[user] WHERE username='" + username + "'";
                SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sql1, sqlConnection);
                DataSet dataSet1 = new DataSet();
                sqlDataAdapter1.Fill(dataSet1);
                if ((dataSet1 != null && dataSet1.Tables.Count > 0 && dataSet1.Tables[0].Rows.Count > 0) == true)
                {
                    return ApiResultBuilder<List<Login>>.Return(-1, "账号已存在");
                }
                return ApiResultBuilder<List<Login>>.Return(0, "账号可以注册");
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Login>.Return(-2, "数据异常" + e.Message);
            }
        }

        /// <summary>
        /// 向数据库中添加数据
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("postUser")]
        public JsonResult PostUser([FromForm]Register register)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                string sql1 = "SELECT * FROM [demo].[dbo].[user] WHERE username='" + register.UserName + "'";
                SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sql1, sqlConnection);
                DataSet dataSet1 = new DataSet();
                sqlDataAdapter1.Fill(dataSet1);
                if ((dataSet1 != null && dataSet1.Tables.Count > 0 && dataSet1.Tables[0].Rows.Count > 0) == true)
                {
                    return ApiResultBuilder<List<Login>>.Return(-1, "账号已存在");
                }
                var token = GetRandomString(13);
                var TimeStamps = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
                string sql = "INSERT INTO [demo].[dbo].[user] " +
                    "(username, name,password,telephone,email,sex,portrait,birtherdate,updatetime,token) VALUES('" + register.UserName + "','" + register.Name + "'," +
                    "'" + register.Password + "','" + register.Telephone + "','" + register.Email + "'," + register.Sex + ",'" + register.Portrait + "'," +
                    "'" + register.Birtherdate+"','"+ TimeStamps + "','" + token + "') ";
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);
                return ApiResultBuilder<List<Login>>.Return(0, "注册成功");
                //return JsonConvert.SerializeObject(dataSet);
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Login>.Return(-2, "数据异常" + e.Message);
            }
        }
    }
}