using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeddingCelebration.Model.Entity
{
    [Table("Log")]
    public class Log
    {
        [Key]//自增长的用此标识
        public virtual int ID { get; set; }
        public virtual string FuntionName { get; set; }
        public virtual string SQL { get; set; }
        //0:未通过 1:通过
        public virtual string Result { get; set; }
        public virtual DateTime CreateTime { get; set; }
    }
}
