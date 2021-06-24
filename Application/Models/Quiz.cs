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
        private int id;
        private static int counter = 0;

        public Quiz(int userID, User user, string code)
        {
            id = counter++;
            UserID = userID;
            User = user;
            Code = code;
        }

        [Key]
        public int IDQuiz { get; set; }

        public int UserID { get; set; }

        public string Code { get; set; }

        public virtual User User { get; set; }

        public List<Player> Players { get; set; }
    }
}
