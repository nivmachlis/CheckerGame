using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheckerGame;

namespace CheckerInterface
{
    public partial class FormGameSettings : Form
    {
        public FormGameSettings()
        {
            InitializeComponent();
        }

        private void CheckBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxPlayer2.Checked)
            {
                TextBoxPlayer2Name.Text = String.Empty;
                TextBoxPlayer2Name.Enabled = true;
            }
            else
            {
                TextBoxPlayer2Name.Text = "[Computer]";
                TextBoxPlayer2Name.Enabled = false;
            }
        }

        private void ButtonDone_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public string GetPlayer1Name()
        {
            return TextBoxPlayer1Name.Text;
        }

        public string GetPlayer2Name()
        {
            return TextBoxPlayer2Name.Text;
        }

        public bool IsPlayer2Human()
        {
            return CheckBoxPlayer2.Checked;
        }

        public int GetBoardSize()
        {
            int boardSize;
            if (RadioButton6On6.Checked)
            {
                boardSize = 6;
            }
            else if (RadioButton8On8.Checked)
            {
                boardSize = 8;
            }
            else
            {
                boardSize = 10;
            }
            return boardSize;
        }
    }
}
