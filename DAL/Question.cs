using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    [Serializable]
    public class Question
    {
        [Key]
        public int Id { set; get; }
        [Required, MaxLength(300)]
        public string Text { set; get;  }
        [Required, DefaultValue(1)]
        public int Points { set; get; }
        
        public byte[] Image { set; get; }

        public virtual Test Test { set; get; }

        public virtual ICollection<Answer> Answers { set; get; } = new List<Answer>();
    }
}