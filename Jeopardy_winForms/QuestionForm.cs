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
    public partial class QuestionForm : Form
    {
        private int CategoryNumber { get; set; }
        private int QuestionNumber { get; set; }
        private void LoadBackground()
        {
            if(File.Exists("save/bg_" + CategoryNumber + "_" + QuestionNumber + ".jpg"))
                BackgroundImage = Image.FromFile("save/bg_" + CategoryNumber + "_" + QuestionNumber + ".jpg");
            BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void QuestionForm_Load(object sender, EventArgs e)
        {
            LoadBackground();
        }
        public QuestionForm(int categoryNumber, int questionNumber)
        {
            InitializeComponent();
            CategoryNumber = categoryNumber + 1;
            QuestionNumber = questionNumber + 1;
            Text += CategoryNumber + " Question " + QuestionNumber;
            Load += QuestionForm_Load;
        }
    }
}
