using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Serializable]
    public class UserAnswer
    {
        [Key]
        public int Id { set; get; }
        //public int TestUserId { set; get; } 
        public virtual TestUser TestUser { set; get; }
        //public int AnswerId { set; get; }
        public virtual Answer Answer { set; get; }
    }
}
