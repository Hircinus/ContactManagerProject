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
            { con.Open(); }
        }

        private void ContactsListItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ContactsBinding selectedContact = (ContactsBinding)ContactsListItems.SelectedItem;
            if (selectedContact != null)
            {
                DetailsWindow newWindow = new DetailsWindow(selectedContact.ID);
                newWindow.ShowDialog(); //
            }
            contacts = DBH.getContacts();
            ContactsListItems.ItemsSource = contacts;
        }

        private void Add_Contact_btn_Click(object sender, RoutedEventArgs e)
        {

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