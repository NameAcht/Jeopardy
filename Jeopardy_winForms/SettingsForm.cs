using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                TextBox textBox = new TextBox();
                textBox.Enabled = false;
                textBox.Size = elementSize;
                textBox.Location = new Point(startLocation.X + i * elementSize.Width, startLocation.Y);
                textBox.Name = "textBoxEditCat" + (i + 1);

                Button button = new Button();
                button.Size = elementSize;
                button.Location = new Point(textBox.Location.X, textBox.Location.Y + 23);
                button.Text = "Edit Category Name";
                button.Name = "buttonEditCat" + (i + 1);
                button.Click += buttonEditCatName_Click;

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
            XmlDocument config = new XmlDocument();
            config.Load("save/config.xml");

            CustomElements.CreateField(config, new Size(140, 70), new Point(200, 100), Controls);
            CreateCatEditElements(config, new Size(140, 50), new Point(200, 25));
            ConnectQuestionButtons();
        }
        public SettingsForm()
        {
            Load += Form2_Load;
            InitializeComponent();
        }

        private void buttonAddPlayer_Click(object sender, EventArgs e)
        {
            // Don't add player if no text was given
            if (textBoxAddPlayer.Text == "")
                return;

            var config = new XmlDocument();
            config.Load("save/config.xml");

            // Get the parent node where the new player node will be added
            var playersNode = config.SelectSingleNode("jeopardy/players");

            // Create a new player node
            var playerNode = config.CreateElement("player");


            // Add the player's information as child nodes to the player node
            var nameNode = config.CreateElement("name");
            nameNode.InnerText = textBoxAddPlayer.Text;
            playerNode.AppendChild(nameNode);

            var scoreNode = config.CreateElement("score");
            scoreNode.InnerText = "0";
            playerNode.AppendChild(scoreNode);


            // Append the new player node to the players parent node
            playersNode.AppendChild(playerNode);

            // Clear playername textbox
            textBoxAddPlayer.Clear();

            config.Save("save/config.xml");

            UpdatePlayerDisplay();
        }

        private void buttonDeletePlayer_Click(object sender, EventArgs e)
        {
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

        private void textBoxAddPlayer_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAddPlayer.Text.Length > 0)
                buttonAddPlayer.Enabled = true;
            else
                buttonAddPlayer.Enabled = false;
        }
        private void buttonEditCatName_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            int categoryNumber = int.Parse(button.Name[button.Name.Length - 1].ToString());

            // This finds the corresponding text box to edit the category name
            var editBox = Controls.Find("textBoxEditCat" + categoryNumber, true).FirstOrDefault() as TextBox;

            // Same thing with the label
            var editLabel = Controls.Find("labelCat" + categoryNumber, true).FirstOrDefault() as Label;


            if (editBox.Enabled)
            {                
                XmlDocument config = new XmlDocument();
                config.Load("save/config.xml");
                if(editBox.Text != string.Empty)
                {
                    var categories = config.SelectNodes("jeopardy/category");
                    categories[categoryNumber - 1].Attributes["name"].Value = editBox.Text;
                    editLabel.Text = editBox.Text;
                }
                button.Text = "Edit Category Name";
                editBox.Enabled = false;
                editBox.Clear();

                config.Save("save/config.xml");
            }
            else
            {
                editBox.Enabled = true;
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
        }
    }
}
