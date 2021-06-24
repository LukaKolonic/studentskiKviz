using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class Player
    {
        private int id;
        private static int counter = 0;
        public Player(string nickname, int quizID)
        {
            id = counter++;
            Nickname = nickname;
            QuizID = quizID;
        }

        public string Nickname  { get; set; }

        public int QuizID { get; set; }
    }
}