namespace Application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Quiz")]
    public partial class Quiz
    {
        [Key]
        public int IDQuiz { get; set; }

        public int UserID { get; set; }

        public virtual User User { get; set; }
    }
}
