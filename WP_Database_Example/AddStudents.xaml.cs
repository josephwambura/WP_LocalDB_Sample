using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace WP_Database_Example
{
    public partial class AddStudents : PhoneApplicationPage
    {
        public AddStudents()
        {
            InitializeComponent();
        }

        private void Submit(object sender, EventArgs e)
        {
            using (UniversityDataContext context = new UniversityDataContext(App.UniversityconnectionString))
            {
                Student st = new Student() { ID = Int32.Parse(ID_text.Text), Name = Name_text.Text, LastName = LastName_text.Text };
                context.Students.InsertOnSubmit(st);
                context.SubmitChanges();
                MessageBox.Show("Student Added Successfully");
            }
        }
    }
}