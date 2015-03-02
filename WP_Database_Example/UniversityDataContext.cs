using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace WP_Database_Example
{
    public class UniversityDataContext: DataContext
    {
        public UniversityDataContext(String connectionString)
            : base(connectionString)
        {

        }
        public Table<Student> Students
        {
            get
            {
                return this.GetTable<Student>();
            }
        }
    }
}
