using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using demo.Models.Common;
using demo.Models.DemoEntities.ShoppingCart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.Api.Controllers.ShoppingCart
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        /// <summary>
        /// 加入购物车
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddShoppCar")]
        public IActionResult AddShoppCar([FromBody]ShoppingCartt shoppitem)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                var TimeStamps = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
                string sql = "INSERT INTO [demo].[dbo].[shopping](username,dishname,price,sumprice,time,remarks,windows,number,ladu,guige1,imagesrc,updatetime) VALUES('" + shoppitem.Username + "','" + shoppitem.Dishname + "','" + shoppitem.Price + "','" + shoppitem.SumPrice + "','" + shoppitem.Time + "','" + shoppitem.Remarks + "','" + shoppitem.Windows + "','" + shoppitem.Number + "','" + shoppitem.Ladu + "','" + shoppitem.Guige1 + "','" + shoppitem.Imagesrc + "','" + TimeStamps + "') ";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<ShoppingCartt>.Return(-1, "保存失败", dataSet);
                }
                else
                {
                    return ApiResultBuilder<List<ShoppingCartt>>.Return(0, "保存购物车成功", dataSet);
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<ShoppingCartt>.Return(-2, "数据异常" + e.Message);
            }
        }

        /// <summary>
        /// 购物车-加载表格数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("queryUser")]
        public JsonResult QueryUser(string username)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "SELECT * FROM [demo].[dbo].[shopping] where username='" + username+"'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<List<ShoppingCartt>>.Return(0, "查询成功", dataSet);
                }
                else
                {
                    return ApiResultBuilder<ShoppingCartt>.Return(-1, "查无数据", dataSet);
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<ShoppingCartt>.Return(-2, "数据异常" + e.Message);
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("DeleteOneOrder")]
        public JsonResult DeleteOneOrder(string shoppingid, string username)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                string sql = "DELETE FROM [demo].[dbo].[shopping] WHERE shoppingid='" +shoppingid + "' And username='" + username + "'";
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);
                return ApiResultBuilder<ShoppingCartt>.Return(0, "删除成功");
            }
            catch (Exception e)
            {
                return ApiResultBuilder<ShoppingCartt>.Return(-2, "数据异常" + e.Message);
            }
        }


        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("deleteorder")]
        public JsonResult DeleteOrder([FromForm]List<ShoppingCartt> ShoppingCartt, string username)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                foreach (var item in ShoppingCartt)
                {
                    string sql = "DELETE FROM [demo].[dbo].[shopping] WHERE shoppingid='" + item.Shoppingid + "' And username='" + username + "'";
                    DataSet dataSet = new DataSet();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                    sqlDataAdapter.Fill(dataSet);
                }
                return ApiResultBuilder<ShoppingCartt>.Return(0, "删除成功");
            }
            catch (Exception e)
            {
                return ApiResultBuilder<ShoppingCartt>.Return(-2, "数据异常" + e.Message);
            }
        }

    }
}