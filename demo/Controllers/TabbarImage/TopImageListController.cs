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

namespace demo.Api.Controllers.TabbarImage
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopImageListController : ControllerBase
    {
        /// <summary>
        /// 加载首页导航图片
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("QueryImageList")]
        public JsonResult QueryImageList()
        {
            try
            {
                SqlConnection sqlConnection =
                 new SqlConnection("Server=localhost;User Id=sa;Password=123456789;Database=demo;");//连接数据库
                sqlConnection.Open();
                string sql = "SELECT * FROM [demo].[dbo].[tabbarimgList]";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return ApiResultBuilder<List<ImageList>>.Return(0, "查询成功", dataSet);
                }
                else
                {
                    return ApiResultBuilder<List<ImageList>>.Return(-1, "查无数据", dataSet);
                }
            }
            catch (Exception e)
            {
                return ApiResultBuilder<ImageList>.Return(-2, "数据异常" + e.Message);
            }
        }
    }
}