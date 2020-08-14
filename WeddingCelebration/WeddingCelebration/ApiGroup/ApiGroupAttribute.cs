
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
    [AttributeUsage(AttributeTargets.Method)]
    public class ApiGroupAttribute : Attribute, IApiDescriptionGroupNameProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public ApiGroupAttribute(ApiGroupNames[] name)
        {
            listName = new List<string>();
            foreach (var item in name)
            {
                listName.Add(item.ToString());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> listName { get; set; }
    }
}

