using System;
using System.Collections.Generic;

#nullable disable

namespace GlebLab3
{
    public partial class Schedule
    {
        public Schedule()
        {
            GameDates = new HashSet<GameDate>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool WorkingDay { get; set; }

        public virtual ICollection<GameDate> GameDates { get; set; }
    }
}
