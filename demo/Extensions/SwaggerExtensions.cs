using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
/// <summary>
/// 添加控制器swagger扩展类
/// </summary>
public class ApplyTagDescriptions : IDocumentFilter
{
    /// <summary>
    /// swagger汉化标签
    /// </summary>
    /// <param name="swaggerDoc"></param>
    /// <param name="context"></param>
    public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
    {
        swaggerDoc.Tags = new List<Tag>
            {
                new Tag { Name = "Enterprise", Description = "企业相关接口" },
                new Tag { Name = "Ticket", Description = "机票相关接口" }
            };
    }
}