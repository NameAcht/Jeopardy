namespace Jeopardy_winForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSettings = new System.Windows.Forms.Button();
            this.listViewStandings = new System.Windows.Forms.ListView();
            this.columnPlayer = new System.Windows.Forms.ColumnHeader();
            this.columnPoints = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // buttonSettings
            // 
            this.buttonSettings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSettings.BackColor = System.Drawing.SystemColors.Control;
            this.buttonSettings.BackgroundImage = global::Jeopardy_winForms.Properties.Resources.settings;
            this.buttonSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSettings.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSettings.Location = new System.Drawing.Point(1472, 9);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(100, 100);
            this.buttonSettings.TabIndex = 6;
            this.buttonSettings.UseVisualStyleBackColor = false;
            this.buttonSettings.Click += new System.EventHandler(this.ButtonSettings_Click);
            // 
            // listView1
            // 
            this.listViewStandings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listViewStandings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnPlayer,
            this.columnPoints});
            this.listViewStandings.FullRowSelect = true;
            this.listViewStandings.GridLines = true;
            this.listViewStandings.Location = new System.Drawing.Point(1372, 115);
            this.listViewStandings.Name = "listView1";
            this.listViewStandings.Size = new System.Drawing.Size(200, 434);
            this.listViewStandings.TabIndex = 10;
            this.listViewStandings.UseCompatibleStateImageBehavior = false;
            this.listViewStandings.View = System.Windows.Forms.View.Details;
            // 
            // columnPlayer
            // 
            this.columnPlayer.Text = "Player";
            this.columnPlayer.Width = 98;
            // 
            // columnPoints
            // 
            this.columnPoints.Text = "Points";
            this.columnPoints.Width = 98;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.listViewStandings);
            this.Controls.Add(this.buttonSettings);
            this.Name = "MainForm";
            this.Text = "Jeopardy";
            this.ResumeLayout(false);

        }

        #endregion

        private Button buttonSettings;
        private ListView listViewStandings;
        private ColumnHeader columnPlayer;
        private ColumnHeader columnPoints;
    }
}