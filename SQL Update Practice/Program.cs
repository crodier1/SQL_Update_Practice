using System;
using System.Data.SqlClient;

namespace SQL_Update_Practice
{
    class Program
    {
        static string connString = @"Data Source=DESKTOP-3BDGT3N;Initial Catalog=AddressBook;Integrated Security=True";
        static SqlConnection conn;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter Id Num");
            string idQuestion = Console.ReadLine();
            int id = Convert.ToInt32(idQuestion);

            Console.WriteLine("Enter new company name");

            string newCompanyName = Console.ReadLine();



            string updateStatement = $@"update BizContacts 
                                        set company = '{newCompanyName}'
                                        where id = {id}";

            //Console.WriteLine(updateStatement);


            using (conn = new SqlConnection(connString))
            {
                try
                {

                    conn.Open();

                    SqlCommand comm = new SqlCommand(updateStatement, conn);

                    comm.ExecuteNonQuery();

                    conn.Close();

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }







            Console.Read();
        }
    }
}
