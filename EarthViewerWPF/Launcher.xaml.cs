using System;
using System.Data;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Media;

namespace EarthViewerWPF
{
    /// <summary>
    /// Interaction logic for Launcher.xaml
    /// </summary>
    public partial class Launcher : Window
    {
        //private string username;
        private string password;
        private string regPassword;
        private string dbPassword;
        private bool isLoginSuccess = false;
        private string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= Resources\Databases\userAccounts.mdb";
        MainWindow eViewer; 
        private static string username;
        public static string Username
        {
            get { return username; }
            set { username = value; }
        }

        public Launcher()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Log in button, assigns values to username and password to then start the login method.
        /// Then checks for a correct username and password with appropriate responses.
        /// </summary>
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            username = usernameTextbox.Text;
            password = passwordTextbox.Password;

            DoLogin();

            if (isLoginSuccess == true)
            {
                eViewer = new MainWindow();         
                this.Hide();
                eViewer.Show();
                passwordTextbox.Clear(); 
            }               

            else
            {
                MessageBox.Show("username or password incorrect");
                passwordTextbox.Clear();
            }
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            sArrange();
        }

        /// <summary>
        /// Complete register button. assigns a value to username and password to then launch register process. 
        /// </summary>
        private void registerButton1_Click(object sender, RoutedEventArgs e)
        {
            username = usernameTextbox.Text;
            password = passwordTextbox.Password;
            regPassword = regPasswordTextbox.Password;

            // Controls the red border around the password text boxes to indicate 
            // a non-matching password pair. 
            if (password != regPassword)
            {
                passwordTextbox.BorderBrush = new SolidColorBrush(Colors.Red);
                regPasswordTextbox.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else if (password == regPassword)
            {
                passwordTextbox.BorderBrush = null;
                regPasswordTextbox.BorderBrush = null;
            }

            DoRegister();
        }

        private void regCloseButton_Click(object sender, RoutedEventArgs e)
        {
            lArrange();
        }

        /// <summary>
        /// Login method.
        /// Creates an SQL query to select the password from the database. 
        /// </summary>
        private void DoLogin()
        {
            string queryString = "SELECT Password FROM userAccounts WHERE PersonID = '" + username + "' ";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    OleDbCommand command = new OleDbCommand(queryString, connection);
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        dbPassword = reader.GetValue(0).ToString();
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: \n" + ex.Message);
            }

            isLoginSuccess = (dbPassword == password) ? true : false;
        }

        /// <summary>
        /// Register method. 
        /// Creates an SQL query to insert new account information into the database. 
        /// </summary>
        private void DoRegister()
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = connectionString;

            OleDbCommand command = new OleDbCommand("INSERT into userAccounts (PersonID, UserName, [Password]) Values (@PersonID, @UserName, @Password)", connection);
            command.Connection = connection;

            connection.Open();

            if (password == regPassword && password != " " && username.Length > 0)
            {
                if (connection.State == ConnectionState.Open)
                {
                    command.Parameters.Add("@PersonID", OleDbType.VarChar).Value = username;
                    command.Parameters.Add("@Username", OleDbType.VarChar).Value = username;
                    command.Parameters.Add("@Password", OleDbType.VarChar).Value = password;

                    try
                    {
                        command.ExecuteNonQuery();
                        connection.Close();
                        lArrange();
                    }
                    catch (OleDbException)
                    {
                        MessageBox.Show("Error: \nThe username you entered already exists, please try a new one");
                        connection.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Sign up failed.", "Please try again");
                    usernameTextbox.Clear();
                    passwordTextbox.Clear();
                    regPasswordTextbox.Clear();
                }
            }
        }

        /// <summary>
        /// Arranges the form for register. 
        /// </summary>
        void sArrange()
        {
            regCloseButton.Visibility = Visibility.Visible;
            registerButton1.Visibility = Visibility.Visible;
            regPasswordLabel.Visibility = Visibility.Visible;
            regPasswordTextbox.Visibility = Visibility.Visible;

            loginButton.Visibility = Visibility.Hidden;
            registerButton.Visibility = Visibility.Hidden;

            accountLoginBg.Height = 248;
            usernameTextbox.Clear();
            passwordTextbox.Clear();

            header.Content = "Account Registration"; 

        }

        /// <summary>
        /// Arranges the form for login. 
        /// </summary>
        void lArrange()
        {
            regCloseButton.Visibility = Visibility.Hidden;
            registerButton1.Visibility = Visibility.Hidden;
            regPasswordLabel.Visibility = Visibility.Hidden;
            regPasswordTextbox.Visibility = Visibility.Hidden;

            loginButton.Visibility = Visibility.Visible;
            registerButton.Visibility = Visibility.Visible;

            accountLoginBg.Height = 174;
            usernameTextbox.Clear();
            usernameTextbox.BorderBrush = null;
            passwordTextbox.Clear();
            passwordTextbox.BorderBrush = null;
            regPasswordTextbox.Clear();
            regPasswordTextbox.BorderBrush = null;

            header.Content = "Account Login"; 
        } 
    }
}
