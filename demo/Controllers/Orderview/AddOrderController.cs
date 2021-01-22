using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using demo.Models;
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
        /// <param name="orders">数组数据</param>
        /// <returns></returns>
        [HttpPost]
        [Route("PostOrder")]
        public JsonResult PostOrder([FromBody]List<Online> orders)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                var TimeStamps = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
                foreach (var item in orders)
                {
                    string sql = "INSERT INTO [demo].[dbo].[order](shoppingid,name,username,address,phone,dishname,price,sumprice,time,windows,remarks,number,isSubmit,isComplete,isEvaluate,imageSrc,guige1,ladu,updatetime) VALUES" +
                        "('" + item.Shoppingid + "','" + item.Name + "','" + item.Username + "','" + item.Address + "','" + item.Phone + "','" + item.Dishname + "','" + item.Price + "','" + item.SumPrice + "','" + item.Time + "','" + item.Windows + "','" + item.Remarks + "','" + item.Number + "','" + 0 + "','" + 0 + "','" + 0 + "','" + item.ImageSrc + "','" + item.Guige1 + "','" + item.Ladu + "','" + TimeStamps + "') ";
                    DataSet dataSet = new DataSet();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                    sqlDataAdapter.Fill(dataSet);
                }
                foreach (var item in orders)
                {
                    string sql = "DELETE FROM [demo].[dbo].[shopping] WHERE shoppingid='" + item.Shoppingid + "' And username='" + item.Username + "'";
                    DataSet dataSet = new DataSet();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                    sqlDataAdapter.Fill(dataSet);
                }
                return new JsonResult(new { rtnCode = 0, resultMsg = "保存到购物车成功",data=TimeStamps });
            }
            catch (Exception e)
            {
                return ApiResultBuilder<FoodList>.Return(-2, "数据异常" + e.Message);
            }
        }
        #endregion

        #region 加载订单数据
        /// <summary>
        /// 加载订单数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("QueryOrderDetail")]
        public JsonResult QueryOrderDetail(string username,string updatetime)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "SELECT * FROM [demo].[dbo].[order] where username='"+username+"'And updatetime='"+updatetime+"'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<List<FoodList>>.Return(0, "查询成功", dataSet);
                }
                else
                {
                    return ApiResultBuilder<List<FoodList>>.Return(-1, "查无数据", dataSet);
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<FoodList>.Return(-2, "数据异常" + e.Message);
            }
        }
        #endregion
    }
}