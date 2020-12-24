using System;
using System.Collections.Generic;

#nullable disable

namespace GlebLab3
{
    public partial class GameDate
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int DateId { get; set; }

        public virtual Schedule Date { get; set; }
        public virtual Game Game { get; set; }
    }
}
