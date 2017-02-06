using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise15_10_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            String connect = "Provider=Microsoft.JET.OLEDB.4.0;" + @"data source=c:\Code\cst117_week5assignment\week5_exercises\Account.mdb";
            OleDbConnection con = new OleDbConnection(connect);
            con.Open();
            Console.WriteLine("Made the connection to the Sales database");

            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT AccountNumber, Balance "
            + "FROM Accounts ORDER BY AccountNumber";
            OleDbDataReader reader = cmd.ExecuteReader();
            Console.WriteLine(" Account Number and Balances of Accounts");
            Console.WriteLine("Number\t\tBalance");
            while (reader.Read())
                Console.WriteLine("{0}\t{1}",
                reader.GetInt32(0), reader.GetDecimal(1));
            reader.Close();

            double newBalance = 1.00;
            cmd.CommandText = "UPDATE Accounts SET Balance = " + newBalance + " WHERE AccountNumber = 1111";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "SELECT AccountNumber, Balance "
            + "FROM Accounts ORDER BY AccountNumber";
            reader = cmd.ExecuteReader();
            Console.WriteLine(" NEW Account Number and Balances of Accounts");
            Console.WriteLine("Number\t\tBalance");
            while (reader.Read())
                Console.WriteLine("{0}\t{1}",
                reader.GetInt32(0), reader.GetDecimal(1));
            reader.Close();

            con.Close();
        }
    }
}
