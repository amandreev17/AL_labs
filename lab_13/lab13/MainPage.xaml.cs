using Microsoft.Data.Sqlite;
using lab13.Models;

namespace lab13
{
    public partial class MainPage : ContentPage
    {
        SqliteConnection sqliteConnection;
        public MainPage()
        {
            InitializeComponent();
            string sqliteconnect = $"Data Source=/Users/olesaandreeva/Desktop/lab12Contex-62028ef8-a8e2-4133-bf0e-8214f642f57b.db";
            sqliteConnection = new SqliteConnection(sqliteconnect);
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            try
            {
                sqliteConnection.Open();
                await App.Current.MainPage.DisplayAlert("Attention", "Connection complite", "Ok");
                sqliteConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw;
            }
        }

        private async void GetClicked(object sender, EventArgs e)
        {
            try
            {
                List<Student> students = new List<Student>();
                sqliteConnection.Open();
                string queryStringsser = "Select * from Student";
                SqliteCommand sqlCommand = new SqliteCommand(queryStringsser, sqliteConnection);
                SqliteDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    students.Add(new Student() { Id = Convert.ToInt32(reader["Id"]), Name = reader["Name"].ToString(), GroupId = Convert.ToInt32(reader["GroupId"]), StipId = Convert.ToInt32(reader["StipId"]) });

                }

                CheckList.ItemsSource = students;
                reader.Close();
                sqliteConnection.Close();

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Attention", ex.Message, "Ok");
                throw;
            }


        }

        private async void PostClicked(object sender, EventArgs e)
        {
            try
            {
                sqliteConnection.Open();
                using (SqliteCommand command = new SqliteCommand("INSERT INTO Student VALUES(@Id, @Name, @GroupId, @StipId)", sqliteConnection))
                {
                    command.Parameters.Add(new SqliteParameter("Id", Id.Text));
                    command.Parameters.Add(new SqliteParameter("Name", Name.Text));
                    command.Parameters.Add(new SqliteParameter("GroupId", GroupId.Text));
                    command.Parameters.Add(new SqliteParameter("StipId", StipId.Text));
                    command.ExecuteNonQuery();
                }
                sqliteConnection.Close();
                await App.Current.MainPage.DisplayAlert("Attention", "Add", "Ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Attention", ex.Message, "Ok");

            }
        }

        private async void PutClicked(object sender, EventArgs e)
        {
            try
            {
                sqliteConnection.Open();
                int id = Convert.ToInt32(Id.Text);
                string name = Name.Text;
                int idgroup = Convert.ToInt32(GroupId.Text);
                int idstip = Convert.ToInt32(StipId.Text);
                string qcomand = $"UPDATE Student SET Id = '{id}', Name='{name}', GroupId='{idgroup}', StipId='{idstip}' WHERE Id='{id}'";
                using (SqliteCommand command = new SqliteCommand(qcomand, sqliteConnection))
                {

                    command.ExecuteNonQuery();
                }

                sqliteConnection.Close();
                await App.Current.MainPage.DisplayAlert("Attention", "Update", "Ok");

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Attention", ex.Message, "Ok");
                throw;
            }
        }

        private async void DelClicked(object sender, EventArgs e)
        {
            try
            {
                sqliteConnection.Open();
                int iddel = Convert.ToInt32(Id.Text);
                using (SqliteCommand command = new SqliteCommand($"Delete FROM Student WHERE Id = {iddel}", sqliteConnection))
                {

                    command.ExecuteNonQuery();
                }

                sqliteConnection.Close();
                await App.Current.MainPage.DisplayAlert("Attention", "Delete", "Ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Attention", ex.Message, "Ok");
                throw;
            }
        }

