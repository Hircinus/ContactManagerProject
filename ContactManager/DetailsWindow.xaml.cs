using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace ContactManager
{
    /// <summary>
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        ContactsBinding cb;
        public DetailsWindow()
        {
            InitializeComponent();

            var ConString = ConfigurationManager.ConnectionStrings["ContactsDatabase"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConString))
            { con.Open(); }
        }
    }
}
