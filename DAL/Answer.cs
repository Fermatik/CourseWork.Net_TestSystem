using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Serializable]
    public class Answer
    {
        [Key]
        public int Id { set; get; }

        [Required, MaxLength(300)]
        public string Text { set; get; }

        [Required, DefaultValue(false)]
        public bool IsTrue { set; get; }
        
        public virtual Question Question { set; get; }

        public virtual ICollection<UserAnswer> UserAnswers { set; get; } = new List<UserAnswer>();

    }
}