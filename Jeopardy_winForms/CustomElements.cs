using System.Diagnostics;
using System.Xml;

namespace Jeopardy_winForms
{
    public class CustomElements
    {
        public static void SetStandardBgSettings()
        {
        
        }
        public static void CreateField(XmlDocument config, Size elementSize, Point startLocation, Control.ControlCollection controls)
        {
            XmlNodeList categories = config.SelectNodes("jeopardy/category");

            // Create labels and add to form
            int x = startLocation.X;
            for (int i = 0; i < categories.Count; i++)
            {
                Label label = new Label();
                label.Text = categories[i].Attributes["name"].Value;
                label.Size = elementSize;
                label.Location = new Point(x, startLocation.Y);
                label.Font = new Font(label.Font.FontFamily, elementSize.Width / 10, FontStyle.Regular);
                label.Name = "labelCat" + (i + 1);
                label.TextAlign = ContentAlignment.MiddleCenter;

                controls.Add(label);
                x += elementSize.Width;
            }

            // Create buttons and add to form
            x = startLocation.X;
            for (int i = 0; i < categories.Count; i++)
            {
                int y = startLocation.Y + elementSize.Height;
                XmlNodeList questions = categories[i].SelectNodes("question");
                for (int j = 0; j < questions.Count; j++)
                {
                    Button button = new Button();
                    button.Text = questions[j].Attributes["value"].Value;
                    button.Location = new Point(x, y);
                    button.Size = elementSize;
                    button.Font = new Font(button.Font.FontFamily, 20, FontStyle.Regular);
                    button.Name = "buttonQuestion_" + i + "_" + j;

                    controls.Add(button);
                    y += elementSize.Height;
                }
                x += elementSize.Width;
            }
        }
    }
}