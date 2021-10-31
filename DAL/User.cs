
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Serializable]
    public class User : ICloneable
    {
        [Key]
        public int Id { set; get; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required, MaxLength(50), MinLength(1), Index(IsUnique = true)]
        public string Login { set; get; }
        [Required, MaxLength(50), MinLength(1)]
        public string Password { set; get; }
        [Required]
        public bool IsAdmin { get; set; }

        public virtual ICollection<Group> Groups { set; get; } = new List<Group>();

        public virtual ICollection<TestUser> TestUsers { set; get; } = new List<TestUser>();

        public override bool Equals(object obj)
        {            
            if (this.GetType() != obj.GetType()) return false;

            User user = (User)obj;
            
            if (this.Id == user.Id &&
                this.FirstName == user.FirstName &&
                this.LastName == user.LastName &&
                this.Login == user.Login &&
                this.Password == user.Password &&
                this.IsAdmin == user.IsAdmin) 
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return $"[{Id}] {this.FirstName} {this.LastName}";
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        
    }
}
