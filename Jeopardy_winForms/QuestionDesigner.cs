using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jeopardy_winForms
{
    public partial class QuestionDesigner : Form
    {
        public QuestionDesigner(int categoryNumber, int questionNumber)
        {
            InitializeComponent(); 
            CategoryNumber = categoryNumber;
            QuestionNumber = questionNumber;
            Text += "Category " + CategoryNumber + ", Question " + QuestionNumber;
            Load += QuestionDesigner_Load;
        }

        private int CategoryNumber { get; set; }
        private int QuestionNumber { get; set; }

        private void QuestionDesigner_Load(object sender, EventArgs e)
        {
            string filePath = "save/bg" + "_" + CategoryNumber + "_" + QuestionNumber + ".jpg";
            if (!File.Exists(filePath))
                return;
            BackgroundImage = Image.FromFile(filePath);
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void buttonSetBackground_Click(object sender, EventArgs e)
        {
            // Create a new instance of the OpenFileDialog
            OpenFileDialog fileDialog = new OpenFileDialog();

            // Set the filter to allow only image files
            fileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";
            
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file name
                string fileName = fileDialog.FileName;

                // Set the image as the background of the form
                BackgroundImage.Dispose();
                Image.FromFile(fileName).Save("save/bg" + "_" + CategoryNumber + "_" + QuestionNumber + ".jpg");
                BackgroundImage = Image.FromFile(fileName);
                BackgroundImageLayout = ImageLayout.Stretch;
            }
        }
    }
}
