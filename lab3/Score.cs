using System;
using System.Collections.Generic;

#nullable disable

namespace GlebLab3
{
    public partial class Score
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int Score1 { get; set; }
        public int Score2 { get; set; }

        public virtual Game Game { get; set; }
    }
}
