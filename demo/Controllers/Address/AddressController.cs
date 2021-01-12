using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using demo.Models.Common;
using demo.Models.DemoEntities.Address;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.Api.Controllers.Address
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        /// <summary>
        /// 加载地址列表数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("QueryAddressList")]
        public JsonResult QueryAddressList(string username)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "SELECT * FROM [demo].[dbo].[address] where username='wangfujun'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<List<Addresss>>.Return(0, "查询成功", dataSet);
                }
                else
                {
                    return ApiResultBuilder<Addresss>.Return(-1, "查无数据", dataSet);
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Addresss>.Return(-2, "数据异常" + e.Message);
            }
        }
        /// <summary>
        /// 向数据库中添加数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddAddress")]
        public JsonResult AddAddress([FromForm]Addresss addresss)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                string sql = "INSERT INTO [demo].[dbo].[address] VALUES('" + addresss.UserName + "','" + addresss.CityCode + "','" + addresss.Detail + "','" + addresss.Contactinfo + "','" + addresss.Contact + "','" + addresss.isdefault + "','" + addresss.Provincename + "','" + addresss.Cityname + "','" + addresss.Countyname + "') ";
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);
                return ApiResultBuilder<Addresss>.Return(0, "添加成功");
                //return JsonConvert.SerializeObject(dataSet);
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Addresss>.Return(-2, "数据异常" + e.Message);
            }
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="addresss"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateAddress")]
        public JsonResult UpdateAddress([FromBody]Addresss addresss)
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection(
                  "Server=localhost;User Id=sa;Password=123456789;Database=demo;");
                sqlConnection.Open();
                string sql = "UPDATE [demo].[dbo].[address] SET cityCode='" + addresss.CityCode + "',detail='" + addresss.Detail + "',contactinfo='" + addresss.Contactinfo + "',contact='" + addresss.Contact + "',isdefault='" + addresss.isdefault + "',provincename = '" + addresss.Provincename + "',cityname = '" + addresss.Cityname + "',countyname = '" + addresss.Countyname + "'where address.addressid = '" + addresss.Addressid + "'";
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);
                return ApiResultBuilder<Addresss>.Return(0, "更新成功");
                //return JsonConvert.SerializeObject(dataSet);
            }
            catch (Exception e)
            {
                return ApiResultBuilder<Addresss>.Return(-2, "数据异常" + e.Message);
            }
        }
    }
}