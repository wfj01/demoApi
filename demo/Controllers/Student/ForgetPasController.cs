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
    /// 修改密码控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ForgetPasController : ControllerBase
    {
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("updateForgetPass")]
        public JsonResult UpdateForgetPass([FromForm]User users)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                string sql1 = "SELECT * FROM [demo].[dbo].[user] where username='" + users.Username + "'";
                SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sql1, sqlConnection);
                DataSet dataSet1 = new DataSet();
                sqlDataAdapter1.Fill(dataSet1);
                string sql = "SELECT * FROM [demo].[dbo].[user] where username='" + users.Username + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if ((dataSet1 != null && dataSet1.Tables.Count > 0 && dataSet1.Tables[0].Rows.Count > 0) == false)
                {
                    return ApiResultBuilder<List<Login>>.Return(-1, "账号不存在");
                }
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    string sq2 = "UPDATE [demo].[dbo].[user] SET password='" + users.Password + "' WHERE username='" + users.Username + "'";
                    DataSet dataSet2 = new DataSet();
                    SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sq2, sqlConnection);
                    sqlDataAdapter2.Fill(dataSet2);
                    return ApiResultBuilder<Login>.Return(0, "修改成功");
                }
                else
                {
                    if ((dataSet1 != null && dataSet1.Tables.Count > 0 && dataSet1.Tables[0].Rows.Count > 0) == false)
                    {
                        return ApiResultBuilder<Firstroom>.Return(-1, "账号错误");
                    }
                    else
                    {
                        return ApiResultBuilder<Firstroom>.Return(-1, "用户姓名错误");
                    }
                }
                
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Login>.Return(-2, "数据异常" + e.Message);
            }
        }

    }
}