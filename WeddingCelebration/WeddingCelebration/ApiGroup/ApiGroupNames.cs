﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingCelebration.ApiGroup
{

    /// <summary>
    /// 系统分组枚举值
    /// </summary>
    public enum ApiGroupNames
    {
        [GroupInfo(Title = "登录认证", Description = "登录认证相关接口", Version = "v1")]
        Auth,
        [GroupInfo(Title = "IT", Description = "登录认证相关接口")]
        It,
        [GroupInfo(Title = "人力资源", Description = "登录认证相关接口")]
        Hr,
        Cw
    }

}
