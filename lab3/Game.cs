using System;
using System.Collections.Generic;

#nullable disable

namespace GlebLab3
{
    public partial class Game
    {
        public Game()
        {
            GameDates = new HashSet<GameDate>();
            Scores = new HashSet<Score>();
        }

        public int Id { get; set; }
        public int Team1Id { get; set; }
        public int Team2Id { get; set; }

        public virtual Team Team1 { get; set; }
        public virtual Team Team2 { get; set; }
        public virtual ICollection<GameDate> GameDates { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
    }
}
