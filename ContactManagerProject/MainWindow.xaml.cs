using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactManagerProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var ConString = ConfigurationManager.ConnectionStrings["ContactsDatabase"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConString))
            { 
                int Id;
                string Title, FirstName, LastName, MiddleName, Gender, CreationDate, UpdateDate, Active;
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
                        Gender = dr.GetString(5);
                        CreationDate = dr.GetString(6);
                        UpdateDate = dr.GetString(7);
                        Active = dr.GetString(8);

                        //display retrieved record
                        Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}", Id.ToString(), Title, FirstName, LastName, MiddleName, Gender, CreationDate, UpdateDate, Active);
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
            
        }

        private void ContactsListItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ContactsBinding selectedContact = (ContactsBinding)ContactsListItems.SelectedItem;
            if (selectedContact != null)
            {
                DetailsWindow newWindow = new DetailsWindow();
                newWindow.ShowDialog(); //
            }
            //contacts = DBH.getContacts();
            //ContactsListItems.ItemsSource = contacts;
        }

        private void Add_Contact_btn_Click(object sender, RoutedEventArgs e)
        {
            AddContact addWindow = new AddContact();
            addWindow.Show();
        }

        private void Edit_Contact_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Del_Contact_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Imp_Contact_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Ex_Contact_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}