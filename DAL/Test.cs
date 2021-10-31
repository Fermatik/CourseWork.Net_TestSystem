using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Serializable]
    public class Test
    {
        [Key]
        public int Id { set; get; }

        [Required, MaxLength(100)]
        public string Author { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }
        
        [Required, MaxLength(300)]
        public string Description { get; set; }

        [Required, MaxLength(300)]
        public string Info { get; set; }
        
        [Required]
        public int Percent { set; get; }        

        public virtual ICollection<Question> Questions { set; get; } = new List<Question>();

        public virtual ICollection<TestUser> TestUsers { set; get; } = new List<TestUser>();

        public override string ToString()
        {
            return $"[{Id}] {Title}";
        }
    }
}
