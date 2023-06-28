using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Xml;

namespace Jeopardy_winForms
{
    public partial class MainForm : Form
    {
        private void ConnectQuestionButtons()
        {
            foreach(Control button in Controls)
                if(button.Name.StartsWith("buttonQuestion"))
                    button.Click += ButtonQuestion_Click;
        }
        private void UpdateLabelNames(XmlNodeList categories)
        {
            for (int i = 0; i < categories.Count; i++)
            {
                string categoryName = categories[i].Attributes["name"].Value;

                string labelName = "labelCat" + (i + 1).ToString();
                Label categoryLabel = Controls.Find(labelName, true).FirstOrDefault() as Label;

                categoryLabel.Text = categoryName;
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            var config = new XmlDocument();
            config.Load("save/config.xml");
            var categories = config.SelectNodes("jeopardy/category");
            CustomElements.CreateField(config, new Size(200, 100), new Point(9, 12), Controls);
            ConnectQuestionButtons();
            UpdateLabelNames(categories);
            UpdateStandings();

            var properties = IPGlobalProperties.GetIPGlobalProperties();
            var connections = properties.GetActiveTcpConnections();

            // Iterate through all connections with port 50000 (Game port)
            foreach (var t in connections.ToList().FindAll(connection => connection.RemoteEndPoint.Port == 50000))
                MessageBox.Show("obama");
        }

        public void RecalculateSizesPositions()
        {
            buttonSettings.Location = new Point(Size.Width - 128, 9);
            listViewStandings.Location = new Point(buttonSettings.Location.X - 100, buttonSettings.Location.Y + 106);
        }

        public void MainForm_Resize(object sender, EventArgs e)
        {
            RecalculateSizesPositions();
        }

        public MainForm()
        {
            Load += MainForm_Load;
            Resize += MainForm_Resize;
            InitializeComponent();
        }

        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
            UpdateSettings();
        }
        private void ButtonQuestion_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            int categoryNumber = int.Parse(button.Name[button.Name.Length - 3].ToString());
            int questionNumber = int.Parse(button.Name[button.Name.Length - 1].ToString());
            var question = new QuestionForm(categoryNumber, questionNumber);
            question.ShowDialog();
            if(BackgroundImage != null)
                question.BackgroundImage.Dispose();
        }

        public void UpdateStandings()
        {
            listViewStandings.Items.Clear();
            var config = new XmlDocument();
            config.Load("save/config.xml");
            var players = config.SelectSingleNode("jeopardy/players");
            foreach(XmlNode player in players)
            {
                var playerStrings = new string[2];
                playerStrings[0] = player.SelectSingleNode("name").InnerText;
                playerStrings[1] = player.SelectSingleNode("score").InnerText;
                var tablePlayer = new ListViewItem(playerStrings);
                listViewStandings.Items.Add(tablePlayer);
            }
        }
        private void UpdateSettings()
        {
            var config = new XmlDocument();
            config.Load("save/config.xml");
            var categories = config.SelectNodes("jeopardy/category");
            UpdateLabelNames(categories);
            UpdateStandings();
        }
    }
}