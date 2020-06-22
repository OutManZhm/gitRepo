using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeddingCelebration.Model.Entity
{
    [Table("Barrage")]
    public class Barrage
    {
        [ExplicitKey]//非自增长的用此标识
        public virtual string ID { get; set; }
        public virtual string Content { get; set; }
        public virtual string OpenID { get; set; }
        //0:未通过 1:通过
        public virtual int Pass { get; set; }
        public virtual DateTime CreateTime { get; set; }
    }
}
