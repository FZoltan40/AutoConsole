using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace AutoConsole
{

    public class Program
    {
        public static List<Cars> carList = new List<Cars>();
        static Connection conn = new Connection();
        public static void feladat1()
        {
            try
            {
                conn.connection.Open();

                string sql = "SELECT * FROM `cars`";
                MySqlCommand cmd = new MySqlCommand(sql, conn.connection);

                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                do
                {
                    Cars cars = new Cars();
                    cars.Id = dr.GetInt32(0);
                    cars.Brand = dr.GetString(1);
                    cars.Type = dr.GetString(2);
                    cars.License = dr.GetString(3);
                    cars.Date = dr.GetDateTime(4);

                    carList.Add(cars);
                } while (dr.Read());

                dr.Close();

                conn.connection.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }
        static void Main(string[] args)
        {
            feladat1();
            foreach (var item in carList)
            {
                Console.WriteLine($"Első feladat {item.Brand}, {item.License}");
            }


        }
    }
}
