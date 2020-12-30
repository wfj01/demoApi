using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using demo.Models.Common;
using demo.Models.DemoEntities.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.Api.Controllers.Business
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessForgetController : ControllerBase
    {
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("updateForgetPass")]
        public JsonResult UpdateForgetPass([FromBody]BusinessLogin businessLogin)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                string sql1 = "SELECT * FROM [demo].[dbo].[businessMessage] where name='" + businessLogin.Name + "'";
                SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sql1, sqlConnection);
                DataSet dataSet1 = new DataSet();
                sqlDataAdapter1.Fill(dataSet1);
                string sql = "SELECT * FROM [demo].[dbo].[businessMessage] where shopname='" + businessLogin.Shopname + "'and name='" + businessLogin.Name + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if ((dataSet1 != null && dataSet1.Tables.Count > 0 && dataSet1.Tables[0].Rows.Count > 0) == false)
                {
                    return ApiResultBuilder<List<BusinessLogin>>.Return(-1, "账号不存在");
                }
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    string sq2 = "UPDATE [demo].[dbo].[businessMessage] SET password='" + businessLogin.Password + "' WHERE name='" + businessLogin.Name + "'";
                    DataSet dataSet2 = new DataSet();
                    SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sq2, sqlConnection);
                    sqlDataAdapter2.Fill(dataSet2);
                    return ApiResultBuilder<BusinessLogin>.Return(0, "修改成功");
                }
                else
                {
                    if ((dataSet1 != null && dataSet1.Tables.Count > 0 && dataSet1.Tables[0].Rows.Count > 0) == false)
                    {
                        return ApiResultBuilder<BusinessLogin>.Return(-1, "账号错误");
                    }
                    else
                    {
                        return ApiResultBuilder<BusinessLogin>.Return(-1, "店铺名称错误");
                    }
                }

            }
            catch (Exception e)
            {
                return ApiResultBuilder<BusinessLogin>.Return(-2, "数据异常" + e.Message);
            }
        }
    }
}