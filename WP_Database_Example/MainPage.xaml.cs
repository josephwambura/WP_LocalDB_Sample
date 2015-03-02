using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace WP_Database_Example
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            using (UniversityDataContext context = new UniversityDataContext(App.UniversityconnectionString))
            {
                if (!context.DatabaseExists())
                {
                    context.CreateDatabase();
                    MessageBox.Show("University Database created successfully");
                }
                else
                {
                    MessageBox.Show("University already Exists");
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewStudents.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddStudents.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}