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
            ContactsListItems.ItemsSource = new DB().GetContacts();

        }
        
        private void ContactsListItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Contact selectedContact = (Contact)ContactsListItems.SelectedItem;
            if (selectedContact != null)
            {
                DetailsWindow newWindow = new DetailsWindow(selectedContact);
                newWindow.ShowDialog(); //
            }
            ContactsListItems.ItemsSource = new DB().GetContacts();
        }

        private void Add_Contact_btn_Click(object sender, RoutedEventArgs e)
        {
            Add_Contact addWindow = new Add_Contact();
            addWindow.Show();
        }

        private void Edit_Contact_btn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Del_Contact_btn_Click(object sender, RoutedEventArgs e)
        {
            Contact selectedContact = (Contact)ContactsListItems.SelectedItem;
            if (selectedContact != null)
            {
                new DB().Delete(selectedContact.Id, selectedContact.Active);
            }
            ContactsListItems.ItemsSource = new DB().GetContacts();
        }

        private void Imp_Contact_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Ex_Contact_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}