namespace Jeopardy_winForms
{
    partial class QuestionDesigner
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
            this.buttonSetBackground = new System.Windows.Forms.Button();
            this.groupBoxEditor = new System.Windows.Forms.GroupBox();
            this.groupBoxEditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSetBackground
            // 
            this.buttonSetBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetBackground.Location = new System.Drawing.Point(63, 750);
            this.buttonSetBackground.Name = "buttonSetBackground";
            this.buttonSetBackground.Size = new System.Drawing.Size(142, 41);
            this.buttonSetBackground.TabIndex = 0;
            this.buttonSetBackground.Text = "Set Background";
            this.buttonSetBackground.UseVisualStyleBackColor = true;
            this.buttonSetBackground.Click += new System.EventHandler(this.buttonSetBackground_Click);
            // 
            // groupBoxEditor
            // 
            this.groupBoxEditor.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBoxEditor.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxEditor.Controls.Add(this.buttonSetBackground);
            this.groupBoxEditor.Location = new System.Drawing.Point(1175, 12);
            this.groupBoxEditor.Name = "groupBoxEditor";
            this.groupBoxEditor.Size = new System.Drawing.Size(211, 797);
            this.groupBoxEditor.TabIndex = 1;
            this.groupBoxEditor.TabStop = false;
            this.groupBoxEditor.Text = "Editor";
            // 
            // QuestionDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1398, 821);
            this.Controls.Add(this.groupBoxEditor);
            this.Name = "QuestionDesigner";
            this.Text = "Edit Question: ";
            this.groupBoxEditor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button buttonSetBackground;
        private GroupBox groupBoxEditor;
    }
}