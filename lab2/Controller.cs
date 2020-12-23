using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace GlebLab2
{
    public class Controller
    {
        static public void Menu(NpgsqlConnection con)
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\tMain menu");
                Console.WriteLine("0 => Show one table\n1 => Insert data\n2 => Delete  \n3 => Update data\n4 => Search text \n5 => Randomize data in Film \n6 => Exit");
                int param = Convert.ToInt32(Console.ReadLine());
                switch (param)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Choose the Table name");
                        Console.WriteLine(" 1 => Team \n 2 => Game \n 3 => Score \n 4 => Game Date \n 5 => Schedule \n");
                        int show = Convert.ToInt32(Console.ReadLine());
                        switch (show)
                        {
                            case 1:
                                Backend.ReaderTeam(con);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            default:
                                Console.WriteLine("Incorrect input");
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                        }
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Choose the Table name");
                        Console.WriteLine(" 1 => Team \n 2 => Game \n 3 => Score \n 4 => Game Date \n 5 => Schedule \n");
                        int insert = Convert.ToInt32(Console.ReadLine());
                        switch (insert)
                        {
                            case 1:
                                Console.WriteLine("Input data: ");
                                Console.WriteLine("Id: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Name: ");
                                string name = Console.ReadLine();
                                Backend.AddTeam(con, id, name);
                              //  Backend.AddClient(con, id, age, name);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;                          
                            default:
                                Console.WriteLine("Incorrect input");
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Choose the Table name");
                        Console.WriteLine(" 1 => Team \n 2 => Game \n 3 => Score \n 4 => Game Date \n 5 => Schedule \n");
                        int delete = Convert.ToInt32(Console.ReadLine());
                        switch (delete)
                        {
                            case 1:
                                Console.WriteLine("Input data: ");
                                Console.WriteLine("Id: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Backend.DeleteTeam(con, id);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            default:
                                Console.WriteLine("Incorrect input");
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Choose the Table name");
                        Console.WriteLine(" 1 => Team \n 2 => Game \n 3 => Score \n 4 => Game Date \n 5 => Schedule \n");
                        int update = Convert.ToInt32(Console.ReadLine());
                        switch (update)
                        {
                            case 1:
                                Console.WriteLine("Input data: ");
                                Console.WriteLine("Id: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Name: ");
                                string name = Console.ReadLine();
                                Backend.UpdateTeam(con, id, name);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            default:
                                break;

                        }
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Choose search");
                        Console.WriteLine("1:Поиск команды по дате провеения матча\n");
                        Console.WriteLine("2:Поиск счета команді по ее идентификатору\n");
                        int search = Convert.ToInt32(Console.ReadLine());
                        switch (search)
                        {
                            case 1:
                                Backend.Dynamic_Search1(con);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 2:
                                Backend.Dynamic_Search2(con);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            default:
                                Console.WriteLine("Incorrect input");
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;

                        }
                        break;
                    case 5:
                        Backend.RandomTeam(con);
                        Console.WriteLine("To proceed press Enter");
                        Console.ReadKey(true);

                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }


        }
    }
}
