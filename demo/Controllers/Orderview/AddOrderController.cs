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

namespace demo.Api.Controllers.Orderview
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddOrderController : ControllerBase
    {
        #region 加入购物车
        /// <summary>
        /// 向订单表中添加数据
        /// </summary>
        /// <param name="firstrooms"></param>
        /// <param name="studentid"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("postUser")]
        public JsonResult PostUser([FromBody]List<Firstroom> firstrooms, string studentid)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                var TimeStamps = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
                foreach (var item in firstrooms)
                {
                    string sql = "INSERT INTO [demo].[dbo].[order](studentid,dishname,price,score,time,windows,remarks,number,isSubmit,isConfirm,isComplete,isEvaluate,updatetime) VALUES('" + studentid + "','" + item.Dishname + "','" + item.Price + "','" + item.Score + "','" + item.Time + "','" + item.Windows + "','" + item.Remarks + "','" + item.Number + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + TimeStamps + "') ";
                    DataSet dataSet = new DataSet();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                    sqlDataAdapter.Fill(dataSet);
                }
                return ApiResultBuilder<Firstroom>.Return(0, "保存到购物车成功");
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Firstroom>.Return(-2, "数据异常" + e.Message);
            }
        }
        #endregion
    }
}