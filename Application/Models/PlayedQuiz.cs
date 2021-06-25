namespace Application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlayedQuiz")]
    public partial class PlayedQuiz
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlayedQuiz()
        {
            Player = new HashSet<Player>();
        }

        [Key]
        public int IDPlayedQuiz { get; set; }

        public int QuizID { get; set; }

        public int GeneratedQuizID { get; set; }

        public int BrojPitanja { get; set; }

        public virtual Quiz Quiz { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Player> Player { get; set; }
    }
}
