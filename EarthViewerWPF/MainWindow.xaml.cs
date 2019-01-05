using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Threading;

namespace EarthViewerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Image height. 
        private static int imageWidth = 7978;
        private static int imageHeight = 3987;

        // Mouse Stimulation Variables.
        private bool isMouseDown;
        private Point startPoint;
        private double rotationSpeed = 1;

        // Various Fields.
        private List<LocationName> locationName;
        private List<LocationName> continentName;
        private double angleBuffer = 0d;
        private MediaPlayer mplayer;
        private static string userName
        {
            get { return Launcher.Username; }
        }

        // Fields for screen transitions. 
        private bool isSettingsClicked;
        private bool isGamesClicked;
        private bool isHighScoresClicked;
        private bool isSettingsResetClicked;
        private bool isExitClicked;
        private bool isSkipClicked; 

        // Country Retrieve Variables. 
        private string countryName = "";
        private string capital = "";
        private string language = "";
        private string population = "";
        private string area = "";
        private string currency = "";
        private string gdp = "";
        private string religion = "";

        // SQL connection strings 
        private static string highScoresConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=Resources\Databases\userAccounts.mdb";
        private static string countriesConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=Resources\Databases\Countries.accdb";

        // Game Variables. 
        private string[] gameOneList = new string[] { "Austria", "Belgium", "Bulgaria", "Croatia", "Czech Republic", "Denmark", 
            "Estonia", "Finland", "France", "Germany", "Greece", "Hungary", "Iceland", "Ireland", "Italy", 
            "Netherlands", "Norway", "Poland", "Portugal", "Russia", "Spain", "Sweden", "Switzerland", 
            "Turkey", "Ukraine", "United Kingdom", "Canada", "USA", "China", "Australia", "Japan", "South Korea", "India"};
        private string[] gameTwoList = new string[] { "North America", "South America", "Europe", "Africa", "Asia", "Oceania", "Atlantic", "Pacific", "Arctic", "Indian" };
        private string[,] gameThreeList = new string[,]
        {
            {"Big Ben", "United Kingdom"}, 
            {"Blue Domed Church", "Greece"}, 
            {"Eiffel Tower", "France"}, 
            {"Great Wall of China", "China"},
            {"Tower of Pisa", "Italy"},
            {"Statue of Liberty", "USA"},
            {"St Basil Cathedral", "Russia"},
            {"Taj Mahal", "India"},
            {"Uluru", "Australia"},
            {"Mount Fuji", "Japan"},
            {"Stonehenge", "United Kingdom"},
            {"Capitol Hill", "USA"},
            {"Grand Canyon", "USA"},
            {"Chichen Itza", "Mexico"},
            {"Inukshuk", "Canada"},
            {"Opera House", "Australia"},
            {"Forbidden City", "China"},
            {"Tower Bridge", "United Kingdom"},
            {"Millau Bridge", "France"},
            {"Empire State Building", "USA"},
            {"Sacré Coeur", "France"}
        };

        private string placeName; 
        private Boolean gameStatus = false;
        private string randomSelect;
        private DispatcherTimer timer = new DispatcherTimer();
        private static int timeLimit = 60; // edit this value for the game time limit. 
        private int time = timeLimit;
        private MediaPlayer tenSecTimer = new MediaPlayer();
        private int skips = 0; 

        // Game Score Variables. 
        private string gameType = "";
        private int Score;
        private int localCountryScore = 0;
        private int localContinentScore = 0;
        private int localPlacesScore = 0; 
        private int dbScore;
        private string player1Val = "";
        private string score1Val = "";
        private string player2Val = "";
        private string score2Val = "";
        private string player3Val = "";
        private string score3Val = ""; 

        public MainWindow()
        {
            InitializeComponent();

            // Creates the list for all countries using the LocationName class, 
            // providing a name and its pixel location along with of the hit box. 
            this.locationName = new List<LocationName>();
            this.locationName.Add(new LocationName() { Name = "Austria", Bound = new Rect(4277, 888, 74, 34) });
            this.locationName.Add(new LocationName() { Name = "Belgium", Bound = new Rect(4070, 822, 47, 34) });
            this.locationName.Add(new LocationName() { Name = "Bulgaria", Bound = new Rect(4497, 991, 106, 50) });
            this.locationName.Add(new LocationName() { Name = "Croatia", Bound = new Rect(4337, 941, 67, 18) });
            this.locationName.Add(new LocationName() { Name = "Croatia", Bound = new Rect(4301, 935, 49, 44) });
            this.locationName.Add(new LocationName() { Name = "Czech Republic", Bound = new Rect(4282, 838, 102, 36) });
            this.locationName.Add(new LocationName() { Name = "Denmark", Bound = new Rect(4167, 679, 96, 65) });
            this.locationName.Add(new LocationName() { Name = "Denmark", Bound = new Rect(2847, 129, 550, 331) });
            this.locationName.Add(new LocationName() { Name = "Estonia", Bound = new Rect(4518, 638, 80, 41) });
            this.locationName.Add(new LocationName() { Name = "Finland", Bound = new Rect(4492, 563, 62, 51) });
            this.locationName.Add(new LocationName() { Name = "Finland", Bound = new Rect(4541, 438, 105, 160) });
            this.locationName.Add(new LocationName() { Name = "France", Bound = new Rect(3965, 868, 152, 125) });
            this.locationName.Add(new LocationName() { Name = "Germany", Bound = new Rect(4152, 773, 111, 123) });
            this.locationName.Add(new LocationName() { Name = "Greece", Bound = new Rect(4451, 1059, 139, 125) });
            this.locationName.Add(new LocationName() { Name = "Hungary", Bound = new Rect(4364, 903, 86, 30) });
            this.locationName.Add(new LocationName() { Name = "Iceland", Bound = new Rect(3466, 485, 220, 70) });
            this.locationName.Add(new LocationName() { Name = "Ireland", Bound = new Rect(3753, 755, 98, 65) });
            this.locationName.Add(new LocationName() { Name = "Italy", Bound = new Rect(4184, 941, 115, 41) });
            this.locationName.Add(new LocationName() { Name = "Italy", Bound = new Rect(4246, 981, 48, 64) });
            this.locationName.Add(new LocationName() { Name = "Italy", Bound = new Rect(4277, 1027, 105, 123) });
            this.locationName.Add(new LocationName() { Name = "Netherlands", Bound = new Rect(4076, 773, 67, 48) });
            this.locationName.Add(new LocationName() { Name = "Norway", Bound = new Rect(4102, 549, 141, 123) });
            this.locationName.Add(new LocationName() { Name = "Poland", Bound = new Rect(4328, 759, 168, 82) });
            this.locationName.Add(new LocationName() { Name = "Portugal", Bound = new Rect(3794, 1031, 35, 103) });
            this.locationName.Add(new LocationName() { Name = "Russia", Bound = new Rect(4696, 241, 3277, 556) });
            this.locationName.Add(new LocationName() { Name = "Russia", Bound = new Rect(5066, 822, 160, 158) });
            this.locationName.Add(new LocationName() { Name = "Spain", Bound = new Rect(3841, 995, 147, 146) });
            this.locationName.Add(new LocationName() { Name = "Sweden", Bound = new Rect(4264, 545, 130, 183) });
            this.locationName.Add(new LocationName() { Name = "Sweden", Bound = new Rect(4355, 459, 138, 71) });
            this.locationName.Add(new LocationName() { Name = "Switzerland", Bound = new Rect(4134, 907, 77, 31) });
            this.locationName.Add(new LocationName() { Name = "Turkey", Bound = new Rect(4590, 1043, 373, 86) });
            this.locationName.Add(new LocationName() { Name = "Ukraine", Bound = new Rect(4520, 812, 312, 104) });
            this.locationName.Add(new LocationName() { Name = "United Kingdom", Bound = new Rect(3857, 650, 164, 194) });
            this.locationName.Add(new LocationName() { Name = "Canada", Bound = new Rect(864, 114, 1947, 775) });
            this.locationName.Add(new LocationName() { Name = "USA", Bound = new Rect(1215, 892, 1211, 373) });
            this.locationName.Add(new LocationName() { Name = "USA", Bound = new Rect(345, 391, 508, 238) });
            this.locationName.Add(new LocationName() { Name = "China", Bound = new Rect(5760, 1020, 856, 288) });
            this.locationName.Add(new LocationName() { Name = "China", Bound = new Rect(6186, 1331, 394, 118) });
            this.locationName.Add(new LocationName() { Name = "China", Bound = new Rect(6641, 830, 219, 193) });
            this.locationName.Add(new LocationName() { Name = "Australia", Bound = new Rect(6502, 2226, 878, 705) });
            this.locationName.Add(new LocationName() { Name = "Japan", Bound = new Rect(7097, 953, 130, 82) });
            this.locationName.Add(new LocationName() { Name = "Japan", Bound = new Rect(7092, 1040, 52, 146) });
            this.locationName.Add(new LocationName() { Name = "Japan", Bound = new Rect(7022, 1126, 67, 68) });
            this.locationName.Add(new LocationName() { Name = "Japan", Bound = new Rect(6913, 1170, 11, 42) });
            this.locationName.Add(new LocationName() { Name = "Japan", Bound = new Rect(6867, 1195, 44, 73) });
            this.locationName.Add(new LocationName() { Name = "South Korea", Bound = new Rect(6800, 1117, 63, 76) });
            this.locationName.Add(new LocationName() { Name = "India", Bound = new Rect(5603, 1483, 156, 287) });
            this.locationName.Add(new LocationName() { Name = "India", Bound = new Rect(5560, 1362, 380, 110) });
            this.locationName.Add(new LocationName() { Name = "India", Bound = new Rect(5630, 1174, 167, 185) });
            this.locationName.Add(new LocationName() { Name = "Mexico", Bound = new Rect(1400, 1268, 156, 184) });
            this.locationName.Add(new LocationName() { Name = "Mexico", Bound = new Rect(1563, 1380, 286, 231) });
            this.locationName.Add(new LocationName() { Name = "Mexico", Bound = new Rect(1852, 1549, 109, 55) });
            this.locationName.Add(new LocationName() { Name = "Mexico", Bound = new Rect(1967, 1483, 88, 76) });

            // Separate list also using the LocationName class instead being used for the continents game
            this.continentName = new List<LocationName>();
            this.continentName.Add(new LocationName() { Name = "North America", Bound = new Rect(277, 310, 2438, 1318) });
            this.continentName.Add(new LocationName() { Name = "South America", Bound = new Rect(2171, 1637, 1054, 1577) });
            this.continentName.Add(new LocationName() { Name = "Europe", Bound = new Rect(3456, 383, 1301, 779) });
            this.continentName.Add(new LocationName() { Name = "Africa", Bound = new Rect(3638, 1686, 1499, 1058) });
            this.continentName.Add(new LocationName() { Name = "Africa", Bound = new Rect(3605, 1180, 1185, 503) });
            this.continentName.Add(new LocationName() { Name = "Asia", Bound = new Rect(4797, 264, 3181, 1404) });
            this.continentName.Add(new LocationName() { Name = "Oceania", Bound = new Rect(6089, 1682, 1889, 1326) });
            this.continentName.Add(new LocationName() { Name = "Pacific", Bound = new Rect(0, 1774, 2098, 1546) });
            this.continentName.Add(new LocationName() { Name = "Pacific", Bound = new Rect(0, 827, 1119, 944) });
            this.continentName.Add(new LocationName() { Name = "Pacific", Bound = new Rect(7269, 848, 709, 1144) });
            this.continentName.Add(new LocationName() { Name = "Atlantic", Bound = new Rect(2485, 1018, 1081, 624) });
            this.continentName.Add(new LocationName() { Name = "Atlantic", Bound = new Rect(2827, 646, 865, 370) });
            this.continentName.Add(new LocationName() { Name = "Atlantic", Bound = new Rect(3227, 2051, 1003, 1070) });
            this.continentName.Add(new LocationName() { Name = "Atlantic", Bound = new Rect(2922, 1655, 692, 366) });
            this.continentName.Add(new LocationName() { Name = "Indian", Bound = new Rect(5132, 1670, 1297, 1539) });
            this.continentName.Add(new LocationName() { Name = "Arctic", Bound = new Rect(0, 0, 7978, 95) });

            Touch.FrameReported += new TouchFrameEventHandler(FrameReported);

            Uri tenUri = new Uri("Resources/Sounds/SFX/timer_10.wav", UriKind.Relative);
            tenSecTimer.Open(tenUri);

            usernameLabel.Content = userName;
            scoreLabel1.Content = Score;

            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(timer_Tick);
            timerText.Text = timeLimit + "s";
        }

        /// <summary>
        /// Handles the live display of the timer countdown and when the timer reaches zero. 
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            timerText.Text = time--.ToString() + "s";

            if (time <= 10)
            {
                tenSecTimer.Play();
            }
            if (time <= 0)
            {
                timer.Stop();

                GameStop(Score);
                gReset();
                gArrange();
            }
        }

        /// <summary>
        /// Method that is called when the timer reaches zero. 
        /// Also calls for CheckHighScore and updates the recent high score text. 
        /// Then resets the UI. 
        /// </summary>
        private void GameStop(int score)
        {
            gameStatus = false;
            score = Score;
            skips = 0; 

            CheckForHighScore();
            if (score > localCountryScore && gameType.Equals("Countries"))
            {
                localCountryScore = score;
                recentScore1.Content = "Your Recent High Score: " + localCountryScore;
            }
            else if (score > localContinentScore && gameType.Equals("Continents"))
            {
                localContinentScore = score;
                game2RecentScore.Content = "Your Recent High Score: " + localContinentScore;
            }
            else if (score > localPlacesScore && gameType.Equals("Places"))
                {
                localPlacesScore = score; 
                game3RecentScore.Content = "Your Recent High Score: " + localPlacesScore; 
            }

            timer.Stop();
            countryGText.Text = "Location";
            timerText.Text = timeLimit + "s";
            time = timeLimit;
            Score = 0;
            scoreLabel1.Content = Score;
        }

        /// <summary>
        /// SQL SELECT query to read the database high score and if the achieved score is higher, 
        /// updates the database entry with a UPDATE query.
        /// </summary>
        private void CheckForHighScore()
        {
            string queryString = "SELECT Score FROM highScores WHERE GameID = '" + gameType + "'";
            string connectionString = highScoresConnectionString;
            string s = "";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    OleDbCommand command = new OleDbCommand(queryString, connection);
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        s = reader.GetValue(0).ToString();
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to database:\n" + ex.Message);
            }

            if (Score > (dbScore = Convert.ToInt32(s)))
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                using (var command = connection.CreateCommand())
                {
                    connection.Open();

                    command.CommandText = "UPDATE highScores SET Score = @score,Username = @username WHERE GameID = @gameID";
                    command.Parameters.AddWithValue("@score", Score);
                    command.Parameters.AddWithValue("@username", userName);
                    command.Parameters.AddWithValue("@gameID", gameType);

                    try
                    {
                        command.ExecuteNonQuery();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Error connecting to database \n" + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// The event handler for touch and click manipulation. 
        /// Rotation only occurs while the angleBuffer is greater than zero (significant rotation)
        /// in order to avoid screen slash. 
        /// </summary>
        private void OnDeltaChange(object sender, ManipulationDeltaEventArgs e)
        {
            this.scaleTransform.ScaleX *= e.DeltaManipulation.Scale.X;
            this.scaleTransform.ScaleY *= e.DeltaManipulation.Scale.Y;
            this.scaleTransform.ScaleZ *= e.DeltaManipulation.Scale.X;

            this.angleBuffer++;
            // To avoid screen slash and to save a few CPU resource, do not rotate the scene whenever a manipulation event occurs.
            // Only rotate the scene if the angle cumulated enough.
            if (angleBuffer >= 0)
            {
                Vector delta = e.DeltaManipulation.Translation;
                this.RotateEarth(delta);
            }
            e.Handled = true;
        }

        /// <summary>
        /// Rotate method combining the manipulation event handler and mouse event handler. 
        /// </summary>
        private void RotateEarth(Vector delta)
        {
            if (delta.X != 0 || delta.Y != 0)
            {
                // Convert delta to a 3D vector.
                Vector3D vOriginal = new Vector3D(-delta.X, delta.Y, 0d);
                Vector3D vSecondary = new Vector3D(0, 0, 1);

                // Find a vector that is perpendicular with the delta vector on the XY surface. This will be the rotation axis.
                Vector3D perpendicular = Vector3D.CrossProduct(vOriginal, vSecondary);
                RotateTransform3D rotate = new RotateTransform3D();

                // The QuaternionRotation3D allows you to easily specify a rotation axis.
                QuaternionRotation3D quaternionRotation = new QuaternionRotation3D();
                quaternionRotation.Quaternion = new Quaternion(perpendicular, rotationSpeed);
                rotate.Rotation = quaternionRotation; this.transformGroup.Children.Add(rotate);
                this.angleBuffer = 0;
            }
        }

        /// <summary>
        /// Resets the rotation of the earth with a mouse button event. 
        /// </summary>
        private void RotationResetButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        /// <summary>
        /// Hit test method that invoked by both touch event handler and mouse event handler.
        /// Obtains a 3 dimensional point from where the user clicks and converts this to a location
        /// on the texture. Finally checks if this is within a LocationName bound. 
        /// Two hit tests depending on which game is active. 
        /// </summary>
        private void GetClickLocation(Point point)
        {
            VisualTreeHelper.HitTest(this.viewport, null, new HitTestResultCallback(target =>
            {
                RayMeshGeometry3DHitTestResult result = target as RayMeshGeometry3DHitTestResult;
                if (result != null)
                {
                    // Calculate the hit point using barycentric coordinates formula:
                    // p = p1 * w1 + p2 * w2 + p3 * w3.
                    Point p1 = result.MeshHit.TextureCoordinates[result.VertexIndex1];
                    Point p2 = result.MeshHit.TextureCoordinates[result.VertexIndex2];
                    Point p3 = result.MeshHit.TextureCoordinates[result.VertexIndex3];
                    double hitX = p1.X * result.VertexWeight1 + p2.X * result.VertexWeight2 + p3.X * result.VertexWeight3;
                    double hitY = p1.Y * result.VertexWeight1 + p2.Y * result.VertexWeight2 + p3.Y * result.VertexWeight3;
                    Point pointHit = new Point(hitX * imageWidth, hitY * imageHeight);                    

                    if (gameType == "Continents")
                    {
                        foreach (LocationName continentName in this.continentName)
                        {
                            if (continentName.Bound.Contains(pointHit))
                            {
                                countryName = continentName.Name;
                                if (gameStatus == true && countryName == randomSelect)
                                {
                                    Score++;
                                    scoreLabel1.Content = Score;
                                    ContinentGame();
                                }
                                return HitTestResultBehavior.Stop;
                            }                             
                        }
                    }

                    else if (gameType == "Places")
                    {
                        foreach (LocationName locationName in this.locationName)
                        {
                            if (locationName.Bound.Contains(pointHit))
                            {
                                countryName = locationName.Name;

                                if (gameStatus == true && countryName == randomSelect)
                                {
                                    Score++;
                                    scoreLabel1.Content = Score;
                                    PlacesGame(); 
                                }
                                return HitTestResultBehavior.Stop; 
                            }
                        }
                    }

                    else
                    {
                        foreach (LocationName locationName in this.locationName)
                        {
                            if (locationName.Bound.Contains(pointHit))
                            {
                                countryName = locationName.Name;
                                GetCountryData();

                                if (gameStatus == true && countryName == randomSelect)
                                {
                                    Score++;
                                    scoreLabel1.Content = Score;
                                    CountryGame();
                                }
                                return HitTestResultBehavior.Stop;
                            }
                        }
                    }  
                }
                return HitTestResultBehavior.Continue;
            }), new PointHitTestParameters(point));
        }

        /// <summary>
        /// Handles raw touch events.
        /// </summary>
        void FrameReported(object sender, TouchFrameEventArgs e)
        {
            var touchPoints = e.GetTouchPoints(this.viewport);
            if (touchPoints.Count >= 2 && touchPoints[0].Action == TouchAction.Up)
            {
                this.TouchLine.X1 = touchPoints[0].Position.X;
                this.TouchLine.X2 = touchPoints[1].Position.X;
                this.TouchLine.Y1 = touchPoints[0].Position.Y;
                this.TouchLine.Y2 = touchPoints[1].Position.Y;
            }
        }

        /// <summary>
        /// Secondary handler for touch input. 
        /// </summary>
        private void OnTouch(object sender, TouchEventArgs e)
        {
            GetClickLocation(e.GetTouchPoint(this.viewport).Position);
        }

        // Event handler for mouse input. 
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.isMouseDown = true;
            this.startPoint = e.GetPosition(this.viewport);
        }

        /// <summary>
        /// Secondary handler for mouse input. 
        /// </summary>
        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isMouseDown)
            {
                this.angleBuffer++;
                if (angleBuffer >= 0)
                {
                    Point currentPoint = e.GetPosition(this.viewport);
                    Vector delta = new Vector(currentPoint.X - this.startPoint.X, currentPoint.Y - this.startPoint.Y);
                    RotateEarth(delta);
                }
            }
        }

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.isMouseDown = false;
            this.GetClickLocation(e.GetPosition(this.viewport));
        }

        /// <summary>
        /// Zoom method: 
        /// Assigns the % zoom per tick value to delta depending on the degree of wheel rotation, 
        /// e.g. 20% increase or 20% decrease. 
        /// </summary>
        private void Zoom(object sender, MouseWheelEventArgs e)
        {
            double delta = e.Delta > 0 ? 1.2 : 0.8;

            this.scaleTransform.ScaleX *= delta;
            this.scaleTransform.ScaleY *= delta;
            this.scaleTransform.ScaleZ *= delta;
        }

        private void GetCountryData()
        {
            string queryString = "SELECT * FROM countryDb WHERE countryName = '" + countryName + "'";
            string connectionString = countriesConnectionString;

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    OleDbCommand command = new OleDbCommand(queryString, connection);
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        capital = reader.GetValue(2).ToString();
                        language = reader.GetValue(3).ToString();
                        population = reader.GetValue(4).ToString();
                        area = reader.GetValue(5).ToString();
                        gdp = reader.GetValue(6).ToString();
                        currency = reader.GetValue(7).ToString();
                        religion = reader.GetValue(9).ToString();
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to database. \n " + ex.Message);
            }
            DisplayCountryData();
        }

        /// <summary>
        /// Updates the information in the high scores table. 
        /// </summary>
        private void hUpdate()
        {
            string queryString = "SELECT Username,Score FROM highScores WHERE GameID = 'Countries'";
            string queryString2 = "SELECT Username,Score FROM highScores WHERE GameID = 'Continents'";
            string queryString3 = "SELECT Username,Score FROM highScores WHERE GameID = 'Places'"; 
            string connectionString = highScoresConnectionString;

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    OleDbCommand command = new OleDbCommand(queryString, connection);
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        score1Val = reader.GetValue(1).ToString();
                        player1Val = reader.GetValue(0).ToString();
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to database:\n" + ex.Message);
            }

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    OleDbCommand command = new OleDbCommand(queryString2, connection);
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        score2Val = reader.GetValue(1).ToString();
                        player2Val = reader.GetValue(0).ToString();
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connection to database:\n" + ex.Message);
            }

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    OleDbCommand command = new OleDbCommand(queryString3, connection);
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        score3Val = reader.GetValue(1).ToString();
                        player3Val = reader.GetValue(0).ToString(); 
                    }
                    reader.Close(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connection to database:\n" + ex.Message); 
            }
        }

        private void DisplayCountryData()
        {
            countryText.Content = countryName;
            capitalText.Content = capital;
            languageText.Content = language;
            populationText.Content = population;
            areaText.Content = area + "km²";
            gdpText.Content = gdp;
            currencyText.Content = currency;
            religionText.Content = religion;
        }

        private void LoadAnthemContent(string uriPath)
        {

        }

        #region Transition Region
        private void settingsIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isSettingsClicked = true;
        }

        /// <summary>
        /// Begins the settings arrange methods and flushes.
        /// Because WPF does not support click events for images. 
        /// </summary>
        private void settingsIcon_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (isSettingsClicked == true)
            {
                gReset();
                hReset();
                sReset();
                sArrange();
            }
        }

        private void settingsReset_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isSettingsResetClicked = true;
        }

        private void settingsReset_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (isSettingsResetClicked == true)
            {
                sReset();
                hReset();
                gReset();
            }
        }

        private void gamesIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isGamesClicked = true;
        }

        private void gamesIcon_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (isGamesClicked == true)
            {
                sReset();
                hReset();
                gArrange();
            }
        }

        private void highScoresIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isHighScoresClicked = true;
        }

        private void highScoresIcon_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (isHighScoresClicked)
            {
                sReset();
                gReset();
                hUpdate();
                hArrange();
            }
        }

        private void powerBttn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isExitClicked = true;
        }

        private void powerBttn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (isExitClicked == true)
            {
                if (MessageBox.Show("are you sure you want to log out?", "Log Out", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    this.Close();
                    Launcher launcher = new Launcher();
                    launcher.Show();
                }
            }
        }

        /// <summary>
        /// The arrange and reset methods. 
        /// </summary>
        private void sArrange()
        {
            bottomBarContainer.Height = 165;
            textureComboBox.Visibility = Visibility.Visible;
            RotationResetButton.Visibility = Visibility.Visible;
            ControlCheckBox.Visibility = Visibility.Visible;
            settingsReset.Visibility = Visibility.Visible;
            settingsBg.Visibility = Visibility.Visible;
        }
        private void sReset()
        {
            bottomBarContainer.Height = 25;
            textureComboBox.Visibility = Visibility.Hidden;
            RotationResetButton.Visibility = Visibility.Hidden;
            ControlCheckBox.Visibility = Visibility.Hidden;
            settingsReset.Visibility = Visibility.Hidden;
            settingsBg.Visibility = Visibility.Hidden;

        }

        private void gArrange()
        {
            bottomBarContainer.Height = 165;
            settingsReset.Visibility = Visibility.Visible;
            gameButton.Visibility = Visibility.Visible;
            countryGText.Visibility = Visibility.Visible;
            timerText.Visibility = Visibility.Visible;
            recentScore1.Visibility = Visibility.Visible;
            scoreLabel1.Visibility = Visibility.Visible;
            game2Button.Visibility = Visibility.Visible;
            game2RecentScore.Visibility = Visibility.Visible;
            gamesBg.Visibility = Visibility.Visible;
            game3Button.Visibility = Visibility.Visible;
            game3RecentScore.Visibility = Visibility.Visible;
            

            scoreLabel1.Content = Score;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void RotationResetButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void gReset()
        {
            bottomBarContainer.Height = 25;
            gameButton.Visibility = Visibility.Hidden;
            countryGText.Visibility = Visibility.Hidden;
            timerText.Visibility = Visibility.Hidden;
            settingsReset.Visibility = Visibility.Hidden;
            recentScore1.Visibility = Visibility.Hidden;
            scoreLabel1.Visibility = Visibility.Hidden;
            game2Button.Visibility = Visibility.Hidden;
            game2RecentScore.Visibility = Visibility.Hidden;
            gamesBg.Visibility = Visibility.Hidden;
            game3Button.Visibility = Visibility.Hidden;
            game3RecentScore.Visibility = Visibility.Hidden;
            placeNameImage.Visibility = Visibility.Hidden;
            skipImage.Visibility = Visibility.Hidden;

            if (timer.IsEnabled)
            {
                timer.Stop(); 
                countryGText.Text = "Location";
                GameStop(Score);
            }            
        }

        private void hArrange()
        {
            bottomBarContainer.Height = 200;
            settingsReset_Copy.Visibility = Visibility.Visible;
            leftSideDivider.Visibility = Visibility.Visible;
            rightSideDivider.Visibility = Visibility.Visible;
            gameModeLabelHs.Visibility = Visibility.Visible;
            usernameLabelHs.Visibility = Visibility.Visible;
            scoreLabelHs.Visibility = Visibility.Visible;
            gameMode1.Visibility = Visibility.Visible;
            gamemode2.Visibility = Visibility.Visible;
            gameMode3.Visibility = Visibility.Visible;
            player1.Visibility = Visibility.Visible;
            player2.Visibility = Visibility.Visible;
            player3.Visibility = Visibility.Visible;
            score1.Visibility = Visibility.Visible;
            score2.Visibility = Visibility.Visible;
            score3.Visibility = Visibility.Visible;
            highScoresBg.Visibility = Visibility.Visible;
            player1.Content = player1Val;
            score1.Content = score1Val;
            player2.Content = player2Val;
            score2.Content = score2Val;
            player3.Content = player3Val;
            score3.Content = score3Val; 
        }

        private void hReset()
        {
            bottomBarContainer.Height = 25;
            settingsReset_Copy.Visibility = Visibility.Hidden;
            leftSideDivider.Visibility = Visibility.Hidden;
            rightSideDivider.Visibility = Visibility.Hidden;
            gameModeLabelHs.Visibility = Visibility.Hidden;
            usernameLabelHs.Visibility = Visibility.Hidden;
            scoreLabelHs.Visibility = Visibility.Hidden;
            gameMode1.Visibility = Visibility.Hidden;
            gamemode2.Visibility = Visibility.Hidden;
            gameMode3.Visibility = Visibility.Hidden;
            player1.Visibility = Visibility.Hidden;
            player2.Visibility = Visibility.Hidden;
            player3.Visibility = Visibility.Hidden;
            score1.Visibility = Visibility.Hidden;
            score2.Visibility = Visibility.Hidden;
            score3.Visibility = Visibility.Hidden;
            highScoresBg.Visibility = Visibility.Hidden;
        }
        #endregion

        private void anthemButton_Click(object sender, RoutedEventArgs e)
        {
            mplayer = new MediaPlayer();
            Uri uri = new Uri("Resources/Sounds/Anthems/" + countryName + ".wav", UriKind.Relative);
            mplayer.Open(uri);
            mplayer.Play();
        }

        private void anthemButtonStop_Click(object sender, RoutedEventArgs e)
        {
            mplayer.Stop();
        }

        private void gameButton_Click(object sender, RoutedEventArgs e)
        {
            if (!timer.IsEnabled)
            {
                gameType = "Countries";
                timeLimit = 60; 
                OnGameStart(); 
                CountryGame();
            }
        }

        // Hover controls for increasing the size of the image. 
        private void placeNameImage_MouseEnter(object sender, MouseEventArgs e)
        {
            placeNameImage.Margin = new Thickness(434, 241, 0, 0);
            placeNameImage.Width = placeNameImage.Width + 300;
            placeNameImage.Height = placeNameImage.Height + 300;
        }
        // Hover controls for resetting the size of the image. 
        private void placeNameImage_MouseLeave(object sender, MouseEventArgs e)
        {
            placeNameImage.Margin = new Thickness(584, 541, 0, 0);
            placeNameImage.Width = placeNameImage.Width - 300;
            placeNameImage.Height = placeNameImage.Height - 300;
        }

        private void CountryGame()
        {
            Random rand = new Random();
            int i = rand.Next(0, 33);
            randomSelect = gameOneList[i];
            countryGText.Text = randomSelect;
            gameStatus = true;
        }

        private void game2Button_Click(object sender, RoutedEventArgs e)
        {
            if (!timer.IsEnabled)
            {
                gameType = "Continents";
                timeLimit = 60; 
                OnGameStart(); 
                ContinentGame();
            }
        }

        private void ContinentGame()
        {
            Random rand = new Random();
            int i = rand.Next(0, 10);
            randomSelect = gameTwoList[i];
            countryGText.Text = randomSelect;
            gameStatus = true;
        }
        
        private void OnGameStart()
        {
            Score = 0;
            scoreLabel1.Content = Score;
            timerText.Text = timeLimit + "s"; 
            timer.Start(); 
        }
    

        private void game3Button_Click(object sender, RoutedEventArgs e)
        {
            if (!timer.IsEnabled)
            {
                gameType = "Places";
                OnGameStart();
                PlacesGame(); 
                
            }
        }
        private void PlacesGame()
        {
            placeNameImage.Visibility = Visibility.Visible;
            skipImage.Visibility = Visibility.Visible; 
            
            Random rand = new Random();
            int i = rand.Next(0, 21);
            
            // Random select is Country the place is within. 
            randomSelect = gameThreeList[i, 1];

            // placeName is the place of interest. 
            placeName = gameThreeList[i, 0];

            placeNameImage.Source = new BitmapImage(new Uri("Resources/Images/" + placeName + ".jpg", UriKind.RelativeOrAbsolute));
            countryGText.Text = placeName;
           
            gameStatus = true;             
        }

        private void skipImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isSkipClicked = true; 
        }

        private void skipImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (isSkipClicked == true)
            {
                skips++;
                if (skips > 3 && Score > 0)
                {
                    Score--;
                }
                scoreLabel1.Content = Score;
                PlacesGame();                                  
            }
        }   
    }
}