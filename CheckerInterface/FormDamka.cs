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
    public partial class FormDamka : Form
    {
        private PictureBox[,] m_Board;
        private bool m_IsOpponentHuman;
        private int m_Size;
        private RunGame cheackerGame;
        private PictureBox m_ClikedPictureBox;
        private PictureBox m_PrevClicledPictureBox;
        private Player m_PlayerTurn;
        public FormDamka(string i_Player1Name, string i_Player2Name, int i_BoardSize, bool i_IsOpponentHuman)
        {
            m_Board = new PictureBox[i_BoardSize, i_BoardSize]; 
            InitializeComponent();
            m_Size = i_BoardSize;
            LabelPlayer1Name.Text = i_Player1Name;
            LabelPLayer2Name.Text = i_Player2Name;
            m_IsOpponentHuman = i_IsOpponentHuman;
            m_ClikedPictureBox = new PictureBox();
            m_PrevClicledPictureBox = new PictureBox();
        }
        private void FormDamka_Load(object sender, EventArgs e)
        {
            
            int topPictureBoxPostion = 0;
            int leftPictureBoxPostion;
            int boxWidth = PanelBoard.Size.Width / m_Size;
            int boxHeight = PanelBoard.Size.Height / m_Size;
            for (int i = 0; i < m_Size; i++)
            {
                leftPictureBoxPostion = 0;
                for (int j = 0; j < m_Size; j++)
                {
                    m_Board[i,j] = new PictureBox();
                    m_Board[i, j].Location = new Point(leftPictureBoxPostion, topPictureBoxPostion);
                    m_Board[i, j].Size = new Size(boxWidth, boxHeight);
                    changeBackColor(m_Board[i, j], i, j);
                    PanelBoard.Controls.Add(m_Board[i, j]);
                    leftPictureBoxPostion += boxWidth;
                    m_Board[i, j].Click += PictureBoxOnClick;
                    m_Board[i, j].Name = $"{i},{j}";
                }
                topPictureBoxPostion += boxHeight;
            }
            this.cheackerGame = InitGame.setUp(LabelPlayer1Name.Text, LabelPLayer2Name.Text, m_Size, m_IsOpponentHuman, LogicListener);
            cheackerGame.Player1.Win += OnWin;
            cheackerGame.Player2.Win += OnWin;
            cheackerGame.Player1.PlayerCantMove += OnPlayersCantMove;
            cheackerGame.Player2.PlayerCantMove += OnPlayersCantMove;
            m_PlayerTurn = cheackerGame.Player1;
            LabelDisplayTurn.Text = m_PlayerTurn.Name;
        }

        private void OnPlayersCantMove(Player i_Player1, Player i_Player2)
        {
            if (i_Player1.GetScore() > i_Player2.GetScore())
            {
                OnWin(i_Player1);
            }
            else if (i_Player1.GetScore() < i_Player2.GetScore())
            {
                OnWin(i_Player2);
            }
            else 
            {
                DialogResult dialogResult = MessageBox.Show("Tie !!!", "Damka", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    FormDamka gameBoard = new FormDamka(cheackerGame.Player1.Name, cheackerGame.Player2.Name, m_Size, m_IsOpponentHuman);
                    gameBoard.Show();
                }
            }
        }

        private void OnWin(Player i_Winner)
        {
            DialogResult dialogResult = MessageBox.Show($"Player {i_Winner.Name} Won !!!", "Damka", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Dispose();
                GameMangment.AnotherGame(LabelPlayer1Name.Text, LabelPLayer2Name.Text, m_Size, m_IsOpponentHuman);    
            }
            else
            {
                this.Dispose();
            }          
        }

        private void PictureBoxOnClick(object sender, EventArgs e)
        {
            bool changePrev = true;
            m_ClikedPictureBox = sender as PictureBox;
            if (m_PrevClicledPictureBox.BackColor == Color.LightBlue)
            {
                if (m_PrevClicledPictureBox == m_ClikedPictureBox)
                {
                    m_ClikedPictureBox.BackColor = Color.White;
                }
                else
                {
                    bool isCapture;
                    string move = $"{m_PrevClicledPictureBox.Name}>{m_ClikedPictureBox.Name}";
                    if (!m_PlayerTurn.ValidMove(move, cheackerGame.Board, out isCapture))
                    {
                        MessageBox.Show("Invalid Move!!!");
                        changePrev = false;
                    }
                    else
                    {
                        Player playerOpponent = m_PlayerTurn == cheackerGame.Player1 ? cheackerGame.Player2 : cheackerGame.Player1;
                        m_PlayerTurn.Move(cheackerGame.Board, playerOpponent, move, out isCapture);
                        LogicListener(cheackerGame.Board.CheckerBoard);
                        m_PrevClicledPictureBox.BackColor = Color.White;
                        if (!isCapture)
                        {
                            m_PlayerTurn = m_PlayerTurn == cheackerGame.Player1 ? cheackerGame.Player2 : cheackerGame.Player1;
                        }
                        if (m_PlayerTurn.Name == "Computer")
                        {
                            playerOpponent = m_PlayerTurn == cheackerGame.Player1 ? cheackerGame.Player2 : cheackerGame.Player1;
                            m_PlayerTurn.Move(cheackerGame.Board, playerOpponent, move, out isCapture);
                            while (isCapture)
                            {
                                m_PlayerTurn.Move(cheackerGame.Board, playerOpponent, move, out isCapture);
                            }
                            m_PlayerTurn = m_PlayerTurn == cheackerGame.Player1 ? cheackerGame.Player2 : cheackerGame.Player1;
                            LogicListener(cheackerGame.Board.CheckerBoard);
                            if (!m_PlayerTurn.CanMove(cheackerGame.Board))
                            {
                                m_PlayerTurn = m_PlayerTurn == cheackerGame.Player1 ? cheackerGame.Player2 : cheackerGame.Player1;
                            }
                        }
                    }
                }
            }
            else if (m_ClikedPictureBox.Image != null && m_PlayerTurn.Name.Equals(m_ClikedPictureBox.Tag))
            {
                m_ClikedPictureBox.BackColor = Color.LightBlue;
            }
            if (changePrev)
            {
                m_PrevClicledPictureBox = sender as PictureBox;
            }
            LabelDisplayTurn.Text = m_PlayerTurn.Name;
            labelPlayer1Score.Text = cheackerGame.Player1.GetScore().ToString();
            labelPlayer2Score.Text = cheackerGame.Player2.GetScore().ToString();
        }
        private void changeBackColor(PictureBox i_PictureBoxToChange, int i_Row, int i_Col)
        {
            if (i_Row % 2 ==0 && i_Col % 2 == 0)
            {
                i_PictureBoxToChange.BackColor = Color.Black;
            }
            else if (i_Row % 2 == 0 && i_Col % 2== 1)
            {
                i_PictureBoxToChange.BackColor = Color.White;
            }
            else if (i_Row % 2 == 1 && i_Col % 2 == 1)
            {
                i_PictureBoxToChange.BackColor = Color.Black;
            }
            else
            {
                i_PictureBoxToChange.BackColor = Color.White;
            }
        }
        private void LogicListener(Soldier[,] i_LogicGameBoard)
        {
            for (int i = 1; i < m_Size + 1; i++)
            {
                for (int j = 1; j < m_Size + 1; j++)
                {
                    if (i_LogicGameBoard[i, j] == null)
                    {
                        m_Board[i - 1, j - 1].Image = null;
                    }
                    else if (i_LogicGameBoard[i, j].Type == Soldier.eType.Soldier)
                    {
                        if (i_LogicGameBoard[i, j].PlayerID == 1)
                        {
                            m_Board[i - 1, j - 1].Image = Properties.Resources.blackSolider;
                            m_Board[i - 1, j - 1].Tag = LabelPlayer1Name.Text;
                        }
                        else if (i_LogicGameBoard[i, j].PlayerID == 2)
                        {
                            m_Board[i - 1, j - 1].Image = Properties.Resources.redSolider;
                            m_Board[i - 1, j - 1].Tag = LabelPLayer2Name.Text;
                        }
                    }
                    else if (i_LogicGameBoard[i, j].Type == Soldier.eType.King)
                    {
                        if (i_LogicGameBoard[i, j].PlayerID == 1)
                        {
                            m_Board[i - 1, j - 1].Image = Properties.Resources.blackKing;
                            m_Board[i - 1, j - 1].Tag = LabelPlayer1Name.Text;

                        }
                        else if (i_LogicGameBoard[i, j].PlayerID == 2)
                        {
                            m_Board[i - 1, j - 1].Image = Properties.Resources.redKing;
                            m_Board[i - 1, j - 1].Tag = LabelPLayer2Name.Text;
                        }
                    }
                    m_Board[i - 1, j - 1].SizeMode = PictureBoxSizeMode.CenterImage;
                    m_Board[i - 1, j - 1].SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }
    }
}
