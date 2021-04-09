using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GeoTronic.Models
{
    public class GeoContext
    {
        private static string Host = "localhost";
        private static string User = "postgres";
        private static string DBname = "postgres";
        private static string Password = "Sh!ft3891";
        private static string Port = "5432";


        public List<Points> pointsLists = new List<Points>();
        public int howManyRows;

        //private DataSet ds = new DataSet();
        public DataTable dt = new DataTable();

        public dynamic resultat;
        public GeoContext()
        {
            pointsLists = TakeDataFromTablePoints().ToList();
            howManyRows = pointsLists.Count;
        }
        public IEnumerable<Points> TakeDataFromTablePoints()
        {
            string connString =
                String.Format(
                    "Server={0};Port={1};User Id={2};Password={3};Database={4};",
                    Host,
                    Port,
                    User,
                    Password,
                    DBname);

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("select * from SegregatePointsInWojewodztwo() order by zz;", conn))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Points
                        {
                            X = reader.GetDouble(0),
                            Y = reader.GetDouble(1),
                            Z = reader.GetDouble(2),
                            Wojewodztwo = reader.GetString(3),
                        };
                    }
                }
            }
        }
    }
}
