using ContactsApp.Classes;
using SQLite;
using System;
using System.Collections.Generic;
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

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            // Save Contact
            Contact contact = new Contact()
            {
                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneNumberTextBox.Text
            };

            // inserting into the sqlite db
            using (SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contact>();
                conn.Insert(contact);
            }

            Close();
        }
    }
}
