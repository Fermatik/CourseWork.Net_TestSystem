using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Serializable]
    public class TestUser
    {
        [Key]
        public int Id { set; get; }

        public virtual Test Test { set; get; }
        
        public virtual User User { set; get; }

        [Required]
        public DateTime Date { set; get; }

        public int? ResultPoints { set; get; } 
        public bool? ResultTest { set; get; }

        public virtual ICollection<UserAnswer> UserAnswers { set; get; } = new List<UserAnswer>();

    }
}
