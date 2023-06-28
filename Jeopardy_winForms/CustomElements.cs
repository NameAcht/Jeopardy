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

            // Create labels
            int x = startLocation.X;
            for (int i = 0; i < categories.Count; i++)
            {
                var label = new Label 
                {
                    Text = categories[i].Attributes["name"].Value,
                    Size = elementSize,
                    Location = new Point(x, startLocation.Y),
                    Font = new Font(Label.DefaultFont.FontFamily, elementSize.Width / 10, FontStyle.Regular),
                    Name = $"labelCat{i + 1}",
                    TextAlign = ContentAlignment.MiddleCenter    
                };
                controls.Add(label);
                x += elementSize.Width;
            }

            // Create buttons
            x = startLocation.X;
            for (int i = 0; i < categories.Count; i++)
            {
                int y = startLocation.Y + elementSize.Height;
                XmlNodeList questions = categories[i].SelectNodes("question");
                for (int j = 0; j < questions.Count; j++)
                {
                    var button = new Button
                    {
                        Text = questions[j].Attributes["value"].Value,
                        Location = new Point(x, y),
                        Size = elementSize
                    };
                    button.Font = new Font(Button.DefaultFont.FontFamily, 20, FontStyle.Regular);
                    button.Name = $"buttonQuestion_{i}_{j}";

                    controls.Add(button);
                    y += elementSize.Height;
                }
                x += elementSize.Width;
            }
        }
    }
}