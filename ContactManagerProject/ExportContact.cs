using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ContactManagerProject
{
    internal class ExportContact
    {
        private void Export_Contact_Click(object sender, RoutedEventArgs e)
        {
            List<Contact> contacts = new DB().GetContacts();
            String seperator = ",";

            StringBuilder output = new StringBuilder();
            String[] headings = { "Title", "First Name", "Last Name", "Middle Name", "Gender", "CreationDate", "UpdateDate", "Active"};
            output.AppendLine(String.Join(seperator, headings));

            foreach (var contact in contacts)
            {
                String[] row = { contact.Id.ToString(), contact.Title, contact.FirstName, contact.LastName, contact.MiddleName, contact.Gender.ToString(), contact.CreationDate, contact.UpdateDate, contact.Active.ToString() };

                output.AppendLine(String.Join(seperator, row));
            }

            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "csv file | *.csv";
                saveFileDialog.Title = "Export contact to a csv file";
                saveFileDialog.ShowDialog();
                if (saveFileDialog.FileName != String.Empty)
                {
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
