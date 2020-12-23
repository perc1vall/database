using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace GlebLab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var cs = "Host=127.0.0.1;Username=postgres;Password=qwerty;Database=Training";
            var con = new NpgsqlConnection(cs);
            con.Open();
             Controller.Menu(con);

            con.Close();
        }
    }
}
