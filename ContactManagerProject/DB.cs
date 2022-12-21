using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerProject
{
    public class DB
    {
        public void Delete(Contact c)
        {
            var ConString = ConfigurationManager.ConnectionStrings["ContactsDatabase"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                string query = @"UPDATE Contact SET active = " + !c.Active + " WHERE Id = " + c.Id;
                //define the SqlCommand object
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    //cmd.Parameters.AddWithValue("@Id", c.getId);
                    //cmd.Parameters.AddWithValue("@firstname", user.FirstName);
                    //cmd.Parameters.AddWithValue("@lastname", user.LastName);
                    //add whatever parameters you required to update here
                    int rows = cmd.ExecuteNonQuery();
                    con.Close();
                }
                //close connection
                con.Close();
            }
        }
        public List<Contact> GetContacts()
        {
            List<Contact> arr = new List<Contact>();
            var ConString = ConfigurationManager.ConnectionStrings["ContactsDatabase"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                int Id;
                string Title, FirstName, LastName, MiddleName, CreationDate, UpdateDate;
                Boolean Gender, Active;
                string query = @"SELECT * FROM Contact";
                //define the SqlCommand object
                SqlCommand cmd = new SqlCommand(query, con);

                //open connection
                con.Open();

                //execute the SQLCommand
                SqlDataReader dr = cmd.ExecuteReader();

                Console.WriteLine(Environment.NewLine + "Retrieving data from database..." + Environment.NewLine);
                Console.WriteLine("Retrieved records:");

                //check if there are records
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Id = dr.GetInt32(0);
                        Title = dr.GetString(1);
                        FirstName = dr.GetString(2);
                        LastName = dr.GetString(3);
                        MiddleName = dr.GetString(4);
                        Gender = dr.GetBoolean(5);
                        CreationDate = dr.GetDateTime(6).ToString();
                        UpdateDate = dr.GetDateTime(7).ToString();
                        Active = dr.GetBoolean(8);

                        arr.Add(new Contact(Id, Title, FirstName, LastName, MiddleName, Gender, CreationDate, UpdateDate, Active));
                    }
                }
                else
                {
                    Console.WriteLine("No data found.");
                }

                //close data reader
                dr.Close();

                //close connection
                con.Close();
            }
            return arr;
        }
    }
}
