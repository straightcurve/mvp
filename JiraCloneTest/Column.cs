using System.Collections.Generic;

namespace JiraCloneTest
{
    public class Column
    {
        public int ID { get; set; } = -1;
        public string Name { get; set; }
        public List<Issue> Issues { get; set; } = new List<Issue>();
    }
}