using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Serializable]
    public class Group
    {
        [Key]
        public int Id { set; get; }

        [Required, MaxLength(50)]
        public string Name { get; set; }
        
        public virtual ICollection<User> Users { set; get; } = new List<User>();

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            Group group = (Group)obj;
            return (group.Name != this.Name || group.Id != this.Id) ? false : true;
        }

        public override string ToString()
        {
            return $"[{Id}] {Name}";
        }

    }
}
