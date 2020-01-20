using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using Dapper;

namespace JiraCloneTest
{
    public static class DbContext
    {
        private static SqlConnection connection;

        static DbContext()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["JiraClone"].ConnectionString);
            connection.Open();
            Application.ApplicationExit += Shutdown;
        }

        public static void Shutdown(object sender, EventArgs e)
        {
            connection.Close();
            connection.Dispose();
        }

        public static void GetUserData(User user)
        {
            //var query = $@"
            //    SELECT * 
            //    FROM Users 
            //    RIGHT JOIN Projects 
            //    ON (Users.ID = Projects.UserID) 
            //    RIGHT JOIN Columns
            //    ON (Projects.ID = Columns.ProjectID) 
            //    JOIN Issues
            //    ON (Columns.ID = Issues.ColumnID) 
            //    WHERE Users.ID = @ID";

            //var results = ExecuteReader(query, new SqlParameter("@ID", user.ID));

            //for (int p = 0; p < results.Count; p++)
            //{
            //}
            var select = $"SELECT *";
            var cond = $"WHERE UserID = {user.ID}";
            var query = $"{select} FROM Projects {cond}";
            var projects = connection.Query<Project>(query).AsList();
            if (projects.Count == 0)
                return;

            user.Projects = projects;

            for (int p = 0; p < projects.Count; p++)
            {
                cond = $"WHERE ProjectID = {projects[p].ID}";
                query = $"{select} FROM Columns {cond}";
                var columns = connection.Query<Column>(query).AsList();
                if (columns.Count == 0)
                    continue;

                user.Projects[p].Columns = columns;

                for (int c = 0; c < columns.Count; c++)
                {
                    //user.Projects[p].Columns.Add(columns[c]);
                    cond = $"WHERE ColumnID = {columns[c].ID}";
                    query = $"{select} FROM Issues {cond}";
                    var issues = connection.Query<Issue>(query).AsList();
                    if (issues.Count == 0)
                        continue;

                    user.Projects[p].Columns[c].Issues = issues;
                }
            }
        }

        public static User GetUser(string username)
        {
            var select = $"SELECT *";
            var cond = $"WHERE Username = '{username}'";
            var query = $"{select} FROM Users {cond}";
            var userResult = connection.Query<User>(query).AsList();
            if (userResult.Count == 0)
                return null;

            return userResult[0];
        }

        public struct Response
        {
            public int LastID { get; set; }
        }

        public static int GetLastID(string table)
        {
            var select = $"SELECT MAX(ID) as LastID";
            var query = $"{select} FROM {table}s";
            var result = connection.Query<Response>(query).AsList();
            if (result.Count == 0)
                return -1;

            return result[0].LastID;
        }

        public static void Save(User user)
        {
            if (user.ID == -1)
            {
                connection.Execute($"dbo.{nameof(User)}s_Insert @Username, @Password", user);
                user.ID = GetLastID(nameof(User));
            }
            else
                connection.Execute($"dbo.{nameof(User)}s_Update @ID, @Username, @Password", user);

            for (int p = 0; p < user.Projects.Count; p++)
                Save(user.Projects[p], user.ID);
        }

        public static void Save(Project project, int userID)
        {
            if (project.ID == -1)
            {
                connection.Execute($"dbo.{nameof(Project)}s_Insert @Name, @Key, @Lead, @UserID", new
                {
                    Name = project.Name,
                    Key = project.Key,
                    Lead = project.Lead,
                    UserID = userID,
                });
                project.ID = GetLastID(nameof(Project));
            }
            else
                connection.Execute($"dbo.{nameof(Project)}s_Update @ID, @Name, @Key, @Lead, @UserID", new
                {
                    ID = project.ID,
                    Name = project.Name,
                    Key = project.Key,
                    Lead = project.Lead,
                    UserID = userID,
                });

            for (int c = 0; c < project.Columns.Count; c++)
                Save(project.Columns[c], project.ID);
        }

        public static void Save(Column column, int projectID)
        {
            if (column.ID == -1)
            {
                connection.Execute($"dbo.{nameof(Column)}s_Insert @Name, @ProjectID", new
                {
                    Name = column.Name,
                    ProjectID = projectID,
                });
                column.ID = GetLastID(nameof(Column));
            }
            else
                connection.Execute($"dbo.{nameof(Column)}s_Update @ID, @Name, @ProjectID", new
                {
                    ID = column.ID,
                    Name = column.Name,
                    ProjectID = projectID,
                });

            for (int i = 0; i < column.Issues.Count; i++)
                Save(column.Issues[i], column.ID);
        }

        public static void Save(Issue issue, int columnID)
        {
            if (issue.ID == -1)
            {
                connection.Execute($"dbo.{nameof(Issue)}s_Insert @Summary, @ColumnID", new
                {
                    Summary = issue.Summary,
                    ColumnID = columnID,
                });
                issue.ID = GetLastID(nameof(Issue));
            }
            else
                connection.Execute($"dbo.{nameof(Issue)}s_Update @ID, @Summary, @ColumnID", new
                {
                    ID = issue.ID,
                    Summary = issue.Summary,
                    ColumnID = columnID,
                });
        }

        #region Helper functions
        private static List<object[]> ExecuteReader(string sql, params SqlParameter[] parameters)
        {
            var temp = new List<object[]>();

            using (var command = new SqlCommand(sql, connection))
            {
                foreach (var param in parameters)
                    command.Parameters.Add(param);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var buffer = new object[reader.FieldCount];
                        reader.GetValues(buffer);
                        temp.Add(buffer);
                    }
                }
            }

            return temp;
        }

        private static void ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (var command = new SqlCommand(sql, connection))
            {
                foreach (var param in parameters)
                    command.Parameters.Add(param);
                command.ExecuteNonQuery();
            }
        }
        #endregion

    }
}