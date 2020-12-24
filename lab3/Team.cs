using System;
using System.Collections.Generic;

#nullable disable

namespace GlebLab3
{
    public partial class Team
    {
        public Team()
        {
            GameTeam1s = new HashSet<Game>();
            GameTeam2s = new HashSet<Game>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Game> GameTeam1s { get; set; }
        public virtual ICollection<Game> GameTeam2s { get; set; }
    }

    public class Team_UDI
    {
        public static void Insert(int id, string name)
        {
            using(TrainingContext db = new TrainingContext())
            {
                Team newTeam = new Team();
                newTeam.Id = id;
                newTeam.Name = name;

                db.Teams.Add(newTeam);
                db.SaveChanges();
            }
        }

        public static void Update(int id, string name)
        {
            using (TrainingContext db = new TrainingContext())
            {
                Team newTeam = db.Teams.Find(id)  ;
                newTeam.Id = id;
                newTeam.Name = name;

                db.Teams.Update(newTeam);
                db.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (TrainingContext db = new TrainingContext())
            {
                Team newTeam = db.Teams.Find(id);
                db.Teams.Remove(newTeam);
                db.SaveChanges();
            }
        }
    }

}
