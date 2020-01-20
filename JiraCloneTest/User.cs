using System.Collections.Generic;

namespace JiraCloneTest
{
    public class User
    {
        public int ID { get; set; } = -1;
        public string Username { get; set; }
        public List<Project> Projects { get; set; } = new List<Project>();
        public string Password { get; set; }
    }
}