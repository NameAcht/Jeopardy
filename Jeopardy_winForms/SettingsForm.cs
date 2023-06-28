using System.Xml;

namespace Jeopardy_winForms
{
    public partial class SettingsForm : Form
    {
        private void ConnectQuestionButtons()
        {
            foreach(var control in Controls)
            {
                var button = control as Button;
                if(!(button is null) && button.Name.StartsWith("buttonQuestion_"))
                    button.Click += buttonEditQuestion_Click;
            }
        }
        private void CreateCatEditElements(XmlDocument config, Size elementSize, Point startLocation)
        {
            XmlNodeList categories = config.SelectNodes("jeopardy/category");
            for (int i = 0; i < categories.Count; i++)
            {
                var textBox = new TextBox();
                textBox.Enabled = false;
                textBox.Size = elementSize;
                textBox.Location = new Point(startLocation.X + i * elementSize.Width, startLocation.Y);
                textBox.Name = "textBoxEditCat" + (i + 1);

                var button = new Button();
                button.Size = elementSize;
                button.Location = new Point(textBox.Location.X, textBox.Location.Y + 23);
                button.Text = "Edit Category Name";
                button.Name = "buttonEditCat" + (i + 1);
                button.Click += HandleEditEvent;
                textBox.KeyDown += HandleEditEvent;

                Controls.Add(button);
                Controls.Add(textBox);
            }
        }
        public void UpdatePlayerDisplay()
        {
            listBoxPlayers.Items.Clear();
            var config = new XmlDocument();
            config.Load("save/config.xml");
            var playerNameList = config.SelectNodes("jeopardy/players/player/name");
            foreach(XmlNode name in playerNameList)
                listBoxPlayers.Items.Add(name.InnerText);
        }
        public void Form2_Load(object sender, EventArgs e)
        {
            UpdatePlayerDisplay();
            var config = new XmlDocument();
            config.Load("save/config.xml");

            CustomElements.CreateField(config, new Size(140, 70), new Point(200, 100), Controls);
            CreateCatEditElements(config, new Size(140, 50), new Point(200, 25));
            ConnectQuestionButtons();
        }
        public SettingsForm()
        {
            Load += Form2_Load;
            InitializeComponent();
            textBoxAddPlayer.KeyDown += ButtonAddPlayer_Click;
        }

        private void ButtonAddPlayer_Click(object sender, EventArgs e)
        {
            if (sender is TextBox && (e as KeyEventArgs).KeyCode != Keys.Enter) return;
            if (textBoxAddPlayer.Text == "")
                return;

            var config = new XmlDocument();
            config.Load("save/config.xml");

            var playersNode = config.SelectSingleNode("jeopardy/players");
            var playerNode = config.CreateElement("player");
            var nameNode = config.CreateElement("name");
            
            nameNode.InnerText = textBoxAddPlayer.Text;
            playerNode.AppendChild(nameNode);
            var scoreNode = config.CreateElement("score");
            scoreNode.InnerText = "0";
            playerNode.AppendChild(scoreNode);
            playersNode.AppendChild(playerNode);
            textBoxAddPlayer.Clear();
            config.Save("save/config.xml");
            UpdatePlayerDisplay();
        }

        private void buttonDeletePlayer_Click(object sender, EventArgs e)
        {
            if(listBoxPlayers.SelectedItems.Count == 0) return;

            var result = MessageBox.Show("Are you sure you want to delete this player?\n" + listBoxPlayers.SelectedItem, "Delete Player", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                var config = new XmlDocument();
                config.Load("save/config.xml");
                var playersNode = config.SelectSingleNode("jeopardy/players");

                foreach(XmlNode playerNode in playersNode.ChildNodes)
                    if (playerNode.FirstChild.InnerText == listBoxPlayers.SelectedItem.ToString())
                    {
                        playersNode.RemoveChild(playerNode);
                        break;
                    }
                config.Save("save/config.xml");
            }
            UpdatePlayerDisplay();
        }

        private void TextBoxAddPlayer_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAddPlayer.Text.Length > 0)
                buttonAddPlayer.Enabled = true;
            else
                buttonAddPlayer.Enabled = false;
        }
        private void EditNameSave(int category)
        {
            // Find elements relevant for saving
            var textBox = Controls.Find("textBoxEditCat" + category, true).FirstOrDefault() as TextBox;
            var label = Controls.Find("labelCat" + category, true).FirstOrDefault() as Label;
            var button = Controls.Find("buttonEditCat" + category, true).FirstOrDefault() as Button;

            var config = new XmlDocument();
            config.Load("save/config.xml");
            
            if (textBox.Text != string.Empty)
            {
                var categories = config.SelectNodes("jeopardy/category");
                categories[category - 1].Attributes["name"].Value = textBox.Text;
                label.Text = textBox.Text;
            }
            button.Text = "Edit Category Name";
            textBox.Enabled = false;
            textBox.Clear();
            config.Save("save/config.xml");
        }

        private void HandleEditEvent(object sender, EventArgs e)
        {
            // Executes when this method is called via Enter key press
            if (sender is TextBox && (e as KeyEventArgs).KeyCode == Keys.Enter)
            {
                var textBox = (TextBox)sender;
                EditNameSave(int.Parse(textBox.Name[textBox.Name.Length - 1].ToString()));
                return;
            }
            else if (sender is TextBox)
                return;

            var button = sender as Button;
            int categoryNumber = int.Parse(button.Name[button.Name.Length - 1].ToString());

            // Finds corresponding TextBox to edit category name
            var editBox = Controls.Find("textBoxEditCat" + categoryNumber, true).FirstOrDefault() as TextBox;

            if (editBox.Enabled)
                EditNameSave(int.Parse(editBox.Name[editBox.Name.Length - 1].ToString()));
            else
            {
                editBox.Enabled = true;
                editBox.Select();
                button.Text = "Save";
            }
        }
        private void buttonEditQuestion_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            int categoryNumber = int.Parse(button.Name[button.Name.Length - 3].ToString()) + 1;
            int questionNumber = int.Parse(button.Name[button.Name.Length - 1].ToString()) + 1;

            var qd = new QuestionDesigner(categoryNumber, questionNumber);
            qd.ShowDialog();
            if (qd.BackgroundImage != null)
                qd.BackgroundImage.Dispose();
        }
    }
}
