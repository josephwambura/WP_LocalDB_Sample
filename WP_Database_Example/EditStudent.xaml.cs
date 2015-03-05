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
    public partial class EditStudent : PhoneApplicationPage
    {
        public EditStudent()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            String id = NavigationContext.QueryString["id"];
            using (UniversityDataContext context = new UniversityDataContext(App.UniversityconnectionString))
            {
                var StudentLoaded = (from Stud in context.Students where Stud.ID == Int32.Parse(id) select Stud).FirstOrDefault();
                if (StudentLoaded!=null)
                {
                    ID_txt.Text = StudentLoaded.ID.ToString();
                    Name_txt.Text = StudentLoaded.Name;
                    LastName_txt.Text = StudentLoaded.LastName;
                }
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            using (UniversityDataContext context = new UniversityDataContext(App.UniversityconnectionString))
            {
                var StudentLoaded = (from Stud in context.Students where Stud.ID == Int32.Parse(ID_txt.Text) select Stud).FirstOrDefault();
                if (StudentLoaded != null)
                {
                    StudentLoaded.Name = Name_txt.Text;
                    StudentLoaded.LastName = LastName_txt.Text;
                    context.SubmitChanges();
                }
            }
        }
    }
}