namespace CheckerInterface
{
    partial class FormGameSettings
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
            this.LabelBoardSize = new System.Windows.Forms.Label();
            this.RadioButton6On6 = new System.Windows.Forms.RadioButton();
            this.RadioButton8On8 = new System.Windows.Forms.RadioButton();
            this.RadioButton10On10 = new System.Windows.Forms.RadioButton();
            this.LabelPlayers = new System.Windows.Forms.Label();
            this.LabelPLayer1 = new System.Windows.Forms.Label();
            this.TextBoxPlayer1Name = new System.Windows.Forms.TextBox();
            this.CheckBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.TextBoxPlayer2Name = new System.Windows.Forms.TextBox();
            this.ButtonDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelBoardSize
            // 
            this.LabelBoardSize.AutoSize = true;
            this.LabelBoardSize.Location = new System.Drawing.Point(34, 18);
            this.LabelBoardSize.Name = "LabelBoardSize";
            this.LabelBoardSize.Size = new System.Drawing.Size(91, 20);
            this.LabelBoardSize.TabIndex = 0;
            this.LabelBoardSize.Text = "Board Size:";
            // 
            // RadioButton6On6
            // 
            this.RadioButton6On6.AutoSize = true;
            this.RadioButton6On6.Location = new System.Drawing.Point(58, 63);
            this.RadioButton6On6.Name = "RadioButton6On6";
            this.RadioButton6On6.Size = new System.Drawing.Size(60, 24);
            this.RadioButton6On6.TabIndex = 1;
            this.RadioButton6On6.TabStop = true;
            this.RadioButton6On6.Text = "6 x 6";
            this.RadioButton6On6.UseVisualStyleBackColor = true;
            // 
            // RadioButton8On8
            // 
            this.RadioButton8On8.AutoSize = true;
            this.RadioButton8On8.Location = new System.Drawing.Point(140, 63);
            this.RadioButton8On8.Name = "RadioButton8On8";
            this.RadioButton8On8.Size = new System.Drawing.Size(60, 24);
            this.RadioButton8On8.TabIndex = 2;
            this.RadioButton8On8.TabStop = true;
            this.RadioButton8On8.Text = "8 x 8";
            this.RadioButton8On8.UseVisualStyleBackColor = true;
            // 
            // RadioButton10On10
            // 
            this.RadioButton10On10.AutoSize = true;
            this.RadioButton10On10.Location = new System.Drawing.Point(232, 65);
            this.RadioButton10On10.Name = "RadioButton10On10";
            this.RadioButton10On10.Size = new System.Drawing.Size(78, 24);
            this.RadioButton10On10.TabIndex = 3;
            this.RadioButton10On10.TabStop = true;
            this.RadioButton10On10.Text = "10 x 10";
            this.RadioButton10On10.UseVisualStyleBackColor = true;
            // 
            // LabelPlayers
            // 
            this.LabelPlayers.AutoSize = true;
            this.LabelPlayers.Location = new System.Drawing.Point(39, 125);
            this.LabelPlayers.Name = "LabelPlayers";
            this.LabelPlayers.Size = new System.Drawing.Size(64, 20);
            this.LabelPlayers.TabIndex = 4;
            this.LabelPlayers.Text = "Players:";
            // 
            // LabelPLayer1
            // 
            this.LabelPLayer1.AutoSize = true;
            this.LabelPLayer1.Location = new System.Drawing.Point(64, 162);
            this.LabelPLayer1.Name = "LabelPLayer1";
            this.LabelPLayer1.Size = new System.Drawing.Size(69, 20);
            this.LabelPLayer1.TabIndex = 5;
            this.LabelPLayer1.Text = "Player 1:";
            // 
            // TextBoxPlayer1Name
            // 
            this.TextBoxPlayer1Name.Location = new System.Drawing.Point(170, 162);
            this.TextBoxPlayer1Name.Name = "TextBoxPlayer1Name";
            this.TextBoxPlayer1Name.Size = new System.Drawing.Size(132, 26);
            this.TextBoxPlayer1Name.TabIndex = 6;
            // 
            // CheckBoxPlayer2
            // 
            this.CheckBoxPlayer2.AutoSize = true;
            this.CheckBoxPlayer2.Location = new System.Drawing.Point(69, 209);
            this.CheckBoxPlayer2.Name = "CheckBoxPlayer2";
            this.CheckBoxPlayer2.Size = new System.Drawing.Size(88, 24);
            this.CheckBoxPlayer2.TabIndex = 7;
            this.CheckBoxPlayer2.Text = "Player 2:";
            this.CheckBoxPlayer2.UseVisualStyleBackColor = true;
            this.CheckBoxPlayer2.CheckedChanged += new System.EventHandler(this.CheckBoxPlayer2_CheckedChanged);
            // 
            // TextBoxPlayer2Name
            // 
            this.TextBoxPlayer2Name.Enabled = false;
            this.TextBoxPlayer2Name.Location = new System.Drawing.Point(170, 208);
            this.TextBoxPlayer2Name.Name = "TextBoxPlayer2Name";
            this.TextBoxPlayer2Name.Size = new System.Drawing.Size(132, 26);
            this.TextBoxPlayer2Name.TabIndex = 8;
            this.TextBoxPlayer2Name.Text = "[Computer]";
            // 
            // ButtonDone
            // 
            this.ButtonDone.Location = new System.Drawing.Point(210, 255);
            this.ButtonDone.Name = "ButtonDone";
            this.ButtonDone.Size = new System.Drawing.Size(92, 42);
            this.ButtonDone.TabIndex = 9;
            this.ButtonDone.Text = "Done";
            this.ButtonDone.UseVisualStyleBackColor = true;
            this.ButtonDone.Click += new System.EventHandler(this.ButtonDone_Click);
            // 
            // FormGameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 311);
            this.Controls.Add(this.ButtonDone);
            this.Controls.Add(this.TextBoxPlayer2Name);
            this.Controls.Add(this.CheckBoxPlayer2);
            this.Controls.Add(this.TextBoxPlayer1Name);
            this.Controls.Add(this.LabelPLayer1);
            this.Controls.Add(this.LabelPlayers);
            this.Controls.Add(this.RadioButton10On10);
            this.Controls.Add(this.RadioButton8On8);
            this.Controls.Add(this.RadioButton6On6);
            this.Controls.Add(this.LabelBoardSize);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGameSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelBoardSize;
        private System.Windows.Forms.RadioButton RadioButton6On6;
        private System.Windows.Forms.RadioButton RadioButton8On8;
        private System.Windows.Forms.RadioButton RadioButton10On10;
        private System.Windows.Forms.Label LabelPlayers;
        private System.Windows.Forms.Label LabelPLayer1;
        private System.Windows.Forms.TextBox TextBoxPlayer1Name;
        private System.Windows.Forms.CheckBox CheckBoxPlayer2;
        private System.Windows.Forms.TextBox TextBoxPlayer2Name;
        private System.Windows.Forms.Button ButtonDone;
    }
}

