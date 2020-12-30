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
    public class TadayRecommendController : ControllerBase
    {
        /// <summary>
        /// 今日推荐菜加载数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("queryUser")]
        public JsonResult QueryUser()
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "SELECT * FROM [demo].[dbo].[tadayRecommend]";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<List<Taday>>.Return(dataSet);
                }
                else
                {
                    return ApiResultBuilder<Taday>.Return(-1, "查无数据");
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Taday>.Return(-2, "数据异常" + e.Message);
            }
        }

        #region 第一餐厅-加入购物车
        /// <summary>
        /// 第一餐厅-向订单表中添加数据
        /// </summary>
        /// <param name="firstrooms"></param>
        /// <param name="studentid"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("postUser")]
        public JsonResult PostUser([FromBody]Firstroom firstrooms, string studentid)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                string sql = "INSERT INTO [demo].[dbo].[order](studentid,dishname,price,score,time,practice,windows,remarks,number,isSubmit,isConfirm,isComplete,updatetime) VALUES('" + studentid + "','" + firstrooms.Dishname + "','" + firstrooms.Price + "','" + firstrooms.Score + "','" + firstrooms.Time + "','" + firstrooms.Windows + "','" + firstrooms.Remarks + "','" + firstrooms.Number + "','" + false + "','" + false + "','" + false + "','" + DateTime.Now.ToString() + "') ";
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);
                return ApiResultBuilder<Firstroom>.Return(0, "保存成功");
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Firstroom>.Return(-2, "数据异常" + e.Message);
            }
        }
        #endregion
    }
}