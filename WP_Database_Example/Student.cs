using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace WP_Database_Example
{
    [Table]
    public class Student
    {
        [Column( IsDbGenerated=true, IsPrimaryKey=true, CanBeNull=false, AutoSync= AutoSync.OnInsert)]
        public int ID { get; set; }
        [Column(CanBeNull=false)]
        public String Name{ get; set; }
        [Column(CanBeNull=false)]
        public String LastName { get; set; }
    }
}
