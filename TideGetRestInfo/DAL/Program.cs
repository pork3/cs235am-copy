using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program will create a Database for both the tide locations \n and the actual tide informataion");
            Console.WriteLine("Press a key to continue: ");
            Console.ReadLine();

            using (var db = new SQLiteConnection(("../../../TideSQLite/Assets/tides.db"));

        }
    }
}
