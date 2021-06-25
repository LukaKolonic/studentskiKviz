namespace Application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Player")]
    public partial class Player
    {
        [Key]
        public int IDPlayer { get; set; }

        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        public int PlayedQuizID { get; set; }

        public int Points { get; set; }

        public virtual PlayedQuiz PlayedQuiz { get; set; }
    }
}
