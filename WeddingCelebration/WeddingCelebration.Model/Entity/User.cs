using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeddingCelebration.Model.Entity
{
    [Table("user")]
    public class User
    {

        public virtual int ID { get; set; }
        public virtual string uAccount { get; set; }
        public virtual string uPassword { get; set; }
        public virtual string uNickName { get; set; }
        public virtual string uMobile { get; set; }
        public virtual string uEmail { get; set; }
        public virtual int uStatus { get; set; }

    }
}
