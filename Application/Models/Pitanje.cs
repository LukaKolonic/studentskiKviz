namespace Application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Pitanje")]
    public partial class Pitanje
    {
        public Pitanje()
        {
            Odgovor = new HashSet<Odgovor>();
        }

        [Key]
        public int IDPitanje { get; set; }

        public int QuizID { get; set; }

        [Required]
        [StringLength(1024)]
        public string Tekst { get; set; }

        public virtual ICollection<Odgovor> Odgovor { get; set; }

        public virtual Quiz Quiz { get; set; }
    }
}
