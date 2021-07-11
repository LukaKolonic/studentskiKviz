namespace Application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pitanje")]
    public partial class Pitanje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Odgovor> Odgovor { get; set; }

        public virtual Quiz Quiz { get; set; }
 
        public override string ToString() => $"{Tekst}";
    }
}
