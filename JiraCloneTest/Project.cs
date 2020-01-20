using System.Collections.Generic;
using System.Windows.Forms;

namespace JiraCloneTest
{
    public class Project
    {
        public int ID { get; set; } = -1;
        public string Name { get; set; }
        public string Key { get; set; }
        public string Lead { get; set; }
        public List<Column> Columns { get; set; } = new List<Column>();
    }
}