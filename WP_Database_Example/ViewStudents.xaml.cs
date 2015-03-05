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
    public partial class ViewStudents : PhoneApplicationPage
    {
        public ViewStudents()
        {
            InitializeComponent();
            LoadStudents();
        }

        private void LoadStudents()
        {
            using (UniversityDataContext context = new UniversityDataContext(App.UniversityconnectionString))
            {
                IQueryable<Student> StudentList = from Students in context.Students select Students;
                List<Student> StudentItems = StudentList.ToList();
                StudentListBox.ItemsSource = StudentItems;
            }
        }

        private void DeleteRegister(object sender, EventArgs e)
        {
            if (StudentListBox.SelectedIndex!=-1)
            {
                Student st = (Student)StudentListBox.SelectedItem;
                using (UniversityDataContext context = new UniversityDataContext(App.UniversityconnectionString))
                {
                    context.Students.Attach(st);
                    context.Students.DeleteOnSubmit(st);
                    context.SubmitChanges();
                    MessageBox.Show("Student Deleted Successfully");
                    StudentListBox.ItemsSource = null;
                    LoadStudents();
                }
            }
            else
            {
                MessageBox.Show("A Student must be selected in order to delete it!");
            }
        }

        private void EditRegister(object sender, EventArgs e)
        {
            if (StudentListBox.SelectedIndex != -1)
            {
                Student st = (Student)StudentListBox.SelectedItem;
                NavigationService.Navigate(new Uri("/EditStudent.xaml?id=" + st.ID, UriKind.RelativeOrAbsolute));
            }
            else
            {
                MessageBox.Show("A Student must be selected in order to edit it!");
            }
        }


    }
}