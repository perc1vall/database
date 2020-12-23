using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace GlebLab2
{
    public class Backend
    {
        public static void ExecuteQuery(NpgsqlCommand _cmd)
        {
            try
            {
                _cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);

            }
        }
        static public void Execute(NpgsqlCommand _cmd)
        {
            ExecuteQuery(_cmd);
        }
        static public void ReaderTeam(NpgsqlConnection con)
        {
            Console.WriteLine("Team");
            Console.WriteLine("----------------------------");
            var sql = $"select * from \"team\"";
            var cmd = new NpgsqlCommand(sql, con);
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine($"{rdr.GetName(0),-4}\t {rdr.GetName(1),-4}\t");
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0),-4} \t {rdr.GetString(1),-3}\t ");
            }
            rdr.Close();
        }

        static public void AddTeam(NpgsqlConnection con, int id, string name)
        {
            var sql = "insert into \"team\"(id,name) VALUES(@id, @name)";
            var cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Prepare();

            Execute(cmd);
            Console.WriteLine("row inserted");
        }

        static public void DeleteTeam(NpgsqlConnection con, int id)
        {
            var sql = $"DELETE FROM \"team\" WHERE id=" + id;
            var cmd = new NpgsqlCommand(sql, con);
            Execute(cmd);
        }

        static public void UpdateTeam(NpgsqlConnection con, int id, string name)
        {
            var sql = $"UPDATE \"team\" SET name ='{name}' WHERE id = {id} ";
            var cmd = new NpgsqlCommand(sql, con);
            Execute(cmd);
        }
        static public void RandomTeam(NpgsqlConnection con)
        {
            Console.WriteLine("Num of randomized rows: ");
            int num = Convert.ToInt32(Console.ReadLine());
            //var rand_char = "chr(trunc(65+random()*25)::int)";
            string[] masstr = new string[num];
            for (int j = 0; j < num; j++) masstr[j] += " chr(trunc(65+random()*25)::int)";
            string rand_char = String.Join("||", masstr);
            for (int i = 0; i < num; i++)
            {
                var sql = $"insert into \"team\"(id,name) VALUES((random()*10000)::int , {rand_char})";
                var cmd = new NpgsqlCommand(sql, con);
                Execute(cmd);
            }

        }


        static public void Dynamic_Search1(NpgsqlConnection con)
        {

            DateTime date;
            Console.WriteLine("Input date");
            date = Convert.ToDateTime(Console.ReadLine());
            var sql = $"select team.id, team.name, game_date.date_id, schedule.date  from team inner join game on team.id = game.team1_id " +
                $"inner join game_date on game.id = game_date.game_id  inner join schedule on game_date.game_id = schedule.id where schedule.date = '{date}'";
            var cmd = new NpgsqlCommand(sql, con);
            Execute(cmd);

            NpgsqlDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine($"{rdr.GetName(0),-4}\t {rdr.GetName(1),-4}\t \t{rdr.GetName(2),10}\t {rdr.GetName(3),10}");
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0),-4} \t {rdr.GetString(1),-3}\t\t {rdr.GetInt32(2),10} \t\t{rdr.GetDate(3),10} \t\t ");
            }
            rdr.Close();
        }

        static public void Dynamic_Search2(NpgsqlConnection con)
        {
            int team_id;
            Console.WriteLine("Input id");
            team_id = Convert.ToInt32(Console.ReadLine());
            var sql = $"select team.id, team.name, score.game_id, score.score1, score.score2  from team " +
                $"inner join game on team.id = game.team1_id" +
                $" inner join score on game.id = score.game_id where team.id = {team_id}"; 

            var cmd = new NpgsqlCommand(sql, con);
            Execute(cmd);

            NpgsqlDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine($"{rdr.GetName(0),-4}\t {rdr.GetName(1),-4}\t \t{rdr.GetName(2),10}\t {rdr.GetName(3),10} \t {rdr.GetName(4),10}");
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0),-4} \t {rdr.GetString(1),-3}\t\t {rdr.GetInt32(2),10} \t\t{rdr.GetInt32(3),10} \t\t {rdr.GetInt32(4),10} ");
            }
            rdr.Close();
        }
    }
}