        private async void GetClickedG(object sender, EventArgs e)
        {
            try
            {
                List<Group> groups = new List<Group>();
                sqliteConnection.Open();
                string queryStringsser = "Select * from \"Group\"";
                SqliteCommand sqlCommand = new SqliteCommand(queryStringsser, sqliteConnection);
                SqliteDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    groups.Add(new Group() { GroupId = Convert.ToInt32(reader["GroupId"]), NameGroup = reader["NameGroup"].ToString() });

                }

                CheckListG.ItemsSource = groups;
                reader.Close();
                sqliteConnection.Close();

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Attention", ex.Message, "Ok");
                throw;
            }
        }

        private async void PostClickedG(object sender, EventArgs e)
        {
            try
            {
                sqliteConnection.Open();
                using (SqliteCommand command = new SqliteCommand("INSERT INTO \"Group\" VALUES(@GroupId2, @NameGroup)", sqliteConnection))
                {
                    command.Parameters.Add(new SqliteParameter("GroupId2", GroupId2.Text));
                    command.Parameters.Add(new SqliteParameter("NameGroup", NameGroup.Text));
                    command.ExecuteNonQuery();
                }
                sqliteConnection.Close();
                await App.Current.MainPage.DisplayAlert("Atention", "Add", "Ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Attention", ex.Message, "Ok");
            }
        }

        private async void PutClickedG(object sender, EventArgs e)
        {
            try
            {
                sqliteConnection.Open();
                int id = Convert.ToInt32(GroupId2.Text);
                string nameG = NameGroup.Text;
                string qcomand = $"UPDATE \"Group\" SET GroupId2 = '{id}', NameGroup='{nameG}' WHERE GroupId2= '{id}'";
                using (SqliteCommand command = new SqliteCommand(qcomand, sqliteConnection))
                {

                    command.ExecuteNonQuery();
                }

                sqliteConnection.Close();
                await App.Current.MainPage.DisplayAlert("Attention", "Update", "Ok");

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Attention", ex.Message, "Ok");
                throw;
            }
        }

        private async void DelClickedG(object sender, EventArgs e)
        {
            try
            {
                sqliteConnection.Open();
                int iddel = Convert.ToInt32(GroupId2.Text);
                using (SqliteCommand command = new SqliteCommand($"Delete FROM \"Group\" WHERE GroupId2 = {iddel}", sqliteConnection))
                {

                    command.ExecuteNonQuery();
                }

                sqliteConnection.Close();
                await App.Current.MainPage.DisplayAlert("Attention", "Delete", "Ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Attention", ex.Message, "Ok");
                throw;
            }
        }

        private async void GetClickedS(object sender, EventArgs e)
        {
            try
            {
                List<Scholarship> scholarships = new List<Scholarship>();
                sqliteConnection.Open();
                string queryStringsser = "Select * from Scholarship";
                SqliteCommand sqlCommand = new SqliteCommand(queryStringsser, sqliteConnection);
                SqliteDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    scholarships.Add(new Scholarship() { StipId = Convert.ToInt32(reader["StipId"]), Size = Convert.ToInt32(reader["Size"]) });

                }

                CheckListS.ItemsSource = scholarships;
                reader.Close();
                sqliteConnection.Close();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Attention", ex.Message, "Ok");
                throw;
            }
        }

        private async void PostClickedS(object sender, EventArgs e)
        {
            try
            {
                sqliteConnection.Open();
                using (SqliteCommand command = new SqliteCommand("INSERT INTO Scholarship VALUES(@StipId, @Size)", sqliteConnection))
                {
                    command.Parameters.Add(new SqliteParameter("StipId", StipsId.Text));
                    command.Parameters.Add(new SqliteParameter("Size", SizeS.Text));
                    command.ExecuteNonQuery();
                }

                sqliteConnection.Close();
                await App.Current.MainPage.DisplayAlert("Attention", "Add", "Ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Attention", ex.Message, "Ok");

            }
        }

        private async void PutClickedS(object sender, EventArgs e)
        {
            try
            {
                sqliteConnection.Open();
                int id = Convert.ToInt32(StipsId.Text);
                decimal size = Convert.ToInt32(SizeS.Text);
                string qcomand = $"UPDATE Scholarship SET StipId = '{id}', Size='{size}'";
                using (SqliteCommand command = new SqliteCommand(qcomand, sqliteConnection))
                {

                    command.ExecuteNonQuery();
                }

                sqliteConnection.Close();
                await App.Current.MainPage.DisplayAlert("Attention", "Update", "Ok");

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Attention", ex.Message, "Ok");
                sqliteConnection.Close();
            }
        }

        private async void DelClickedS(object sender, EventArgs e)
        {
            try
            {
                sqliteConnection.Open();
                int iddel = Convert.ToInt32(StipsId.Text);
                using (SqliteCommand command = new SqliteCommand($"Delete FROM Scholarship WHERE StipId = {iddel}", sqliteConnection))
                {

                    command.ExecuteNonQuery();
                }

                sqliteConnection.Close();
                await App.Current.MainPage.DisplayAlert("Attention", "Delete", "Ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Attention", ex.Message, "Ok");
                throw;
            }
        }

    }
}
