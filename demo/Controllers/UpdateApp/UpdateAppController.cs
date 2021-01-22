using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using demo.Models;
using demo.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.Api.Controllers.UpdateApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateAppController : ControllerBase
    {
        /// <summary>
        /// 更新APP
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUnloadApp")]
        public JsonResult GetUnloadApp(string appid,string version,string versionnum)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "select max(versionnum) from [dbo].updateApp";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    string aa =  dataSet.Tables[0].Rows[0][0].ToString();
                    if (Convert.ToInt32(aa) > Convert.ToInt32(versionnum))
                    {
                        string sql2 = "SELECT * FROM [dbo].updateApp WHERE version='" + aa + "';";
                        SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sql2, sqlConnection);
                        DataSet dataSet2 = new DataSet();
                        sqlDataAdapter2.Fill(dataSet2);
                        return ApiResultBuilder<List<Updateapp>>.Return(0, "查询成功", dataSet2);
                    }
                    return ApiResultBuilder<List<Updateapp>>.Return(-1, "无需升级");
                }
                else
                {
                    return ApiResultBuilder<List<Updateapp>>.Return(-1, "查无数据", dataSet);
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Updateapp>.Return(-2, "数据异常" + e.Message);
            }
        }
        string DataSetToString(DataSet dataSet)
        {
            string str = dataSet.GetXml();
            return str;
        }
    }
}