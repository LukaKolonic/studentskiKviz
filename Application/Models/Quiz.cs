namespace Application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Quiz")]
    public partial class Quiz
    {
        public Quiz()
        {
            Pitanje = new HashSet<Pitanje>();
        }

        [Key]
        public int IDQuiz { get; set; }

        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string Naziv { get; set; }

        public virtual ICollection<Pitanje> Pitanje { get; set; }

        public virtual User User { get; set; }
    }
}
