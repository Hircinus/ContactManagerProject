using Microsoft.Win32;
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
                        CreationDate = dr.GetString(6);
                        UpdateDate = dr.GetString(7);
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
            List<ContactDetail> contacts = DB.DB.GetContactsAll();
            String seperator = ",";

            StringBuilder output = new StringBuilder();
            String[] headings = { "Id", "FirstName", "MiddleName", "LastName", "Salutation", "Address", "CodeAddress", "AddressDescription", "Email", "CodeEmail", "EmailDescription", "Phone", "CodePhone", "PhoneDescription" };
            output.AppendLine(String.Join(seperator, headings));

            foreach (var contact in contacts)
            {
                String[] row = { contact.Id.ToString(), contact.FirstName, contact.MiddleName, contact.LastName, contact.Salutation, contact.Address, contact.CodeAddress, contact.AddressDescription, contact.Email, contact.CodeEmail, contact.EmailDescription, contact.Phone, contact.CodePhone, contact.PhoneDescription };

                output.AppendLine(String.Join(seperator, row));
            }

            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "csv file | *.csv";
                saveFileDialog.Title = "EXPORT CONTACTS TO CSV";
                saveFileDialog.ShowDialog();
                if (saveFileDialog.FileName != String.Empty)
                {
                    //System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog.OpenFile();
                    File.AppendAllText(saveFileDialog.FileName, output.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The file could not be created");
            }
        }
    }
}