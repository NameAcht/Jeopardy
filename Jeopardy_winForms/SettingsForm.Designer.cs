namespace Jeopardy_winForms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxAddPlayer = new System.Windows.Forms.TextBox();
            this.labelPlayerName = new System.Windows.Forms.Label();
            this.labelPlayers = new System.Windows.Forms.Label();
            this.listBoxPlayers = new System.Windows.Forms.ListBox();
            this.buttonAddPlayer = new System.Windows.Forms.Button();
            this.buttonDeletePlayer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxAddPlayer
            // 
            this.textBoxAddPlayer.Location = new System.Drawing.Point(12, 27);
            this.textBoxAddPlayer.Name = "textBoxAddPlayer";
            this.textBoxAddPlayer.Size = new System.Drawing.Size(143, 23);
            this.textBoxAddPlayer.TabIndex = 1;
            this.textBoxAddPlayer.TextChanged += new System.EventHandler(this.textBoxAddPlayer_TextChanged);
            // 
            // labelPlayerName
            // 
            this.labelPlayerName.AutoSize = true;
            this.labelPlayerName.Location = new System.Drawing.Point(12, 9);
            this.labelPlayerName.Name = "labelPlayerName";
            this.labelPlayerName.Size = new System.Drawing.Size(77, 15);
            this.labelPlayerName.TabIndex = 2;
            this.labelPlayerName.Text = "Player Name:";
            // 
            // labelPlayers
            // 
            this.labelPlayers.AutoSize = true;
            this.labelPlayers.Location = new System.Drawing.Point(12, 100);
            this.labelPlayers.Name = "labelPlayers";
            this.labelPlayers.Size = new System.Drawing.Size(47, 15);
            this.labelPlayers.TabIndex = 3;
            this.labelPlayers.Text = "Players:";
            // 
            // listBoxPlayers
            // 
            this.listBoxPlayers.FormattingEnabled = true;
            this.listBoxPlayers.ItemHeight = 15;
            this.listBoxPlayers.Location = new System.Drawing.Point(12, 118);
            this.listBoxPlayers.Name = "listBoxPlayers";
            this.listBoxPlayers.Size = new System.Drawing.Size(143, 214);
            this.listBoxPlayers.TabIndex = 4;
            // 
            // buttonAddPlayer
            // 
            this.buttonAddPlayer.Enabled = false;
            this.buttonAddPlayer.Location = new System.Drawing.Point(12, 56);
            this.buttonAddPlayer.Name = "buttonAddPlayer";
            this.buttonAddPlayer.Size = new System.Drawing.Size(143, 41);
            this.buttonAddPlayer.TabIndex = 0;
            this.buttonAddPlayer.Text = "Add Player";
            this.buttonAddPlayer.UseVisualStyleBackColor = true;
            this.buttonAddPlayer.Click += new System.EventHandler(this.buttonAddPlayer_Click);
            // 
            // buttonDeletePlayer
            // 
            this.buttonDeletePlayer.Location = new System.Drawing.Point(12, 338);
            this.buttonDeletePlayer.Name = "buttonDeletePlayer";
            this.buttonDeletePlayer.Size = new System.Drawing.Size(143, 41);
            this.buttonDeletePlayer.TabIndex = 5;
            this.buttonDeletePlayer.Text = "Delete Selected Player";
            this.buttonDeletePlayer.UseVisualStyleBackColor = true;
            this.buttonDeletePlayer.Click += new System.EventHandler(this.buttonDeletePlayer_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 760);
            this.Controls.Add(this.buttonDeletePlayer);
            this.Controls.Add(this.listBoxPlayers);
            this.Controls.Add(this.labelPlayers);
            this.Controls.Add(this.labelPlayerName);
            this.Controls.Add(this.textBoxAddPlayer);
            this.Controls.Add(this.buttonAddPlayer);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox textBoxAddPlayer;
        private Label labelPlayerName;
        private Label labelPlayers;
        private ListBox listBoxPlayers;
        private Button buttonAddPlayer;
        private Button buttonDeletePlayer;
    }
}