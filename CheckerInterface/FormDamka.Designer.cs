namespace CheckerInterface
{
    partial class FormDamka
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
            this.PanelBoard = new System.Windows.Forms.Panel();
            this.LabelPlayer1Name = new System.Windows.Forms.Label();
            this.LabelPLayer2Name = new System.Windows.Forms.Label();
            this.LabelPlayerTurn = new System.Windows.Forms.Label();
            this.LabelDisplayTurn = new System.Windows.Forms.Label();
            this.labelPlayer1Score = new System.Windows.Forms.Label();
            this.labelPlayer2Score = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PanelBoard
            // 
            this.PanelBoard.AllowDrop = true;
            this.PanelBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelBoard.AutoSize = true;
            this.PanelBoard.Location = new System.Drawing.Point(70, 114);
            this.PanelBoard.Name = "PanelBoard";
            this.PanelBoard.Size = new System.Drawing.Size(960, 662);
            this.PanelBoard.TabIndex = 0;
            // 
            // LabelPlayer1Name
            // 
            this.LabelPlayer1Name.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelPlayer1Name.AutoSize = true;
            this.LabelPlayer1Name.Location = new System.Drawing.Point(202, 14);
            this.LabelPlayer1Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelPlayer1Name.Name = "LabelPlayer1Name";
            this.LabelPlayer1Name.Size = new System.Drawing.Size(111, 20);
            this.LabelPlayer1Name.TabIndex = 2;
            this.LabelPlayer1Name.Text = "Player 1 Name";
            // 
            // LabelPLayer2Name
            // 
            this.LabelPLayer2Name.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelPLayer2Name.AutoSize = true;
            this.LabelPLayer2Name.Location = new System.Drawing.Point(753, 14);
            this.LabelPLayer2Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelPLayer2Name.Name = "LabelPLayer2Name";
            this.LabelPLayer2Name.Size = new System.Drawing.Size(117, 20);
            this.LabelPLayer2Name.TabIndex = 3;
            this.LabelPLayer2Name.Text = "PLayer 2 Name";
            // 
            // LabelPlayerTurn
            // 
            this.LabelPlayerTurn.AutoSize = true;
            this.LabelPlayerTurn.Location = new System.Drawing.Point(472, 27);
            this.LabelPlayerTurn.Name = "LabelPlayerTurn";
            this.LabelPlayerTurn.Size = new System.Drawing.Size(92, 20);
            this.LabelPlayerTurn.TabIndex = 4;
            this.LabelPlayerTurn.Text = "Player Turn:";
            // 
            // LabelDisplayTurn
            // 
            this.LabelDisplayTurn.AutoSize = true;
            this.LabelDisplayTurn.Location = new System.Drawing.Point(476, 65);
            this.LabelDisplayTurn.Name = "LabelDisplayTurn";
            this.LabelDisplayTurn.Size = new System.Drawing.Size(0, 20);
            this.LabelDisplayTurn.TabIndex = 5;
            // 
            // labelPlayer1Score
            // 
            this.labelPlayer1Score.AutoSize = true;
            this.labelPlayer1Score.Location = new System.Drawing.Point(332, 13);
            this.labelPlayer1Score.Name = "labelPlayer1Score";
            this.labelPlayer1Score.Size = new System.Drawing.Size(0, 20);
            this.labelPlayer1Score.TabIndex = 6;
            // 
            // labelPlayer2Score
            // 
            this.labelPlayer2Score.AutoSize = true;
            this.labelPlayer2Score.Location = new System.Drawing.Point(887, 13);
            this.labelPlayer2Score.Name = "labelPlayer2Score";
            this.labelPlayer2Score.Size = new System.Drawing.Size(0, 20);
            this.labelPlayer2Score.TabIndex = 7;
            // 
            // FormDamka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 838);
            this.Controls.Add(this.labelPlayer2Score);
            this.Controls.Add(this.labelPlayer1Score);
            this.Controls.Add(this.LabelDisplayTurn);
            this.Controls.Add(this.LabelPlayerTurn);
            this.Controls.Add(this.LabelPLayer2Name);
            this.Controls.Add(this.LabelPlayer1Name);
            this.Controls.Add(this.PanelBoard);
            this.Name = "FormDamka";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Damka";
            this.Load += new System.EventHandler(this.FormDamka_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelBoard;
        private System.Windows.Forms.Label LabelPlayer1Name;
        private System.Windows.Forms.Label LabelPLayer2Name;
        private System.Windows.Forms.Label LabelPlayerTurn;
        private System.Windows.Forms.Label LabelDisplayTurn;
        private System.Windows.Forms.Label labelPlayer1Score;
        private System.Windows.Forms.Label labelPlayer2Score;
    }
}