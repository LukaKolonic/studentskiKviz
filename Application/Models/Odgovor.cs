namespace Application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Odgovor")]
    public partial class Odgovor
    {
        [Key]
        public int IDOdgovor { get; set; }

        public int PitanjeID { get; set; }

        [Required]
        [StringLength(1024)]
        public string Tekst { get; set; }

        public bool Correct { get; set; }

        public virtual Pitanje Pitanje { get; set; }

        public override string ToString() => $"{Tekst}";
    }
}

