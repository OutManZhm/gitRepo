
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingCelebration.ApiGroup
{
    /// <summary>
    /// 系统分组特性
    /// </summary>
    
    public class ApiGroupAttribute : Attribute, IApiDescriptionGroupNameProvider
    {
        public ApiGroupAttribute(ApiGroupNames[] name)
        {
            listName = new List<string>();
            foreach (var item in name)
            {
                listName.Add(item.ToString());
            }
        }
        public string GroupName { get; set; }
        public List<string> listName { get; set; }
    }
}

